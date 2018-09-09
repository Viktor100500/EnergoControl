using System;
using System.IO;
using System.Windows.Forms;

namespace EnergoControl
{
    // Класс для проверки лицензии продукта

    class License
    {
        // Переменная хранящая путь до файла с системными настройками 
        string Way = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Энергоконтроль\\Settings.dat";
        string WayDays = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Энергоконтроль\\SettingsBackUp.dat";
        public License() // Конструктор 
        {

        }

        public bool CheckExistSettingsDat() // Первая проверка существования файла 
        {
            if (File.Exists(Way))
            {
                DateTime DateLicense;
                FileStream fs = new FileStream(Way, FileMode.Open);
                BinaryReader br = new BinaryReader(fs);
                DateLicense = DateTime.FromBinary(br.ReadInt64());
                if (DateTime.Now >= DateLicense)
                {
                    int DT = (DateTime.Now - DateLicense).Days;
                    int DaysLeft = TakeDays() - DT;
                    if (DaysLeft > 0)
                    {
                        br.Close();
                        fs.Close();
                        fs = new FileStream(Way, FileMode.Create);
                        BinaryWriter bW = new BinaryWriter(fs);
                        bW.Write(DateTime.Now.ToBinary());
                        br.Close();
                        fs.Close();
                        fs = new FileStream(WayDays, FileMode.Create);
                        bW = new BinaryWriter(fs);
                        bW.Write(DaysLeft);
                        br.Close();
                        fs.Close();
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Срок активации вышел, пожалуйста, приобретите полную версию");
                        return false;
                    }
                }
                else
                {
                    MessageBox.Show("На компьютере изменена дата");
                    return false;
                }
            }
            else { MessageBox.Show("Программа не активирована"); return false;}
        }

        public int TakeDays() // Проверка дней 
        {
            FileStream fs = new FileStream(WayDays, FileMode.Open);
            BinaryReader br = new BinaryReader(fs);
            int ret = br.ReadInt32(); ;
            br.Close();
            fs.Close();
            return ret;
        }
    }
}
