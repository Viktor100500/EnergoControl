using System;
using System.Windows.Forms;

namespace EnergoControl
{
    static class Program
    {
        // Власов Виктор 
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
                if (System.Diagnostics.Process.GetProcessesByName(Application.ProductName).Length > 1)
                {
                    MessageBox.Show("Приложение уже запущено");
                }
                else
                {
                    License Check = new License();
                    if (Check.CheckExistSettingsDat())
                    {
                        Application.EnableVisualStyles();
                        Application.SetCompatibleTextRenderingDefault(false);
                        Application.Run(new frmMain());
                    }
                }
        }
    }
}
