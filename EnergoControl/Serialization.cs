using System;
using System.IO;

namespace EnergoControl
{
    class Serialization // Класс для сериализации и хранения полученных данных
    {
        public Serialization() // Конструктор 
        {

        }

        public void WriteToDataBase(double[,] WhatWrite, int Identificator) // Запись в файл 
        {
            using (StreamWriter SW = new StreamWriter(Directory.GetCurrentDirectory() + "\\" + Identificator + "\\" + CreateNameFile() +".dat",true))
            {
                SW.WriteLine(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss")); // Запись даты 
                SW.WriteLine(CreateString(WhatWrite, 0)); // Запись тока
                SW.WriteLine(CreateString(WhatWrite, 1)); // Запись напряжения
                SW.WriteLine(CreateString(WhatWrite, 2)); // Запись косинуса FI
                SW.WriteLine();
            }
        }

        string CreateString(double[,] InfoToWrite, int i) // Разпарсиваем все обратно 
        {
            // i что записываем
            // j какая фаза
            string WW = "";
            for (int j = 0; j < 3; j++)
            {
                WW += InfoToWrite[i, j] + " ";
            }
            return WW;
        }

        string CreateNameFile() // Создаем подходящее относительно даты время
        {
            string Name = DateTime.Today.ToString("dd.MM.yyyy");
            return Name;
        }
    }
}
