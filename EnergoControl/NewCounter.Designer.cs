namespace EnergoControl
{
    partial class NewCounter
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ChartPower = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.CMaxCurrent = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.CMinVoltage = new System.Windows.Forms.Label();
            this.CMaxVoltage = new System.Windows.Forms.Label();
            this.CMinCurrent = new System.Windows.Forms.Label();
            this.CVoltage = new System.Windows.Forms.Label();
            this.CCurrent = new System.Windows.Forms.Label();
            this.AMinCurrent = new System.Windows.Forms.Label();
            this.BVoltage = new System.Windows.Forms.Label();
            this.BCurrent = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.AVoltage = new System.Windows.Forms.Label();
            this.ACurrent = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.AMaxCurrent = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label25 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.AMinVoltage = new System.Windows.Forms.Label();
            this.AMaxVoltage = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label28 = new System.Windows.Forms.Label();
            this.BMaxCurrent = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.BMinVoltage = new System.Windows.Forms.Label();
            this.BMaxVoltage = new System.Windows.Forms.Label();
            this.BMinCurrent = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.LogBox = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ChartPower)).BeginInit();
            this.panel4.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.ChartPower);
            this.groupBox1.Controls.Add(this.panel4);
            this.groupBox1.Controls.Add(this.AMinCurrent);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.AMaxCurrent);
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Controls.Add(this.panel2);
            this.groupBox1.Controls.Add(this.panel5);
            this.groupBox1.Controls.Add(this.panel6);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(987, 642);
            this.groupBox1.TabIndex = 36;
            this.groupBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 164);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(232, 20);
            this.label3.TabIndex = 64;
            this.label3.Text = "График мощности (U*I*Cos fi)";
            // 
            // ChartPower
            // 
            chartArea1.Name = "ChartArea1";
            this.ChartPower.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.ChartPower.Legends.Add(legend1);
            this.ChartPower.Location = new System.Drawing.Point(12, 193);
            this.ChartPower.Name = "ChartPower";
            series1.BorderWidth = 5;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Color = System.Drawing.Color.Yellow;
            series1.Legend = "Legend1";
            series1.Name = "Фаза А";
            series1.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Time;
            series2.BorderWidth = 5;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Color = System.Drawing.Color.Lime;
            series2.Legend = "Legend1";
            series2.Name = "Фаза B";
            series2.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Time;
            series3.BorderWidth = 5;
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series3.Color = System.Drawing.Color.Red;
            series3.Legend = "Legend1";
            series3.Name = "Фаза С";
            series3.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Time;
            this.ChartPower.Series.Add(series1);
            this.ChartPower.Series.Add(series2);
            this.ChartPower.Series.Add(series3);
            this.ChartPower.Size = new System.Drawing.Size(969, 285);
            this.ChartPower.TabIndex = 60;
            this.ChartPower.Text = "chart2";
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel4.Controls.Add(this.label1);
            this.panel4.Controls.Add(this.CMaxCurrent);
            this.panel4.Controls.Add(this.label16);
            this.panel4.Controls.Add(this.CMinVoltage);
            this.panel4.Controls.Add(this.CMaxVoltage);
            this.panel4.Controls.Add(this.CMinCurrent);
            this.panel4.Location = new System.Drawing.Point(604, 484);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(255, 141);
            this.panel4.TabIndex = 59;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 20);
            this.label1.TabIndex = 37;
            this.label1.Text = "C - MAX";
            // 
            // CMaxCurrent
            // 
            this.CMaxCurrent.AutoSize = true;
            this.CMaxCurrent.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CMaxCurrent.Location = new System.Drawing.Point(29, 63);
            this.CMaxCurrent.Name = "CMaxCurrent";
            this.CMaxCurrent.Size = new System.Drawing.Size(65, 20);
            this.CMaxCurrent.TabIndex = 43;
            this.CMaxCurrent.Text = "-10000";
            this.CMaxCurrent.Visible = false;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(148, 11);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(62, 20);
            this.label16.TabIndex = 47;
            this.label16.Text = "C - MIN";
            // 
            // CMinVoltage
            // 
            this.CMinVoltage.AutoSize = true;
            this.CMinVoltage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CMinVoltage.Location = new System.Drawing.Point(148, 106);
            this.CMinVoltage.Name = "CMinVoltage";
            this.CMinVoltage.Size = new System.Drawing.Size(59, 20);
            this.CMinVoltage.TabIndex = 50;
            this.CMinVoltage.Text = "10000";
            this.CMinVoltage.Visible = false;
            // 
            // CMaxVoltage
            // 
            this.CMaxVoltage.AutoSize = true;
            this.CMaxVoltage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CMaxVoltage.Location = new System.Drawing.Point(29, 106);
            this.CMaxVoltage.Name = "CMaxVoltage";
            this.CMaxVoltage.Size = new System.Drawing.Size(65, 20);
            this.CMaxVoltage.TabIndex = 44;
            this.CMaxVoltage.Text = "-10000";
            this.CMaxVoltage.Visible = false;
            // 
            // CMinCurrent
            // 
            this.CMinCurrent.AutoSize = true;
            this.CMinCurrent.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CMinCurrent.Location = new System.Drawing.Point(148, 63);
            this.CMinCurrent.Name = "CMinCurrent";
            this.CMinCurrent.Size = new System.Drawing.Size(59, 20);
            this.CMinCurrent.TabIndex = 49;
            this.CMinCurrent.Text = "10000";
            this.CMinCurrent.Visible = false;
            // 
            // CVoltage
            // 
            this.CVoltage.AutoSize = true;
            this.CVoltage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CVoltage.Location = new System.Drawing.Point(351, 103);
            this.CVoltage.Name = "CVoltage";
            this.CVoltage.Size = new System.Drawing.Size(37, 20);
            this.CVoltage.TabIndex = 31;
            this.CVoltage.Text = "null";
            // 
            // CCurrent
            // 
            this.CCurrent.AutoSize = true;
            this.CCurrent.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CCurrent.Location = new System.Drawing.Point(351, 60);
            this.CCurrent.Name = "CCurrent";
            this.CCurrent.Size = new System.Drawing.Size(37, 20);
            this.CCurrent.TabIndex = 30;
            this.CCurrent.Text = "null";
            // 
            // AMinCurrent
            // 
            this.AMinCurrent.AutoSize = true;
            this.AMinCurrent.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AMinCurrent.Location = new System.Drawing.Point(263, 547);
            this.AMinCurrent.Name = "AMinCurrent";
            this.AMinCurrent.Size = new System.Drawing.Size(59, 20);
            this.AMinCurrent.TabIndex = 54;
            this.AMinCurrent.Text = "10000";
            this.AMinCurrent.Visible = false;
            // 
            // BVoltage
            // 
            this.BVoltage.AutoSize = true;
            this.BVoltage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BVoltage.Location = new System.Drawing.Point(253, 103);
            this.BVoltage.Name = "BVoltage";
            this.BVoltage.Size = new System.Drawing.Size(37, 20);
            this.BVoltage.TabIndex = 29;
            this.BVoltage.Text = "null";
            // 
            // BCurrent
            // 
            this.BCurrent.AutoSize = true;
            this.BCurrent.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BCurrent.Location = new System.Drawing.Point(253, 60);
            this.BCurrent.Name = "BCurrent";
            this.BCurrent.Size = new System.Drawing.Size(37, 20);
            this.BCurrent.TabIndex = 28;
            this.BCurrent.Text = "null";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(42, 547);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(54, 20);
            this.label15.TabIndex = 39;
            this.label15.Text = "Ток, A";
            // 
            // AVoltage
            // 
            this.AVoltage.AutoSize = true;
            this.AVoltage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AVoltage.Location = new System.Drawing.Point(154, 103);
            this.AVoltage.Name = "AVoltage";
            this.AVoltage.Size = new System.Drawing.Size(37, 20);
            this.AVoltage.TabIndex = 27;
            this.AVoltage.Text = "null";
            // 
            // ACurrent
            // 
            this.ACurrent.AutoSize = true;
            this.ACurrent.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ACurrent.Location = new System.Drawing.Point(154, 60);
            this.ACurrent.Name = "ACurrent";
            this.ACurrent.Size = new System.Drawing.Size(37, 20);
            this.ACurrent.TabIndex = 26;
            this.ACurrent.Text = "null";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(36, 590);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(67, 20);
            this.label14.TabIndex = 40;
            this.label14.Text = "Напр, В";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(44, 103);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(67, 20);
            this.label9.TabIndex = 25;
            this.label9.Text = "Напр, В";
            // 
            // AMaxCurrent
            // 
            this.AMaxCurrent.AutoSize = true;
            this.AMaxCurrent.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AMaxCurrent.Location = new System.Drawing.Point(143, 547);
            this.AMaxCurrent.Name = "AMaxCurrent";
            this.AMaxCurrent.Size = new System.Drawing.Size(65, 20);
            this.AMaxCurrent.TabIndex = 41;
            this.AMaxCurrent.Text = "-10000";
            this.AMaxCurrent.Visible = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(47, 60);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(54, 20);
            this.label8.TabIndex = 24;
            this.label8.Text = "Ток, A";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.label25);
            this.panel1.Controls.Add(this.label18);
            this.panel1.Controls.Add(this.AMinVoltage);
            this.panel1.Controls.Add(this.AMaxVoltage);
            this.panel1.Location = new System.Drawing.Point(110, 484);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(255, 141);
            this.panel1.TabIndex = 56;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(151, 11);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(62, 20);
            this.label25.TabIndex = 37;
            this.label25.Text = "А - MIN";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(34, 11);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(68, 20);
            this.label18.TabIndex = 36;
            this.label18.Text = "А - MAX";
            // 
            // AMinVoltage
            // 
            this.AMinVoltage.AutoSize = true;
            this.AMinVoltage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AMinVoltage.Location = new System.Drawing.Point(151, 106);
            this.AMinVoltage.Name = "AMinVoltage";
            this.AMinVoltage.Size = new System.Drawing.Size(59, 20);
            this.AMinVoltage.TabIndex = 55;
            this.AMinVoltage.Text = "10000";
            this.AMinVoltage.Visible = false;
            // 
            // AMaxVoltage
            // 
            this.AMaxVoltage.AutoSize = true;
            this.AMaxVoltage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AMaxVoltage.Location = new System.Drawing.Point(31, 104);
            this.AMaxVoltage.Name = "AMaxVoltage";
            this.AMaxVoltage.Size = new System.Drawing.Size(65, 20);
            this.AMaxVoltage.TabIndex = 42;
            this.AMaxVoltage.Text = "-10000";
            this.AMaxVoltage.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(351, 8);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 20);
            this.label7.TabIndex = 23;
            this.label7.Text = "Фаза C";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.label17);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.label21);
            this.panel2.Controls.Add(this.label22);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.label24);
            this.panel2.Location = new System.Drawing.Point(371, 484);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(226, 141);
            this.panel2.TabIndex = 57;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.label28);
            this.panel3.Controls.Add(this.BMaxCurrent);
            this.panel3.Controls.Add(this.label30);
            this.panel3.Controls.Add(this.BMinVoltage);
            this.panel3.Controls.Add(this.BMaxVoltage);
            this.panel3.Controls.Add(this.BMinCurrent);
            this.panel3.Location = new System.Drawing.Point(-2, -2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(255, 141);
            this.panel3.TabIndex = 58;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(29, 11);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(68, 20);
            this.label28.TabIndex = 37;
            this.label28.Text = "B - MAX";
            // 
            // BMaxCurrent
            // 
            this.BMaxCurrent.AutoSize = true;
            this.BMaxCurrent.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BMaxCurrent.Location = new System.Drawing.Point(29, 63);
            this.BMaxCurrent.Name = "BMaxCurrent";
            this.BMaxCurrent.Size = new System.Drawing.Size(65, 20);
            this.BMaxCurrent.TabIndex = 43;
            this.BMaxCurrent.Text = "-10000";
            this.BMaxCurrent.Visible = false;
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(148, 11);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(62, 20);
            this.label30.TabIndex = 47;
            this.label30.Text = "B - MIN";
            // 
            // BMinVoltage
            // 
            this.BMinVoltage.AutoSize = true;
            this.BMinVoltage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BMinVoltage.Location = new System.Drawing.Point(148, 106);
            this.BMinVoltage.Name = "BMinVoltage";
            this.BMinVoltage.Size = new System.Drawing.Size(59, 20);
            this.BMinVoltage.TabIndex = 50;
            this.BMinVoltage.Text = "10000";
            this.BMinVoltage.Visible = false;
            // 
            // BMaxVoltage
            // 
            this.BMaxVoltage.AutoSize = true;
            this.BMaxVoltage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BMaxVoltage.Location = new System.Drawing.Point(29, 106);
            this.BMaxVoltage.Name = "BMaxVoltage";
            this.BMaxVoltage.Size = new System.Drawing.Size(65, 20);
            this.BMaxVoltage.TabIndex = 44;
            this.BMaxVoltage.Text = "-10000";
            this.BMaxVoltage.Visible = false;
            // 
            // BMinCurrent
            // 
            this.BMinCurrent.AutoSize = true;
            this.BMinCurrent.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BMinCurrent.Location = new System.Drawing.Point(148, 63);
            this.BMinCurrent.Name = "BMinCurrent";
            this.BMinCurrent.Size = new System.Drawing.Size(59, 20);
            this.BMinCurrent.TabIndex = 49;
            this.BMinCurrent.Text = "10000";
            this.BMinCurrent.Visible = false;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(3, 6);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(68, 20);
            this.label17.TabIndex = 37;
            this.label17.Text = "B - MAX";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(3, 58);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(33, 20);
            this.label11.TabIndex = 43;
            this.label11.Text = "null";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(122, 6);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(62, 20);
            this.label21.TabIndex = 47;
            this.label21.Text = "B - MIN";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(122, 101);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(33, 20);
            this.label22.TabIndex = 50;
            this.label22.Text = "null";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(3, 101);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(33, 20);
            this.label10.TabIndex = 44;
            this.label10.Text = "null";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(122, 58);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(33, 20);
            this.label24.TabIndex = 49;
            this.label24.Text = "null";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(253, 8);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 20);
            this.label6.TabIndex = 22;
            this.label6.Text = "Фаза B";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(154, 8);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 20);
            this.label5.TabIndex = 21;
            this.label5.Text = "Фаза А";
            // 
            // panel5
            // 
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel5.Controls.Add(this.label8);
            this.panel5.Controls.Add(this.label5);
            this.panel5.Controls.Add(this.label6);
            this.panel5.Controls.Add(this.CVoltage);
            this.panel5.Controls.Add(this.label7);
            this.panel5.Controls.Add(this.CCurrent);
            this.panel5.Controls.Add(this.label9);
            this.panel5.Controls.Add(this.ACurrent);
            this.panel5.Controls.Add(this.BVoltage);
            this.panel5.Controls.Add(this.AVoltage);
            this.panel5.Controls.Add(this.BCurrent);
            this.panel5.Location = new System.Drawing.Point(0, 15);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(490, 139);
            this.panel5.TabIndex = 62;
            // 
            // panel6
            // 
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel6.Controls.Add(this.label2);
            this.panel6.Controls.Add(this.LogBox);
            this.panel6.Location = new System.Drawing.Point(501, 15);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(490, 139);
            this.panel6.TabIndex = 63;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 20);
            this.label2.TabIndex = 64;
            this.label2.Text = "События";
            // 
            // LogBox
            // 
            this.LogBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LogBox.Location = new System.Drawing.Point(3, 32);
            this.LogBox.MaxLength = 32000;
            this.LogBox.Multiline = true;
            this.LogBox.Name = "LogBox";
            this.LogBox.ReadOnly = true;
            this.LogBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.LogBox.Size = new System.Drawing.Size(480, 100);
            this.LogBox.TabIndex = 61;
            // 
            // NewCounter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1011, 687);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "NewCounter";
            this.Text = "NewCounter";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ChartPower)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label CMaxCurrent;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label CMinVoltage;
        private System.Windows.Forms.Label CMaxVoltage;
        private System.Windows.Forms.Label CMinCurrent;
        private System.Windows.Forms.Label CVoltage;
        private System.Windows.Forms.Label AMinVoltage;
        private System.Windows.Forms.Label CCurrent;
        private System.Windows.Forms.Label AMinCurrent;
        private System.Windows.Forms.Label BVoltage;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label BCurrent;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label AVoltage;
        private System.Windows.Forms.Label AMaxVoltage;
        private System.Windows.Forms.Label ACurrent;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label AMaxCurrent;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label BMaxCurrent;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label BMinVoltage;
        private System.Windows.Forms.Label BMaxVoltage;
        private System.Windows.Forms.Label BMinCurrent;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataVisualization.Charting.Chart ChartPower;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox LogBox;
        private System.Windows.Forms.Label label3;
    }
}