using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace EnergoControl
{
    public delegate void DelegateWriteCurAndVol(string A, int B); // Делегат записи результатов
    public delegate void DelegateWriteException(); // Делегат записи ошибки

    public partial class NewCounter : Form
    {
        Label[,] CurAndVol = new Label[2, 3]; // Установка надписей для таблицы текущих токов и напряжений на каждой фазе
        Label[,] MaxAndMin = new Label[3, 4]; // Установка надписей для таблиц максимальных и минимальных значений тока и напряжения для каждой фазы

        public NewCounter() // Создание формы для счетчика 
        {
            InitializeComponent();
            SetLabels();
        }

        public NewCounter(string NameC) // Создание формы для счетчика 
        {
            InitializeComponent();
            Text = "Счетчик " + NameC;
            Name = NameC;
            TopLevel = false;
            Dock = DockStyle.Fill;
            Show();
            SetLabels();
        }

        public void SetLabels() // Создание масссива надписей на форме 
        {
            CurAndVol[0, 0] = ACurrent;
            CurAndVol[0, 1] = BCurrent;
            CurAndVol[0, 2] = CCurrent;
            CurAndVol[1, 0] = AVoltage;
            CurAndVol[1, 1] = BVoltage;
            CurAndVol[1, 2] = CVoltage;

            MaxAndMin[0, 0] = AMaxCurrent;
            MaxAndMin[0, 1] = AMinCurrent;
            MaxAndMin[0, 2] = AMaxVoltage;
            MaxAndMin[0, 3] = AMinVoltage;

            MaxAndMin[1, 0] = CMaxCurrent;
            MaxAndMin[1, 1] = CMinCurrent;
            MaxAndMin[1, 2] = CMaxVoltage;
            MaxAndMin[1, 3] = CMinVoltage;

            MaxAndMin[2, 0] = BMaxCurrent;
            MaxAndMin[2, 1] = BMinCurrent;
            MaxAndMin[2, 2] = BMaxVoltage;
            MaxAndMin[2, 3] = BMinVoltage;

        }

        public Label[,] GetLabelCurAndVol() // Доступ к массиву класса 
        {
            return CurAndVol;
        }

        public void WriteVoltageorCurrent(string WhatParse, int CurrentIndex) // Фукнций записи текущих показаний напряжения и тока 
        {
            try
            {
                WhatParse = WhatParse.Replace('.', ',');
                int start = WhatParse.IndexOf('(') + 1;
                int end = WhatParse.IndexOf(')');
                for (int j = 0; j < 3; j++)
                {
                    CurAndVol[CurrentIndex, j].Text = WhatParse.Substring(start, end - start);
                    WhatParse = WhatParse.Substring(end + 1);
                    start = WhatParse.IndexOf('(') + 1;
                    end = WhatParse.IndexOf(')');
                }


                if (CurrentIndex == 1) // Заполняем график мощности
                {
                    try
                    {
                        ChartPower.Series["Фаза А"].Points.AddXY(DateTime.Now, Double.Parse(ACurrent.Text) * Double.Parse(AVoltage.Text));
                        ChartPower.Series["Фаза B"].Points.AddXY(DateTime.Now, Double.Parse(BCurrent.Text) * Double.Parse(BVoltage.Text));
                        ChartPower.Series["Фаза С"].Points.AddXY(DateTime.Now, Double.Parse(CCurrent.Text) * Double.Parse(CVoltage.Text));
                        if (!MaxAndMin[0, 0].Visible) { VisibleMaxMin(); }
                        WriteNewMaxAndMin(Double.Parse(ACurrent.Text), Double.Parse(AVoltage.Text), 0);
                        WriteNewMaxAndMin(Double.Parse(BCurrent.Text), Double.Parse(BVoltage.Text), 1);
                        WriteNewMaxAndMin(Double.Parse(CCurrent.Text), Double.Parse(CVoltage.Text), 2);
                    }
                    catch
                    {
                        WriteException();
                    }
                }
            }
            catch
            {
                WriteException();
            }
        }

        public void WriteException() // Заполнение лога ошибкой 
        {
            LogBox.Text += "Неудачный опрос " + DateTime.Now + Environment.NewLine;
        }

        public void WriteGoodEnd() // Заполнение лога удачей 
        {
            LogBox.Text += "Удачный опрос " + DateTime.Now + Environment.NewLine;
        }

        public void WriteNewMaxAndMin(Double Current, Double Voltage, int i) // Устновка максимальных и минимальных значений 
        {
            //MaxAndMin[i, 0] = AMaxCurrent;
            //MaxAndMin[i, 1] = AMinCurrent;
            //MaxAndMin[i, 2] = AMaxVoltage;
            //MaxAndMin[i, 3] = AMinVoltage;
            if (Double.Parse(MaxAndMin[i, 0].Text) < Current)
            {
                MaxAndMin[i, 0].Text = Current.ToString();
            }
            if (Double.Parse(MaxAndMin[i, 1].Text) > Current)
            {
                MaxAndMin[i, 1].Text = Current.ToString();
            }
            if (Double.Parse(MaxAndMin[i, 2].Text) < Voltage)
            {
                MaxAndMin[i, 2].Text = Voltage.ToString();
            }
            if (Double.Parse(MaxAndMin[i, 3].Text) > Voltage)
            {
                MaxAndMin[i, 3].Text = Voltage.ToString();
            }
        }

        public void VisibleMaxMin() // Появление максимальных и минимальных значений 
        {
            MaxAndMin[0, 0].Visible = true;
            MaxAndMin[0, 1].Visible = true;
            MaxAndMin[0, 2].Visible = true;
            MaxAndMin[0, 3].Visible = true;

            MaxAndMin[1, 0].Visible = true;
            MaxAndMin[1, 1].Visible = true;
            MaxAndMin[1, 2].Visible = true;
            MaxAndMin[1, 3].Visible = true;

            MaxAndMin[2, 0].Visible = true;
            MaxAndMin[2, 1].Visible = true;
            MaxAndMin[2, 2].Visible = true;
            MaxAndMin[2, 3].Visible = true;
        }
    }
}
