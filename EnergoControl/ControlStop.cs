using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EnergoControl
{
    // Форма для обработки пароля при нажатии кнопки СТОП
    public partial class ControlStop : Form
    {
        private string Password = "2222"; // Константа пароль
        public ControlStop() // Конструктор 
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) // Нажатие кнопки OK 
        {
            if (PasswordBox.Text == Password)
            {
                this.DialogResult = DialogResult.OK;
            }
            else WrongPassword.Visible = true;
        }

        private void PasswordBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            WrongPassword.Visible = false;
        }
    }
}
