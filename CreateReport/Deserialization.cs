using System;
using System.Collections.Generic;
using System.IO;

namespace CreateReport
{
    // Класс для чтения информации 
    class Deserialization
    {
        // Переменные
        private string IDCounter; // Айди текущего счетчка

        private DateTime After; // Время после которого нужно записывать данные

        private DateTime Before; // Время до которого нужно записывать данные 
        // Свойства 
        public List<DateTime> Times { get; set; } // Список значений времен

        // i что записываем
        // j какая фаза
        public List<double[,]> Indications { get; set; } // Список показаний

        public Deserialization(DateTime _After, DateTime _Before, string _IDCounter) // Конструктор 
        {
            After = _After;
            Before = _Before;
            IDCounter = _IDCounter;
            Times = new List<DateTime>();
            Indications = new List<double[,]>();
        }

        public bool FindIndications() // ГЛАВНАЯ функция поиска и парсинга нужных данных 
        {
            bool ok = false;
            List<string> SuitableFiles = FindSuitableFiles();
            if (SuitableFiles.Count != 0)
            {
                for (int i = 0; i < SuitableFiles.Count; i++) // Заполняем все индикаторы  
                {
                    ok = FillInTheListOfIndications(SuitableFiles[i]);
                }
            }

            return ok;
        }

        List<string> FindSuitableFiles() // Поиск и окрытие подходящих файлов 
        {
            string[] Files = Directory.GetFiles(IDCounter); // Массив всех файлов
            List<string> SuitableFiles = new List<string>(); // Массив подходящих файлов
            for (int i = 0; i < Files.Length; i++)
            {
                Files[i] = Files[i]
                    .Substring(Files[i].LastIndexOf("\\")); // Оставляем только название файла и его тип

                DateTime myDate = DateTime.ParseExact(Files[i].Substring(1, Files[i].LastIndexOf(".") - 1),
                    "dd.MM.yyyy",
                    System.Globalization.CultureInfo.InvariantCulture); // Сериализуем название в формат DateTime
                DateTime _After = DateTime.ParseExact(After.ToShortDateString(), "dd.MM.yyyy",
                    System.Globalization.CultureInfo.InvariantCulture); // Сериализуем название в формат DateTime
                DateTime _Before = DateTime.ParseExact(Before.ToShortDateString(), "dd.MM.yyyy",
                    System.Globalization.CultureInfo.InvariantCulture); // Сериализуем название в формат DateTime
                if (_After <= myDate && myDate <= _Before)
                {
                    SuitableFiles.Add(Files[i]);
                }
            }
            return SuitableFiles;
        }

        bool FillInTheListOfIndications(string NameOfFile) // Заполняем лист из конретного файла 
        {
            bool ok = false;
            int count = File.ReadAllLines(IDCounter + NameOfFile).Length;
            StreamReader CurentF = new StreamReader(IDCounter + NameOfFile);
            if (count > 5)
            {
                for (int i = 0; i < count / 5; i++)
                {
                    string Date = CurentF.ReadLine();
                    DateTime myDate = DateTime.ParseExact(Date, "dd.MM.yyyy HH:mm:ss",
                        System.Globalization.CultureInfo.InvariantCulture); // Сериализуем время показания в формат DateTime
                    if (After <= myDate && myDate <= Before)
                    {
                        Times.Add(myDate); // Записываем время 
                        ok = true;
                        double[,] Indicate = new double[3, 3];
                        // m что записываем
                        // n какая фаза
                        for (int m = 0; m < 3; m++) // Записываем показания
                        {
                            string A = CurentF.ReadLine();
                            for (int n = 0; n < 3; n++)
                            {
                                Indicate[m, n] = Double.Parse(A.Substring(0, A.IndexOf(" ")));
                                A = A.Substring(A.IndexOf(" ") + 1);
                            }
                        }
                        Indications.Add(Indicate);
                    }
                    else // Пропускаем показание 
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            CurentF.ReadLine();
                        }
                    }
                    CurentF.ReadLine(); // Двигаемся к следующему показанию
                }
            }
            return ok;
        }
    }
}
