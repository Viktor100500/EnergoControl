using System;
using System.Drawing;
using System.Windows.Forms;

namespace EnergoControl
{
    public partial class SelectCounters : Form
    {
        private bool[] Selected = new bool[10]; // Массив маркеров выбранных счетчиков 

        private TabControl _Counters; // Вкладки со счетчиками

        public SelectCounters(TabControl Counters) // Конструктор 
        {
            InitializeComponent();
            _Counters = Counters;
            for (int i = 1; i < Counters.TabCount; i++) // Подгружаем уже опрашиваемые счетчики
            {
                button1_Click(Controls["B" + _Counters.TabPages[i].Name], EventArgs.Empty);
            }
        }

        private void button1_Click(object sender, EventArgs e) // Обработка нажатия кнопки счетчика 
        {
            Button Current = (Button) sender;
            if (Current.BackColor == SystemColors.Control)
            {
                Current.BackColor = Color.PaleGreen;
                Selected[Int16.Parse(Current.Name.Substring(1)) - 1] = true;
            }
            else
            {
                Current.BackColor = SystemColors.Control;
                Selected[Int16.Parse(Current.Name.Substring(1)) - 1] = false;
            }
        }

        private void Ok_Click(object sender, EventArgs e) // Сохраняем состояние 
        {
            for (int i = 0; i < 10; i++)
            {
                if (Selected[i])
                {
                    if (!CheckAvailability(i+1))
                    {
                        NewCounter childFrm = new NewCounter((i+1).ToString(), ((frmMain) Owner).GetTextBoxWithAccident());
                        _Counters.TabPages.Add(childFrm.Name, childFrm.Text);
                        childFrm.Parent = _Counters.TabPages[_Counters.TabCount - 1];
                    }
                }
                else
                {
                    if (CheckAvailability(i + 1))
                    {
                        _Counters.TabPages.RemoveByKey((i+1).ToString());
                    }
                }
            }
            Close();
        }

        public bool CheckAvailability(int i) // Проверяет, есть ли уже такой счетчик в опросе 
        {
            for (int j = 1; j < _Counters.TabCount; j++) // Подгружаем уже опрашиваемые счетчики
            {
                if (_Counters.TabPages[j].Name == i.ToString())
                {
                    return true;
                }
            }
            return false;
        }

        private void SelectCounters_FormClosing(object sender, FormClosingEventArgs e) // Обработка закрытия окна 
        {
            Owner.Enabled = true;
        }
    }
}
