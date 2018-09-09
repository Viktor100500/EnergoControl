using System;
using System.Diagnostics;
using System.IO.Ports;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Color = System.Drawing.Color;

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

        private async void toolStripButton1_Click(object sender, EventArgs e)  // ЗАПУСК ОПРОСА 
        {
            if (LabelPort.Text != "null") // Проверяем что порт установлен
            {
                if (CounterPage.TabCount != 1)
                {
                    toolStripLabel3.Text = "Опрос счетчиков включен"; // Меняем флаги
                    notifyIcon1.Text = "Контроль электроэнергии[ВКЛ]";
                    toolStripLabel3.ForeColor = Color.Green;
                    toolStripButton1.Enabled = false;
                    toolStripButton2.Enabled = true;
                    NewCounter[] ChildF = new NewCounter[CounterPage.TabCount - 1];
                    WorkOn = true; // Меняем флаг работы опроса
                    for (int i = 1; i < CounterPage.TabCount; i++)
                    {
                        ChildF[i-1] = (NewCounter)CounterPage.TabPages[i].Controls[0];
                    }

                    _Work = new InterrogationСounter(LabelPort.Text);
                    await Task.Factory.StartNew(() => _Work.Request(ChildF,
                        (AmountCounter)CounterPage.TabPages[0].Controls[0]));
                }
                else
                {
                    MessageBox.Show("Нет счетчиков в очереди на опрос", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                PortProperties();
                MessageBox.Show("Повторите попытку запуска, установлен не подходящий порт", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e) // Кнопка стоп 
        {
            toolStripLabel3.Text = "Опрос счетчиков отключен"; // Меняем флаги
            notifyIcon1.Text = "Контроль электроэнергии[ВЫКЛ]";
            toolStripLabel3.ForeColor = Color.Red;
            toolStripButton2.Enabled = false;
            Thread.Sleep(600);
            toolStripButton1.Enabled = true;
            _Work.Cancel(); // Отменяем выполнение опроса
            Task.WaitAll(); // Ждем окончания
            WorkOn = false; // Меняем флаг работы опроса
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e) // Выбрать счетчики для опроса 
        {
            if (WorkOn)
            {
                toolStripButton2_Click(sender, e); // Останавливаем опрос
            }
            Enabled = false;
            SelectCounters Select = new SelectCounters(CounterPage);
            Select.Owner = this;
            Select.Show();
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

        private void ClearAccident_Click(object sender, EventArgs e) // Очистить Аварии 
        {
            TextBoxAccident.Clear();
        }

        private void создатьToolStripMenuItem_Click(object sender, EventArgs e) // Открыть генератор отчетов 
        {
            try
            {
                Process.Start("CreateReport.exe");
            }
            catch { }

        }

        #endregion

        #region Счетчики Инкаба

        private void frmMain_Load(object sender, EventArgs e) // Загрузка тестовых счетчиков 
        {
            CountersInkab();
        }

        void CountersInkab() // Заготовка форм счетчиков для Инкаба 
        {
            AddNewCounter(new AmountCounter()); // Суммирующий график мощностей
            AddNewCounter(new NewCounter("1", TextBoxAccident));
            AddNewCounter(new NewCounter("2", TextBoxAccident));
            AddNewCounter(new NewCounter("3", TextBoxAccident));
            AddNewCounter(new NewCounter("4", TextBoxAccident));
            AddNewCounter(new NewCounter("5", TextBoxAccident));
            AddNewCounter(new NewCounter("6", TextBoxAccident));
            AddNewCounter(new NewCounter("7", TextBoxAccident));
            AddNewCounter(new NewCounter("8", TextBoxAccident));
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

        public TextBox GetTextBoxWithAccident() // Возвращает текст бокс с авариями 
        {
            return TextBoxAccident;
        }

        #endregion

        #region Работа вкладок

        void AddNewCounter(NewCounter childFrm) // Добавление счетчика на вкладку 
        {
            CounterPage.TabPages.Add(childFrm.Name, childFrm.Text);
            childFrm.Parent = CounterPage.TabPages[CounterPage.TabCount - 1];
        }

        void AddNewCounter(AmountCounter childFrm) // Добавление суммарного на вкладку 
        {
            CounterPage.TabPages.Add(childFrm.Text);
            childFrm.Parent = CounterPage.TabPages[0];
        }

        #endregion

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Task.Run(() =>
            {
                var dialogResult = MessageBox.Show("\"Энергоконтроль\", Версия 1.3 - 04.09.2018; ООО \"Энергоучет\", energouchet_uk@mail.ru", "О программе", MessageBoxButtons.OK);
            });
        }
    }
}
