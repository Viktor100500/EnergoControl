using System;
using System.Windows.Forms;

namespace EnergoControl
{
    public delegate void DelegateWriteCurAndVol(double[,] WhatWrite, int Index); // Делегат для многопоточной записи значений на форму
    public delegate void DelegateWriteException(); // Делегат для многопоточной записи значений на форму

    public partial class NewCounter : Form
    {
        private const int MaxPoint = 150; // Ограничение количества хранимых значений
        private TextBox Accident;

        public double[] SettingAccident { get; set; } // Свойство

        public NewCounter() // Конструктор создания формы для счетчика 
        {
            InitializeComponent();
        }

        public NewCounter(string NameC, TextBox A) // Конструктор создания формы для счетчика с именем 
        {
            InitializeComponent();
            Text = "Счетчик " + NameC;
            Name = NameC;
            TopLevel = false;
            Dock = DockStyle.Fill;
            Show();

            SettingAccident = new double[2]; // Установка настроек сообщений об авриях
            SettingAccident[0] = 207; // Минимальное значение
            SettingAccident[1] = 253; // Максимальное значение
            Accident = A; // Передаем текст бокс с авариями
        }

        public void SetSetiings(double Min, double Max) // Установка настроек аварий 
        {
            SettingAccident[1] = Min;
            SettingAccident[0] = Max;
        }

        public void WriteIndications(double[,] WhatWrite, int CurOrVolOrCos) // Функция заполнения показателей 
        {
            switch (CurOrVolOrCos)
            {
                case 0:
                    ACurrent.Text = WhatWrite[0, 0].ToString();
                    BCurrent.Text = WhatWrite[0, 1].ToString();
                    CCurrent.Text = WhatWrite[0, 2].ToString();
                    break;
                case 1:
                    AVoltage.Text = WhatWrite[1, 0].ToString();
                    BVoltage.Text = WhatWrite[1, 1].ToString();
                    CVoltage.Text = WhatWrite[1, 2].ToString();
                    CheckAccident(WhatWrite); // Проверяем аварии
                    break;
                case 2:
                    if (ChartPower.Series[0].Points.Count > MaxPoint) // Проверяем требуется ли удалять точки в графике и сообщения в textbox
                    {
                        SetPointWithDel(WhatWrite);
                    }
                    else
                    {
                        SetPoint(WhatWrite);
                    }

                    if (AMaxCurrent.Visible == false) { VisibleMaxMin(); }
                    WriteNewMaxAndMin(WhatWrite, 0);
                    WriteNewMaxAndMin(WhatWrite, 1);
                    WriteNewMaxAndMin(WhatWrite, 2);
                    break;
            }
        }

        void VisibleMaxMin() // Видимость максимальных и минимальных значений 
        {
            AMaxCurrent.Visible = true;
            AMinCurrent.Visible = true;
            AMaxVoltage.Visible = true;
            AMinVoltage.Visible = true;

            BMaxCurrent.Visible = true;
            BMinCurrent.Visible = true;
            BMaxVoltage.Visible = true;
            BMinVoltage.Visible = true;

            CMaxCurrent.Visible = true;
            CMinCurrent.Visible = true;
            CMaxVoltage.Visible = true;
            CMinVoltage.Visible = true;
        }

        public void WriteException() // Заполнение лога ошибкой 
        {
            LogBox.Text += "Неудачный опрос " + DateTime.Now + Environment.NewLine;
            LogBox.ScrollToCaret();
        }

        void WriteNewMaxAndMin(double[,] Indications, int i) // Устновка максимальных и минимальных значений 
        {
            switch (i)
            {
                case 0: // Сравнение фазы А
                    if (Indications[0, 0] < Double.Parse(AMinCurrent.Text))
                    {
                        AMinCurrent.Text = Indications[0, 0].ToString();
                    }
                    if (Indications[0, 0] > Double.Parse(AMaxCurrent.Text))
                    {
                        AMaxCurrent.Text = Indications[0, 0].ToString();
                    }
                    if (Indications[1, 0] < Double.Parse(AMinVoltage.Text))
                    {
                        AMinVoltage.Text = Indications[1, 0].ToString();
                    }
                    if (Indications[1, 0] > Double.Parse(AMaxVoltage.Text))
                    {
                        AMaxVoltage.Text = Indications[1, 0].ToString();
                    }
                    break;
                case 1: // Сравнение фазы B
                    if (Indications[0, 1] < Double.Parse(BMinCurrent.Text))
                    {
                        BMinCurrent.Text = Indications[0, 1].ToString();
                    }
                    if (Indications[0, 1] > Double.Parse(BMaxCurrent.Text))
                    {
                        BMaxCurrent.Text = Indications[0, 1].ToString();
                    }
                    if (Indications[1, 1] < Double.Parse(BMinVoltage.Text))
                    {
                        BMinVoltage.Text = Indications[1, 1].ToString();
                    }
                    if (Indications[1, 1] > Double.Parse(BMaxVoltage.Text))
                    {
                        BMaxVoltage.Text = Indications[1, 1].ToString();
                    }
                    break;
                case 2: // Сравнение фазы C
                    if (Indications[0, 2] < Double.Parse(CMinCurrent.Text))
                    {
                        CMinCurrent.Text = Indications[0, 2].ToString();
                    }
                    if (Indications[0, 2] > Double.Parse(CMaxCurrent.Text))
                    {
                        CMaxCurrent.Text = Indications[0, 2].ToString();
                    }
                    if (Indications[1, 2] < Double.Parse(CMinVoltage.Text))
                    {
                        CMinVoltage.Text = Indications[1, 2].ToString();
                    }
                    if (Indications[1, 2] > Double.Parse(CMaxVoltage.Text))
                    {
                        CMaxVoltage.Text = Indications[1, 2].ToString();
                    }
                    break;
            }
        }

        void SetPoint(double[,] WhatWrite) // Добавление точек на график 
        {
            LogBox.Text += DateTime.Now + " Удачный опрос " + Environment.NewLine;
            ChartPower.Series["Фаза А"].Points.AddXY(DateTime.Now, WhatWrite[0, 0] * WhatWrite[1, 0] * WhatWrite[2, 0]);
            ChartPower.Series["Фаза B"].Points.AddXY(DateTime.Now, WhatWrite[0, 1] * WhatWrite[1, 1] * WhatWrite[2, 1]);
            ChartPower.Series["Фаза С"].Points.AddXY(DateTime.Now, WhatWrite[0, 2] * WhatWrite[1, 2] * WhatWrite[2, 2]);
            LogBox.ScrollToCaret();
        }

        void SetPointWithDel(double[,] WhatWrite) // Добавление точек на график с удалением 
        {
            LogBox.Lines[0].Remove(0);
            LogBox.Text += DateTime.Now + " Удачный опрос " + Environment.NewLine;
            ChartPower.Series["Фаза А"].Points.RemoveAt(0);
            ChartPower.Series["Фаза А"].Points.AddXY(DateTime.Now, WhatWrite[0, 0] * WhatWrite[1, 0] * WhatWrite[2, 0]);
            ChartPower.Series["Фаза B"].Points.RemoveAt(0);
            ChartPower.Series["Фаза B"].Points.AddXY(DateTime.Now, WhatWrite[0, 1] * WhatWrite[1, 1] * WhatWrite[2, 1]);
            ChartPower.Series["Фаза С"].Points.RemoveAt(0);
            ChartPower.Series["Фаза С"].Points.AddXY(DateTime.Now, WhatWrite[0, 2] * WhatWrite[1, 2] * WhatWrite[2, 2]);
            ChartPower.ResetAutoValues();
            LogBox.ScrollToCaret();
        }

        void CheckAccident(double[,] WhatWrite) // Проверка напряжения на аварии 
        {
            if (WhatWrite[1, 0] < SettingAccident[0] || WhatWrite[1, 0] > SettingAccident[1])
            {
                Accident.Text += DateTime.Now + Environment.NewLine + Text + " напряжение на фазе А = " + WhatWrite[1, 0] + Environment.NewLine + Environment.NewLine;
            }
            if (WhatWrite[1, 1] < SettingAccident[0] || WhatWrite[1, 1] > SettingAccident[1])
            {
                Accident.Text += DateTime.Now + Environment.NewLine + Text + " напряжение на фазе B = " + WhatWrite[1, 1] + Environment.NewLine + Environment.NewLine;
            }
            if (WhatWrite[1, 2] < SettingAccident[0] || WhatWrite[1, 2] > SettingAccident[1])
            {
                Accident.Text += DateTime.Now + Environment.NewLine + Text + " напряжение на фазе C = " + WhatWrite[1, 2] + Environment.NewLine + Environment.NewLine;
            }
        }
    }
}
