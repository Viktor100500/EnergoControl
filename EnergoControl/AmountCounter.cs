using System;
using System.Windows.Forms;

namespace EnergoControl
{
    public delegate void DelegateWriteSummary(double[] A); // Делегат для многопоточной записи значений на форму
    public partial class AmountCounter : Form
    {
        private const int MaxPoint = 150; // Ограничение количества хранимых значений
        public AmountCounter()
        {
            InitializeComponent();
            Text = "Суммарно";
            TopLevel = false;
            Dock = DockStyle.Fill;
            Show();
        }

        void SetPoint(double[] WhatWrite) // Добавление точек на график 
        {
            ChartPower.Series["Полная мощность"].Points.AddXY(DateTime.Now, WhatWrite[0]);
            ChartPower.Series["Активная мощность"].Points.AddXY(DateTime.Now, WhatWrite[1]);
        }

        void SetPointWithDel(double[] WhatWrite) // Добавление точек на график с удалением 
        {
            ChartPower.Series["Полная мощность"].Points.RemoveAt(0);
            ChartPower.Series["Полная мощность"].Points.AddXY(DateTime.Now, WhatWrite[0]);
            ChartPower.Series["Активная мощность"].Points.RemoveAt(0);
            ChartPower.Series["Активная мощность"].Points.AddXY(DateTime.Now, WhatWrite[1]);
            ChartPower.ResetAutoValues();
        }

        public void ChooseTypeWrite(double[] A) // Делегат
        {
            FullPowerValue.Visible = true;
            ActivePowerValue.Visible = true;
            Time.Visible = true;
            FullPowerValue.Text = (A[0] / 1000.00).ToString("#.#");
            ActivePowerValue.Text = (A[1] / 1000.00).ToString("#.#");
            Time.Text = DateTime.Now.ToShortTimeString();
            if (ChartPower.Series[0].Points.Count < MaxPoint)
            {
                SetPoint(A);
            }
            else
            {
                SetPointWithDel(A);
            }
        }

        private void ClearAccident_Click(object sender, EventArgs e) // Кнопка отчистить
        {
            ChartPower.Series["Полная мощность"].Points.Clear();
            ChartPower.Series["Активная мощность"].Points.Clear();
        }
    }
}
