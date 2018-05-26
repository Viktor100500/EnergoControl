using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO.Ports;
using System.Windows.Forms;
using DocumentFormat.OpenXml.Office2010.PowerPoint;
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml.Wordprocessing;

namespace EnergoControl
{
    public class InterrogationСounter // Класс для опроса счетчиков
    {
        SerialPort _serialPort; // Используемый порт
        private bool _Cancelled = false; // Флаг отмены

        public InterrogationСounter(string Name) // Конструктор 
        {
            // Устанавливаем свойства порта
            _serialPort = new SerialPort
            {
                PortName = Name,
                BaudRate = 9600,
                Parity = Parity.Even,
                DataBits = 7,
                StopBits = StopBits.One,
                ReadBufferSize = 4096,
                ReadTimeout = 5000,
                WriteTimeout = 5000
            };
        }

        public void Cancel() // Отмена 
        {
            _Cancelled = true;
        }

        public void Request(NewCounter[] Current) // Основная фукнция работы опрашивания счетчика 
        {
            while (!_Cancelled)
            {
                for (int i = 0; i < Current.Length; i++)
                {
                    if (!_Cancelled) // Нажата ли кнопка отмены
                    {
                        if (!_serialPort.IsOpen) // Открываем порт
                            _serialPort.Open();

                        Inquiry(Current[i].Name, Current[i]);

                        if (_serialPort.IsOpen) _serialPort.Close(); // Закрываем порт
                        _serialPort.Dispose();
                        }
                    else // Высвобождаем ресурсы 
                    {
                        _serialPort.Close(); _serialPort.Dispose();
                        break;
                    }
                }
            }
        }

        public void Inquiry(string IDCounter, NewCounter Current) // Функция запроса тока и напряжения 
        {
            try
            {
                byte[] ByteMassiv = new byte[5 + IDCounter.Length]; // Формирование первого запроса в зависимости от модели счетчика
                ByteMassiv[0] = 0x2F;
                ByteMassiv[1] = 0x3F;
                for (int j = 2; j < IDCounter.Length + 2; j++)
                {
                    ByteMassiv[j] = (byte)IDCounter[j - 2];
                }
                ByteMassiv[IDCounter.Length + 2] = 0x21;
                ByteMassiv[IDCounter.Length + 3] = 0x0D;
                ByteMassiv[IDCounter.Length + 4] = 0x0A;

                RequestWithoutWrite(ByteMassiv); // Первый запрос            
                RequestWithoutWrite(ByteMassiv = new byte[] { 0x06, 0x30, 0x35, 0x31, 0x0D, 0x0A }); // Второй запрос
                RequestWithoutWrite(ByteMassiv = new byte[] { 0x01, 0x52, 0x31, 0x02, 0x49, 0x44, 0x45, 0x4E, 0x54, 0x28, 0x29, 0x03, 0x4D }); // Запрос спецификаций счетчика
                RequestWithoutWrite(ByteMassiv = new byte[] { 0x01, 0x52, 0x31, 0x02, 0x53, 0x4E, 0x55, 0x4D, 0x42, 0x28, 0x29, 0x03, 0x5E }); // Третий запрос серийного номера
                RequestWithoutWrite(ByteMassiv = new byte[] { 0x01, 0x52, 0x31, 0x02, 0x49, 0x44, 0x50, 0x41, 0x53, 0x28, 0x29, 0x03, 0x4A }); // запрос идентификатора


                RequestWithWrite(ByteMassiv = new byte[] { 0x01, 0x52, 0x31, 0x02, 0x43, 0x55, 0x52, 0x52, 0x45, 0x28, 0x29, 0x03, 0x5A }, Current, 0); // Четвертый запрос тока
                RequestWithWrite(ByteMassiv = new byte[] { 0x01, 0x52, 0x31, 0x02, 0x56, 0x4F, 0x4C, 0x54, 0x41, 0x28, 0x29, 0x03, 0x5F }, Current, 1); // Пятый запрос напряжения
                RequestWithWrite(ByteMassiv = new byte[] { 0x01, 0x52, 0x31, 0x02, 0x56, 0x4F, 0x4C, 0x54, 0x41, 0x28, 0x29, 0x03, 0x5F }, Current, 1); // Запрос косинуса FI


                ByteMassiv = new byte[] { 0x01, 0x42, 0x30, 0x03, 0x75 }; // Шестой запрос прощание
                _serialPort.Write(ByteMassiv, 0, ByteMassiv.Length);
                Thread.Sleep(600);
                ByteMassiv = new byte[_serialPort.ReadBufferSize];
                ByteMassiv = null;

                DelegateWriteException D1 = Current.WriteGoodEnd;
                Current.Invoke(D1);
            }
            catch
            {
                DelegateWriteException D1 = Current.WriteException;
                Current.Invoke(D1);
            }
        }

        public void RequestWithoutWrite(byte[] ByteMassiv) // Работа каждой итерации опроса без записи результата 
        {
                _serialPort.Write(ByteMassiv, 0, ByteMassiv.Length);
                Thread.Sleep(600);
                ByteMassiv = new byte[_serialPort.ReadBufferSize];
                _serialPort.Read(ByteMassiv, 0, ByteMassiv.Length);
                ByteMassiv = null;
        }

        public void RequestWithWrite(byte[] ByteMassiv, NewCounter Current, int CurOrVolOrCos) // Работа опроса с записью результата 
        {
            _serialPort.Write(ByteMassiv, 0, ByteMassiv.Length);
            Thread.Sleep(600);
            ByteMassiv = new byte[_serialPort.ReadBufferSize];
            _serialPort.Read(ByteMassiv, 0, ByteMassiv.Length);
            if (ByteMassiv[0] != 0)
            {
                DelegateWriteCurAndVol D1 = Current.WriteVoltageorCurrent;
                Current.Invoke(D1, System.Text.Encoding.UTF8.GetString(ByteMassiv), CurOrVolOrCos);
            }
            else
            {
                DelegateWriteCurAndVol D1 = Current.WriteVoltageorCurrent;
                Current.Invoke(D1, System.Text.Encoding.UTF8.GetString(ByteMassiv), CurOrVolOrCos);
            }
        }

        void WriteToDataBase(string ByteMassiv, int CurOrVolOrCos)
        {
            string WhatParse = (string)ByteMassiv.Clone();
            switch (CurOrVolOrCos)
            {
                case 0:
                    //WhatParse = WhatParse.Replace('.', ',');
                    //int start = WhatParse.IndexOf('(') + 1;
                    //int end = WhatParse.IndexOf(')');
                    //for (int j = 0; j < 3; j++)
                    //{
                    //    CurAndVol[CurrentIndex, j].Text = WhatParse.Substring(start, end - start);
                    //    WhatParse = WhatParse.Substring(end + 1);
                    //    start = WhatParse.IndexOf('(') + 1;
                    //    end = WhatParse.IndexOf(')');
                    //}
                    break;
                case 1:
                    break;
                case 2:
                    break;
            }
        }
    }
}
