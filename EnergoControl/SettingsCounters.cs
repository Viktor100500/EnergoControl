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
    public partial class SettingsCounters : Form
    {
        private TabControl _Counters;
        private Form F;
        public SettingsCounters() // Конструктор
        {
            InitializeComponent();
        }

        public SettingsCounters(TabControl Counters, Form _F) // Конструктор с счетчиками
        {
            InitializeComponent();
            SetCheckBox(Counters);
            _Counters = Counters;
            F = _F;
        }

        private void SettingsCounters_FormClosed(object sender, FormClosedEventArgs e) // Форма закрывается
        {
            F.Enabled = true;
            F.Show();
        }

        public void SetCheckBox(TabControl Counters)
        {
            for (int i = 0; i < Counters.TabCount - 1; i++)
            {
                checkedListBox.Items.Add(Counters.TabPages[i].Text);
            }
        }

        private void Button_Click(object sender, EventArgs e) // Кнопка удаления
        {
            for (int i = 0; i < checkedListBox.SelectedItems.Count; i++)
            {
                _Counters.TabPages.Remove(_Counters.TabPages[checkedListBox.SelectedIndices[i]]);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
