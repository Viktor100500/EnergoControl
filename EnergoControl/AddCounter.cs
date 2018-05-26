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
    public partial class AddCounter : Form
    {
        private Form ParentF;
        private TabControl Counter;
        public AddCounter(TabControl CounterPage, Form F) 
        {
            InitializeComponent();
            ParentF = F;
            Counter = CounterPage;
        }

        private void Button1_Click(object sender, EventArgs e) // Кнопка добавить счетчик
        {
            if (textBox1.Text != "")
            {
                Counter.TabPages.Add(Counter.TabPages[Counter.TabCount - 1].Text);
                Counter.TabPages[Counter.TabCount - 2].Controls[0].Parent = Counter.TabPages[Counter.TabCount - 1];
                Counter.TabPages[Counter.TabCount - 2].Controls.Clear();
                NewCounter childFrm = new NewCounter(textBox1.Text);
                Counter.TabPages[Counter.TabCount - 2].Text = childFrm.Text;
                childFrm.Parent = Counter.TabPages[Counter.TabCount - 2];
                ParentF.Enabled = true;
                Close();
            }
            else
            {
                MessageBox.Show("Вы не ввели идентификатор устройства", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CancelButt_Click(object sender, EventArgs e) // Кнопка отмены
        {
            Parent.Enabled = true;
            Close();
        }
    }
}
