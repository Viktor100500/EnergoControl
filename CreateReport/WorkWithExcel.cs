using System;
using System.Collections.Generic;
using System.IO;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using OfficeOpenXml;
using OfficeOpenXml.Drawing.Chart;
using OfficeOpenXml.Style;

namespace CreateReport
{
    class WorkWithExcel // Класс для генерации Excel отчета по входнным критериям 
    {
        private List<int> Counters; // Массив выбранных счетчиков
        private bool[] SelectedData; // Массив выбранной информации
        private DateTime Before; // Дата до которой нужно вывести информацию
        private DateTime After; // Дата после которой нужно вывести информацию
        private ExcelWorksheet Counter; // Текущий лист с которым идет работа
        private int IDCounter; // Текущий ID счетчика с которым идет работа
        private List<int> CountIdnications; // Количество показаний
        private string FileName; // Имя файла отчета
        private const int AccidentLow = 207;
        private const int AccidentHigh = 253;

        public WorkWithExcel(DateTime A, DateTime B, List<int> C, bool[] D) // Конструктор 
        {
            After = A;
            Before = B;
            Counters = C;
            SelectedData = D;
            FileName = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Энергоконтроль\\Отчеты" + "\\Отчет " + CreateNameFile() + ".xlsx";
            CountIdnications = new List<int>();
        }

        public void CreateExcelFile() // Создать ексель файл 
        {
            CheckNameFile();
            using (FileStream NF = new FileStream(FileName, FileMode.Create))
            {
                ExcelPackage NExcel = new ExcelPackage(NF);
                ExcelWorkbook workbook = NExcel.Workbook; // Создаем приложение Excel
                for (int i = 0; i < Counters.Count; i++)
                {
                    Counter = workbook.Worksheets.Add("Счетчик " + Counters[i]); // Добавляем новый лист
                    IDCounter = Counters[i];
                    if (!FillList()) // Пытаемся заполнить, если нет, удаляем лист
                    {
                        workbook.Worksheets.Delete("Счетчик " + Counters[i]);
                    }
                }

                if (workbook.Worksheets.Count != 0)
                {
                    try
                    {
                        if (workbook.Worksheets.Count != 0)
                        {
                            NExcel.SaveAs(NF); // Сохраняем изменения
                        }
                    }
                    catch
                    {
                        MessageBox.Show(
                            "Не удалось сохранить или открыть файл, закройте предыдущие отчеты или сохраните их под другим именем",
                            "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    Process.Start(FileName);
                }
            }
        }

        void CheckNameFile() // Проверяем открыт ли файл с таким именем, если да добавляем единички 
        {
            bool ok = false;
            int i = 1;
            while (!ok)
            {
                try
                {
                    using (var fs = File.Open(FileName, FileMode.Create))
                    {
                        ok = true;
                    }
                }
                catch
                {
                    FileName = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Энергоконтроль\\Отчеты" + "\\Отчет " + CreateNameFile() + " " + i + ".xlsx";
                    i++;
                }
            }

        }

        void AddChartsWithEPPlus() // Добавляем графики 
        {
            string[] Titles = { "Сила тока", "Напряжение", "Мощность" };
            //create a WorkSheet
            for (int i = 0; i < 2; i++)
            {
                if (SelectedData[i]) // Сила тока и напряжение 
                {
                    //create a new piechart of type Line
                    ExcelLineChart lineChart =
                        Counter.Drawings.AddChart("lineChart" + i, eChartType.Line) as ExcelLineChart;

                    //set the title
                    lineChart.Title.Text = Titles[i];

                    //create the ranges for the chart
                    var rangeLabel = Counter.Cells["A32:A" + (CountIdnications[0] + 31)]; // Время
                    var range1 = Counter.Cells[32, 2 + i, CountIdnications[0] + 31, 2 + i]; // Фаза А
                    var range2 = Counter.Cells[32, 5 + i, CountIdnications[0] + 31, 5 + i]; // Фаза B
                    var range3 = Counter.Cells[32, 8 + i, CountIdnications[0] + 31, 8 + i]; // Фаза C

                    //add the ranges to the chart
                    lineChart.Series.Add(range1, rangeLabel);
                    lineChart.Series.Add(range2, rangeLabel);
                    lineChart.Series.Add(range3, rangeLabel);

                    //set the names of the legend
                    lineChart.Series[0].Header = Counter.Cells["B30"].Value.ToString();
                    lineChart.Series[1].Header = Counter.Cells["E30"].Value.ToString();
                    lineChart.Series[2].Header = Counter.Cells["H30"].Value.ToString();

                    // Красим легенды 
                    lineChart.SetLineChartColor(0, i, Color.FromArgb(0xFFEC8B));
                    lineChart.SetLineChartColor(1, i, Color.FromArgb(0x98FB98));
                    lineChart.SetLineChartColor(2, i, Color.FromArgb(0xFA5050));

                    //position of the legend
                    lineChart.Legend.Position = eLegendPosition.Right;

                    //size of the chart
                    lineChart.SetSize(600 + i * 170, 500);

                    //add the chart at cell B6
                    lineChart.SetPosition(3, 0, 0 + i * 10, 0);
                }
            }

            if (SelectedData[2]) // Мощность
            {
                //create a new piechart of type Line
                ExcelLineChart lineChart =
                    Counter.Drawings.AddChart("lineChart2", eChartType.Line) as ExcelLineChart;

                //set the title
                lineChart.Title.Text = Titles[2];

                //create the ranges for the chart
                var rangeLabel = Counter.Cells["A32:A" + (CountIdnications[0] + 31)]; // Время
                var range1 = Counter.Cells["K32:K" + (CountIdnications[0] + 31)]; // Активная
                var range2 = Counter.Cells["L32:L" + (CountIdnications[0] + 31)]; // Полная

                //add the ranges to the chart
                lineChart.Series.Add(range1, rangeLabel);
                lineChart.Series.Add(range2, rangeLabel);

                //set the names of the legend
                lineChart.Series[0].Header = Counter.Cells["K31"].Value.ToString();
                lineChart.Series[1].Header = Counter.Cells["L31"].Value.ToString();

                //position of the legend
                lineChart.Legend.Position = eLegendPosition.Right;

                //size of the chart
                lineChart.SetSize(780, 500);

                //add the chart at cell B6
                lineChart.SetPosition(3, 0, 23, 0);
            }
            CountIdnications.RemoveAt(0);
        }

        bool FillList() // Создать лист конкретного счетчика 
        {
            // Добавляем стандартную информацию 
            AddStandartInformation();

            // Парсим файлы и получаем список показаний 
            Deserialization Finder = new Deserialization(After, Before, IDCounter.ToString());
            if (Finder.FindIndications())
            {
                AddData(Finder); // Добавляем данные из базы данных
            }
            else
            {
                MessageBox.Show("Данных по заданному периоду для счетчика " + IDCounter + " нет", "Внимание", MessageBoxButtons.OK,
                MessageBoxIcon.Asterisk);
                return false;
            }
            // Добавляем графики 
            AddChartsWithEPPlus();
            // Косметические настройки
            Counter.Cells.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            Counter.Cells.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            Counter.Cells.AutoFitColumns();
            AddBorders();
            return true;
        }

        void AddData(Deserialization Finder) // Заполняем выбранные данные 
        {
            CountIdnications.Add(Finder.Times.Count);
            for (int i = 0; i < Finder.Times.Count; i++)
            {
                Counter.Cells[32 + i, 1].Value = Finder.Times[i].ToString(); // Добавляем время показания
                for (int j = 0; j < 3; j++) // Добавляем данные по фазам 
                {
                    if (SelectedData[j])
                    {
                        if (j == 1 && (Finder.Indications[i][j, 0] > AccidentHigh || Finder.Indications[i][j, 0] < AccidentLow)) // Проверка на аварии
                        {
                            Counter.Cells[32 + i, 2 + j].Style.Fill.PatternType = ExcelFillStyle.Solid;
                            Counter.Cells[32 + i, 2 + j].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(0xFF7C80));
                        }
                        Counter.Cells[32 + i, 2 + j].Value = Finder.Indications[i][j, 0];
                        if (j == 1 && (Finder.Indications[i][j, 1] > AccidentHigh || Finder.Indications[i][j, 1] < AccidentLow))
                        {
                            Counter.Cells[32 + i, 5 + j].Style.Fill.PatternType = ExcelFillStyle.Solid;
                            Counter.Cells[32 + i, 5 + j].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(0xFF7C80));
                        }
                        Counter.Cells[32 + i, 5 + j].Value = Finder.Indications[i][j, 1];
                        if (j == 1 && (Finder.Indications[i][j, 2] > AccidentHigh || Finder.Indications[i][j, 2] < AccidentLow))
                        {
                            Counter.Cells[32 + i, 8 + j].Style.Fill.PatternType = ExcelFillStyle.Solid;
                            Counter.Cells[32 + i, 8 + j].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(0xFF7C80));
                        }
                        Counter.Cells[32 + i, 8 + j].Value = Finder.Indications[i][j, 2];
                    }

                }
                // Добавляем мощность 
                if (SelectedData[3])
                {
                    Counter.Cells[32 + i, 11].FormulaR1C1 = "=RC2*RC3*RC4+RC5*RC6*RC7+RC8*RC9*RC10";
                    Counter.Cells[32 + i, 12].FormulaR1C1 = "=RC2*RC3+RC5*RC6+RC8*RC9";
                }
            }
        }

        void AddStandartInformation() // ДОБАВЛЯЕМ шаблонные надписи в зависимости от выбранного счетчика и необходимых данных 
        {
            // Добавляем название 
            AddTitle();

            // Добавляем период
            AddPeriod();

            // Добавляем наименования столбика Время
            AddNameColumnTime();

            // Добавляем столбики для всех фаз
            AddPhase("A");
            AddPhase("B");
            AddPhase("C");
            Counter.Cells["A30:L31"].Style.Border.BorderAround(ExcelBorderStyle.Thin);

            // Добавляем наименования для столбиков выбранных данных
            for (int i = 0; i < SelectedData.Length; i++)
            {
                if (SelectedData[i])
                {
                    switch (i)
                    {
                        // Напряжение 
                        case 1:
                            AddVoltageTitle();
                            break;

                        // Ток
                        case 0:
                            AddCurrentTitle();
                            break;

                        // Косинус φ
                        case 2:
                            AddCosFiTitle();
                            break;

                        // Мощность
                        case 3:
                            AddPowerFiTitle();
                            break;
                    }
                }
            }
        }

        void AddPhase(string Phase) // Добавить фазу 
        {
            switch (Phase)
            {
                case "A":
                    Counter.Cells["B30"].Value = "Фаза А";
                    Counter.Cells["B30"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    Counter.Cells["B30"].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(0xFFEC8B));
                    Counter.Cells["B30:D30"].Merge = true;
                    break;
                case "B":
                    Counter.Cells["E30"].Value = "Фаза B";
                    Counter.Cells["E30"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    Counter.Cells["E30"].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(0x98FB98)); ;
                    Counter.Cells["E30:G30"].Merge = true;
                    break;
                case "C":
                    Counter.Cells["H30"].Value = "Фаза C";
                    Counter.Cells["H30"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    Counter.Cells["H30"].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(0xFA5050));
                    Counter.Cells["H30:J30"].Merge = true;
                    break;
            }
        }

        string CreateNameFile() // Создаем подходящее относительно даты время 
        {
            string Name = DateTime.Today.ToString();
            Name = Name.Replace(":", ".");
            Name = Name.Substring(0, 8);
            return Name;
        }

        void AddPeriod() // Добавить в лист информацию о выбранном периоде 
        {
            Counter.Cells["A2"].Value = "С " + After + " по " + Before;
            Counter.Cells["A2:D2"].Merge = true;
            Counter.Cells["A2:D2"].Style.Border.BorderAround(ExcelBorderStyle.Thin);
        }

        void AddTitle() // Добавить название листа и отобразить его на листе 
        {
            Counter.Cells["A1"].Value = "Счетчик " + IDCounter;
            Counter.Cells["A1:L1"].Style.Border.BorderAround(ExcelBorderStyle.Thin);
            Counter.Cells["A1"].Style.Font.Size = 15;
            Counter.Cells["A1:L1"].Merge = true;
        }

        void AddNameColumnTime() // Добавляем наименования столбика Время 
        {
            Counter.Cells["A30"].Value = "Время";
            Counter.Cells["A30:A31"].Merge = true;
        }

        void AddCurrentTitle() // Добавляем название столбцов для напряжения 
        {
            Counter.Cells["B31"].Value = "Сила тока, А";
            Counter.Cells["B31"].Style.Fill.PatternType = ExcelFillStyle.Solid;
            Counter.Cells["B31"].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(0xFFEC8B)); // lightyellow
            Counter.Cells["E31"].Value = "Сила тока, А";
            Counter.Cells["E31"].Style.Fill.PatternType = ExcelFillStyle.Solid;
            Counter.Cells["E31"].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(0x98FB98));
            Counter.Cells["H31"].Value = "Сила тока, А";
            Counter.Cells["H31"].Style.Fill.PatternType = ExcelFillStyle.Solid;
            Counter.Cells["H31"].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(0xFA5050));
        }

        void AddVoltageTitle() // Добавляем название столбцов для тока 
        {
            Counter.Cells["C31"].Value = "Напряжение, В";
            Counter.Cells["C31"].Style.Fill.PatternType = ExcelFillStyle.Solid;
            Counter.Cells["C31"].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(0xFFEC8B));
            Counter.Cells["F31"].Value = "Напряжение, В";
            Counter.Cells["F31"].Style.Fill.PatternType = ExcelFillStyle.Solid;
            Counter.Cells["F31"].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(0x98FB98));
            Counter.Cells["I31"].Value = "Напряжение, В";
            Counter.Cells["I31"].Style.Fill.PatternType = ExcelFillStyle.Solid;
            Counter.Cells["I31"].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(0xFA5050));
        }

        void AddCosFiTitle() // Добавляем название столбцов для Косинусов Fi 
        {
            Counter.Cells["D31"].Value = "Cos φ";
            Counter.Cells["D31"].Style.Fill.PatternType = ExcelFillStyle.Solid;
            Counter.Cells["D31"].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(0xFFEC8B));
            Counter.Cells["G31"].Value = "Cos φ";
            Counter.Cells["G31"].Style.Fill.PatternType = ExcelFillStyle.Solid;
            Counter.Cells["G31"].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(0x98FB98)); ;
            Counter.Cells["J31"].Value = "Cos φ";
            Counter.Cells["J31"].Style.Fill.PatternType = ExcelFillStyle.Solid;
            Counter.Cells["J31"].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(0xFA5050));
        }

        void AddPowerFiTitle() // Добавляем название столбцов для Мощности 
        {
            Counter.Cells["K30"].Value = "Мощность";
            Counter.Cells["K30:L30"].Merge = true;
            Counter.Cells["K31"].Value = "Активная, Вт";
            Counter.Cells["L31"].Value = "Полная, ВА";
            Counter.Cells["K30:L31"].Style.Fill.PatternType = ExcelFillStyle.Solid;
            Counter.Cells["K30:L31"].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(0x8EA9DB));
        }

        void AddBorders() // Добавить границы 
        {
            for (int i = 30; i <= 31; i++)
            {
                for (int j = 1; j <= 12; j++)
                {
                    Counter.Cells[i, j].Style.Border.BorderAround(ExcelBorderStyle.Thin);
                }
            }
        }


    }
}
