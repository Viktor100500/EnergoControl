using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace CreateReport
{
    public partial class CreateReportForm : Form
    {
        private bool[] SelectedCounters = new bool[10]; // Массив флагов выбора счетчиков
        private bool[] SelectedData = new bool[4]; // Массив флагов выбора данных

        public CreateReportForm() // Конструктор 
        {
            InitializeComponent();
            FillArrays();
        }

        private void ButtonWork_Click(object sender, EventArgs e) // Обрабатываем нажатие на кнопку счетчика 
        {
            ToolStripButton Current = (ToolStripButton) sender;
            if (Current.BackColor == SystemColors.Control)
            {
                Current.BackColor = Color.PaleGreen;
                SelectedCounters[Int16.Parse(Current.Name.Substring(1)) - 1] = true;
            }
            else
            {
                Current.BackColor = SystemColors.Control;
                SelectedCounters[Int16.Parse(Current.Name.Substring(1)) - 1] = false;
            }
        }

        private void DataSelected_Click(object sender, EventArgs e) // Обрабатываем нажатие на информационные кнопки 
        {
            ToolStripButton Current = (ToolStripButton) sender;
            if (Current.BackColor == SystemColors.Control)
            {
                SelectedData[Int16.Parse(Current.Name.Substring(1)) - 1] = true;
                Current.BackColor = Color.PaleGreen;
            }
            else
            {
                SelectedData[Int16.Parse(Current.Name.Substring(1)) - 1] = false;
                Current.BackColor = SystemColors.Control;
            }
        }

        private void button1_Click(object sender, EventArgs e) // Кнопка СОЗДАТЬ 
        {
            if (ArrayCountersTrue().Count != 0 && ArrayDataTrue().Count != 0)
            {
                if (TimePickerAfter.Value < TimePickerBefore.Value)
                {
                    WorkWithExcel Work = new WorkWithExcel(TimePickerAfter.Value, TimePickerBefore.Value,
                        ArrayCountersTrue(), SelectedData);
                    Work.CreateExcelFile();
                }
                else
                {
                    MessageBox.Show("Вы неправильно выбрали период", "Внимание!",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Вы не выбрали счетчики или информацию, которую необходимо вывести в отчете", "Внимание!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private List<int>
            ArrayCountersTrue() // Метод для предоставления информации о выбранных пользователем счетчиков 
        {
            List<int> ArrayTrue = new List<int>();
            for (int i = 0; i < SelectedCounters.Length; i++)
            {
                if (SelectedCounters[i])
                {
                    ArrayTrue.Add(i + 1);
                }
            }

            return ArrayTrue;
        }

        private List<int> ArrayDataTrue() // Метод для предоставленияо выбранной пользователем информации 
        {
            List<int> ArrayTrue = new List<int>();
            for (int i = 0; i < SelectedData.Length; i++)
            {
                if (SelectedData[i])
                {
                    ArrayTrue.Add(i + 1);
                }
            }

            return ArrayTrue;
        }

        void FillArrays() // Заполняем массивы true или false 
        {
            for (int i = 0; i < 10; i++)
            {
                SelectedCounters[i] = false;
            }

            for (int i = 0; i < 4; i++)
            {
                SelectedData[i] = true;
            }
        }
    }
}
