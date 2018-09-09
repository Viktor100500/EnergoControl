using System;
using System.IO.Ports;
using System.Threading;
using System.Threading.Tasks;

namespace EnergoControl
{
    public delegate void DelegateWriteToDataBase(double[,] WW, int ID); // Делегат для записи в файл

    public class InterrogationСounter // Класс для опроса счетчиков
    {
        private SerialPort _serialPort; // Используемый порт
        private bool _Cancelled = false; // Флаг отмены
        private double[,] Indications; // Массив с показаниями [Тип показания, Фаза]
        private bool AllRequsted; // Флаг проверки опроса всех счетчиков
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

        public void Request(NewCounter[] Current, AmountCounter SumForm) // Основная фукнция работы опрашивания счетчика 
        {
            while (!_Cancelled)
            {
                double[] Summary = new double[3]; // Сумма мощностей на каждой фазе
                for (int i = 0; i < Current.Length; i++)
                {
                    if (!_Cancelled) // Нажата ли кнопка отмены
                    {
                        try
                        {
                            if (!_serialPort.IsOpen) // Открываем порт
                                _serialPort.Open();
                        }
                        catch
                        {
                        }
                        
                        Indications = new double[3, 3]; // Создаем новый массив показаний
                        Inquiry(Current[i].Name, Current[i]); // Делаем запрос и заполняем форму
                        Summation(ref Summary); // Суммируем результаты
                        if (_serialPort.IsOpen) _serialPort.Close(); // Закрываем порт
                        _serialPort.Dispose();
                    }
                    else // Высвобождаем ресурсы 
                    {
                        _serialPort.Close(); _serialPort.Dispose();
                        break;
                    }
                }

                if (AllRequsted)
                {
                    DelegateWriteSummary D1 = SumForm.ChooseTypeWrite; // Выполняем делегат суммирующего графика
                    SumForm.Invoke(D1, Summary);
                }
            }
        }

        public void Inquiry(string IDCounter, NewCounter Current) // Функция запроса тока и напряжения 
        {
            try
            {
                AllRequsted = true;
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

                RequestWithWrite(ByteMassiv = new byte[]
                {
                    0x01, 0x52, 0x31, 0x02, 0x43, 0x55, 0x52, 0x52, 0x45, 0x28, 0x29, 0x03, 0x5A
                }, Current, 0); // Четвертый запрос тока
                RequestWithWrite(ByteMassiv = new byte[]
                {
                    0x01, 0x52, 0x31, 0x02, 0x56, 0x4F, 0x4C, 0x54, 0x41, 0x28, 0x29, 0x03, 0x5F
                }, Current, 1); // Пятый запрос напряжения
                RequestWithWrite(ByteMassiv = new byte[]
                {
                    0x01, 0x52, 0x31, 0x02, 0x43, 0x4F, 0x52, 0x49, 0x55, 0x28, 0x29, 0x03, 0x5B
                }, Current, 2); // Запрос косинуса FI

                ByteMassiv = new byte[] { 0x01, 0x42, 0x30, 0x03, 0x75 }; // Шестой запрос прощание
                _serialPort.Write(ByteMassiv, 0, ByteMassiv.Length);
                Thread.Sleep(600);
                ByteMassiv = new byte[_serialPort.ReadBufferSize];
                ByteMassiv = null;
            }
            catch
            {
                DelegateWriteException D1 = Current.WriteException;
                Current.Invoke(D1);
                AllRequsted = false;
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

            ParseIncomingMessage(System.Text.Encoding.UTF8.GetString(ByteMassiv), CurOrVolOrCos); // Записываем результаты в массив
            DelegateWriteCurAndVol D1 = Current.WriteIndications;
            Current.Invoke(D1, Indications, CurOrVolOrCos); // Записываем результаты на форму

            if (CurOrVolOrCos == 2) // Если это последний запрос, записываем данные в базу данных
            {
                Serialization _WRITE = new Serialization(); // Создаем рабочий класс записи
                Task.Factory.StartNew(() => _WRITE.WriteToDataBase(Indications, Int16.Parse(Current.Name))); // Открываем в новом потоке
            }
        }

        private void ParseIncomingMessage(string WhatParse, int CurOrVolOrCos) // Парсинг входящего сообщения 
        {
            WhatParse = WhatParse.Replace('.', ',');
            int start = WhatParse.IndexOf('(') + 1;
            int end = WhatParse.IndexOf(')');
            for (int j = 0; j < 3; j++)
            {
                Indications[CurOrVolOrCos, j] = Double.Parse(WhatParse.Substring(start, end - start));
                WhatParse = WhatParse.Substring(end + 1);
                start = WhatParse.IndexOf('(') + 1;
                end = WhatParse.IndexOf(')');
            }

            if (CurOrVolOrCos == 2) // Приводим к косинусу
            {
                for (int i = 0; i < 3; i++)
                {
                    double rad = Indications[2, i] * (Math.PI / 180.0);
                    Indications[2, i] = Math.Cos(rad);
                }
            }
        }

        void Summation(ref double[] Summa) // Суммируем показания мощности счетчиков по каждой фазе 
        {
            // 0 - полная мощность
            // 1 - активная мощность
            Summa[1] += Indications[0, 0] * Indications[1, 0] * Indications[2, 0] + Indications[0, 1] * Indications[1, 1] * Indications[2, 1]+ Indications[0, 2] * Indications[1, 2] * Indications[2, 2]; // Активная мощность 
            Summa[0] += Indications[0, 0] * Indications[1, 0] + Indications[0, 1] * Indications[1, 1] + Indications[0, 2] * Indications[1, 2]; // Полная мощность
        }

    }
}
