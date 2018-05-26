using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.Threading;
using DocumentFormat.OpenXml.Drawing;

namespace EnergoControl
{
    public partial class frmMain : Form
    {
        #region Переменные
        InterrogationСounter _Work; // Рабочий класс опроса
        private bool WorkOn = false; // Флаг работы опроса
        #endregion

        #region Работа кнопок
        private void выходToolStripMenuItem_Click(object sender, EventArgs e) // Кнопка выхода из программы 
        {
            Close();
        }
        private async void toolStripButton1_Click(object sender, EventArgs e)  // Запуск опроса 
        {
            if (LabelPort.Text != "null") // Проверяем что порт установлен
            {
                toolStripLabel3.Text = "Опрос счетчиков включен"; // Меняем флаги
                notifyIcon1.Text = "Контроль электроэнергии[ВКЛ]";
                toolStripLabel3.ForeColor = Color.Green;
                toolStripButton1.Enabled = false;
                toolStripButton2.Enabled = true;
                NewCounter[] ChildF = new NewCounter[CounterPage.TabCount - 1];
                WorkOn = true;
                for (int i = 0; i < CounterPage.TabCount - 1; i++)
                {
                    ChildF[i] = (NewCounter)CounterPage.TabPages[i].Controls[0];
                }
                _Work = new InterrogationСounter(LabelPort.Text);
                await Task.Factory.StartNew(() => _Work.Request(ChildF));
            }
            else
            {
                PortProperties();
                MessageBox.Show("Повторите попытку запуска", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void toolStripButton2_Click(object sender, EventArgs e) // Кнопка стоп 
        {
            toolStripLabel3.Text = "Опрос счетчиков отключен"; // Меняем флаги
            notifyIcon1.Text = "Контроль электроэнергии[ВЫКЛ]";
            toolStripLabel3.ForeColor = Color.Red;
            toolStripButton1.Enabled = true;
            toolStripButton2.Enabled = false;
            _Work.Cancel(); // Отменяем выполнение опроса
            Task.WaitAll(); // Ждем окончания
            WorkOn = false;
        }
        private void toolStripMenuItem1_Click(object sender, EventArgs e) // Добавить новый счетчик 
        {
            if (CounterPage.TabCount - 1 < 10) // ПРОГРАММА НА 10 счетчиков!
            {
                if (WorkOn)
                {
                    toolStripButton2_Click(sender, e); // Останавливаем опрос
                }
                Enabled = false;
                AddCounter D = new AddCounter(CounterPage, this);
                D.Show();
            }
            else
            {
                MessageBox.Show("Количество счетчиков не может превышать 10", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void свернутьВТрейToolStripMenuItem_Click(object sender, EventArgs e) // Кнопка ухода в трей 
        {
            ShowInTaskbar = false;
            notifyIcon1.Visible = true;
            Hide();
        }
        private void notifyIcon1_DoubleClick(object sender, EventArgs e) // Возвращение из трея 
        {
            Show();
            ShowInTaskbar = true;
            notifyIcon1.Visible = false;
        }
        private void настройкиСчетчиковToolStripMenuItem_Click(object sender, EventArgs e) // Открытие настроек счетчика
        {
            if (WorkOn)
            {
                toolStripButton2_Click(sender, e); // Останавливаем опрос
            }
            Enabled = false;
            SettingsCounters Change = new SettingsCounters(CounterPage, this);
            Change.Show();
        }
        #endregion

        #region Счетчики Инкаба

        private void frmMain_Load(object sender, EventArgs e) // Загрузка тестовых счетчиков 
        {
            CountersInkab();
        }

        void CountersInkab() // Заготовка форм счетчиков для Инкаба 
        {
            //AddNewCounter(new NewCounter("1"));
            //AddNewCounter(new NewCounter("2"));
            //AddNewCounter(new NewCounter("3"));
            //AddNewCounter(new NewCounter("4"));
            //AddNewCounter(new NewCounter("5"));
            //AddNewCounter(new NewCounter("6"));
            //AddNewCounter(new NewCounter("7"));
            //AddNewCounter(new NewCounter("8"));
            //AddNewCounter(new NewCounter("9"));
            //AddNewCounter(new NewCounter("10"));
            AddNewCounter(new AmountCounter());
        }

        #endregion

        #region Работа с портом

        public void PortProperties() // Установка надписи о текущем порте 
        {
            try
            {
                LabelPort.Text = SerialPort.GetPortNames()[0];
            }
            catch
            {
                MessageBox.Show("Не найдено подходящих портов", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void PortPropertiesWithoutMessage() // Установка надписи о текущем порте 
        {
            try
            {
                LabelPort.Text = SerialPort.GetPortNames()[0];
                for (int i = 0; i < SerialPort.GetPortNames().Length; i++)
                {
                    LabelPort.Items.Add(SerialPort.GetPortNames()[i]);
                }
            }
            catch
            {
            }
        }

        #endregion

        #region Работа формы

        public frmMain() // Конструктор 
        {
            InitializeComponent();
            PortPropertiesWithoutMessage();
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e) // Когда форма закрывается 
        {
            if (WorkOn)
            {
                Task.WaitAll();
            }
        }

        #endregion

        #region Работа вкладок

        void AddNewCounter(NewCounter childFrm) // Добавление счетчика на вкладку 
        {
            CounterPage.TabPages.Add(childFrm.Text);
            childFrm.Parent = CounterPage.TabPages[CounterPage.TabCount - 1];
        }

        void AddNewCounter(AmountCounter childFrm) // Добавление суммарного на вкладку 
        {
            CounterPage.TabPages.Add(childFrm.Text);
            childFrm.Parent = CounterPage.TabPages[CounterPage.TabCount - 1];
        }

        #endregion
    }
}
