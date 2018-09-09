using System;
using System.Windows.Forms;
using CreateReport;

namespace EnergoControl
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new CreateReportForm());
        }
    }
}
