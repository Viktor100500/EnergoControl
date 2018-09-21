using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.Ports;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using EnergoControl.Properties;
using Color = System.Drawing.Color;

namespace EnergoControl
{
    public partial class frmMain : Form
    {
        #region Переменные

        InterrogationСounter _Work; // Рабочий класс опроса
        private bool WorkOn = false; // Флаг работы опроса
        CancellationTokenSource _tokenSource;
        List<Task> tasks = new List<Task>();

        #endregion

        #region Работа кнопок

        private void выходToolStripMenuItem_Click(object sender, EventArgs e) // Кнопка выхода из программы 
        {
            Close();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)  // ЗАПУСК ОПРОСА 
        {
            if (LabelPort.Text != "null") // Проверяем что порт установлен
            {
                if (CounterPage.TabCount != 1)
                {
                    WorkOn = true; // Меняем флаг работы опроса
                    SaveLatestPort.Save(LabelPort.Text); // Сохраняем порт в файл 
                    WriteGoodWork();
                    toolStripButton1.Enabled = false;
                    toolStripButton2.Enabled = true;
                    LabelPort.Enabled = false;
                    NewCounter[] ChildF = new NewCounter[CounterPage.TabCount - 1];
                    for (int i = 1; i < CounterPage.TabCount; i++)
                    {
                        ChildF[i - 1] = (NewCounter)CounterPage.TabPages[i].Controls[0];
                    }

                    _Work = new InterrogationСounter(LabelPort.Text);
                    tasks.Add(Task.Factory.StartNew(() => _Work.Request(ChildF,
                        (AmountCounter)CounterPage.TabPages[0].Controls[0])));
                }
                else
                {
                    MessageBox.Show("Нет счетчиков в очереди на опрос", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                PortProperties();
                MessageBox.Show("Проверьте подключение кабеля и соответствие наименования выбранного порта, повторите попытку запуска", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e) // Кнопка СТОП 
        {
            InputPassword();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e) // Выбрать счетчики для опроса 
        {
            SelectCounters Select;
            if (WorkOn)
            {
                if (InputPassword())
                {
                    Enabled = false;
                    Select = new SelectCounters(CounterPage);
                    Select.Owner = this;
                    Select.Show();
                }
                else
                {
                    return;
                }
            }
            else
            {
                Enabled = false;
                Select = new SelectCounters(CounterPage);
                Select.Owner = this;
                Select.Show();
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
            SettingsCounters Change;
            if (WorkOn)
            {
                if (InputPassword())
                {
                    Enabled = false;
                    Change = new SettingsCounters(CounterPage, this);
                    Change.Show();
                }
                else return;
            }
            else
            {
                Enabled = false;
                Change = new SettingsCounters(CounterPage, this);
                Change.Show();
            }
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

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Task.Run(() =>
            {
                var dialogResult = MessageBox.Show("\"Энергоконтроль\", Версия 1.4 - 13.09.2018; ООО \"Энергоучет\", energouchet_uk@mail.ru", "О программе", MessageBoxButtons.OK);
            });
        }

        #endregion

        #region Работа формы

        public frmMain() // Конструктор 
        {
            InitializeComponent();
            PortProperties();
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e) // Когда форма закрывается 
        {
            if (WorkOn)
            {
                _Work.Cancel();
                Thread.Sleep(500);
            }
        }

        public TextBox GetTextBoxWithAccident() // Возвращает текст бокс с авариями 
        {
            return TextBoxAccident;
        }

        private void frmMain_Load(object sender, EventArgs e) // Заготовка форм счетчиков для Инкаба 
        {
            AddNewCounter(new AmountCounter()); // Суммирующий график мощностей
            AddNewCounter(new NewCounter("1", this));
            AddNewCounter(new NewCounter("2", this));
            AddNewCounter(new NewCounter("3", this));
            AddNewCounter(new NewCounter("4", this));
            AddNewCounter(new NewCounter("5", this));
            AddNewCounter(new NewCounter("6", this));
            AddNewCounter(new NewCounter("7", this));
            AddNewCounter(new NewCounter("8", this));
            toolStripButton1_Click(null, new EventArgs());
        }

        public bool InputPassword() // Остановка опроса 
        {
            ControlStop Stop = new ControlStop();
            Stop.ShowDialog();
            if (Stop.DialogResult == DialogResult.OK)
            {
                _Work.Cancel();
                WorkOn = false; // Меняем флаг работы опроса
                toolStripLabel3.Text = "Опрос счетчиков отключен"; // Меняем флаги
                notifyIcon1.Text = "Контроль электроэнергии[ВЫКЛ]";
                notifyIcon1.Icon = Resources.IconStop;
                toolStripLabel3.ForeColor = Color.Black;
                toolStripButton2.Enabled = false;
                LabelPort.Enabled = true;
                toolStripButton1.Enabled = true;
                return true;
            }
            return false;
        }

        public void PortProperties() // Установка надписи о текущем порте 
        {
            try
            {
                if (SaveLatestPort.Check()) // Пробуем взять из файла 
                {
                    LabelPort.Text = SaveLatestPort.Read();
                }
                else { LabelPort.Text = SerialPort.GetPortNames()[0]; } // Если нет устанавливаем существующие 
            }
            catch
            {
                LabelPort.Text = "null"; // Иначе 0
            }
        }

        public void WriteException() // Установка надписи о разрыве связи 
        {
            if (WorkOn)
            {
                toolStripLabel3.Text = "НЕТ СВЯЗИ, ПРОВЕРЬТЕ КАБЕЛЬ"; // Меняем флаги
                notifyIcon1.Text = "Контроль электроэнергии[НЕТ СВЯЗИ]";
                notifyIcon1.Icon = Resources.IconException;
                toolStripLabel3.ForeColor = Color.Red;
            }
        }

        public void WriteGoodWork() // Установка надписи о хорошем соеднинении 
        {
            if (WorkOn)
            {
                toolStripLabel3.Text = "Опрос счетчиков включен"; // Меняем флаги
                notifyIcon1.Text = "Контроль электроэнергии[ВКЛ]";
                notifyIcon1.Icon = Resources.IconGood;
                toolStripLabel3.ForeColor = Color.Green;
            }
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
    }
}
