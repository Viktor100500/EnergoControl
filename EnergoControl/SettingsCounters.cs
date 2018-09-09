using System;
using System.Windows.Forms;

namespace EnergoControl
{
    public partial class SettingsCounters : Form
    {
        private TabControl _Counters; // Переменные
        private Form F;
        private NewCounter Chouse;

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
            checkedListBox.Items.Clear();
            for (int i = 1; i < Counters.TabCount; i++)
            {
                checkedListBox.Items.Add(Counters.TabPages[i].Text);
            }
        }

        private void Button_Click(object sender, EventArgs e) // Кнопка удаления 
        {
            for (int i = checkedListBox.CheckedItems.Count - 1; i >=0; i--)
            {
                _Counters.TabPages.Remove(_Counters.TabPages[checkedListBox.CheckedIndices[i]+1]);
            }
            SetCheckBox(_Counters);
        }

        private void button2_Click(object sender, EventArgs e) // Кнопка ОК 
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e) // Кнопка применить 
        {
            if (checkedListBox.CheckedItems.Count != 0)
            {
                try
                {
                    for (int i = 0; i < checkedListBox.CheckedItems.Count; i++)
                    {
                        Chouse = (NewCounter) _Counters.TabPages[checkedListBox.CheckedIndices[i]+1].Controls[0];
                        Chouse.SetSetiings(Double.Parse(textBox1.Text), Double.Parse(textBox2.Text));
                    }
                }
                catch
                {
                    MessageBox.Show("Проверьте корректность введенных чисел", "Ошибка", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Выберите хотя бы один счетчик", "Ошибка", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}
