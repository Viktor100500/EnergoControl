using System;
using System.IO;

namespace EnergoControl
{
    // Класс для работы сохранения последнего порта 
    static public class SaveLatestPort
    {
        static string Way = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Энергоконтроль\\LastPort.stg"; // Путь до файла с портом 

        public static string Read() // Прочитать порт из файла 
        {
            return File.ReadAllText(Way);
        }

        public static void Save(string Port) // Записать порт в файл 
        {
            File.WriteAllText(Way, Port);
        }

        public static bool Check() // Проверка на существования файла и порта в нем 
        {
            if (File.Exists(Way))
            {
                if (File.ReadAllText(Way).Length != 0) return true;
            }
            return false;
        }
    }
}
