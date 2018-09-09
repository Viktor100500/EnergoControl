using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Activator
{
    public partial class Form1 : Form
    {
        private const int Days = 30; // Количество дней
        // WDEFnefjD212312DNEJjrff3
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string Way = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Энергоконтроль";
            // Delete the file if it exists.
            if (File.Exists(Way))
            {
                // Note that no lock is put on the
                // file and the possibility exists
                // that another process could do
                // something with it between
                // the calls to Exists and Delete.
                File.Delete(Way);
            }

            Directory.CreateDirectory(Way);
            Way += "\\Settings.dat";
            FileStream fs = new FileStream(Way,FileMode.Create);
            BinaryWriter WriteDate = new BinaryWriter(fs);
            WriteDate.Write(DateTime.Now.ToBinary());
            WriteDate.Close();
            fs.Close();
            Way = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Энергоконтроль";
            // Delete the file if it exists.
            if (File.Exists(Way))
            {
                // Note that no lock is put on the
                // file and the possibility exists
                // that another process could do
                // something with it between
                // the calls to Exists and Delete.
                File.Delete(Way);
            }

            Directory.CreateDirectory(Way);
            Way += "\\SettingsBackUp.dat";
            fs = new FileStream(Way, FileMode.Create);
            WriteDate = new BinaryWriter(fs);
            WriteDate.Write(Days);
            WriteDate.Close();
            fs.Close();
        }
    }
}
