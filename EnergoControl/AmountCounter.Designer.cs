namespace EnergoControl
{
    partial class AmountCounter
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.label3 = new System.Windows.Forms.Label();
            this.ChartPower = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.ClearAccident = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ActivePowerValue = new System.Windows.Forms.Label();
            this.FullPowerValue = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.Time = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ChartPower)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(251, 20);
            this.label3.TabIndex = 64;
            this.label3.Text = "Суммарный график мощностей:";
            // 
            // ChartPower
            // 
            chartArea2.Name = "ChartArea1";
            this.ChartPower.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.ChartPower.Legends.Add(legend2);
            this.ChartPower.Location = new System.Drawing.Point(12, 121);
            this.ChartPower.Name = "ChartPower";
            series3.BorderWidth = 5;
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series3.Color = System.Drawing.Color.DarkGoldenrod;
            series3.Legend = "Legend1";
            series3.Name = "Полная мощность";
            series3.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Time;
            series4.BorderWidth = 5;
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series4.Color = System.Drawing.Color.RoyalBlue;
            series4.Legend = "Legend1";
            series4.Name = "Активная мощность";
            series4.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Time;
            this.ChartPower.Series.Add(series3);
            this.ChartPower.Series.Add(series4);
            this.ChartPower.Size = new System.Drawing.Size(1007, 538);
            this.ChartPower.TabIndex = 60;
            this.ChartPower.Text = "chart2";
            // 
            // ClearAccident
            // 
            this.ClearAccident.BackColor = System.Drawing.Color.LightCoral;
            this.ClearAccident.Location = new System.Drawing.Point(900, 618);
            this.ClearAccident.Name = "ClearAccident";
            this.ClearAccident.Size = new System.Drawing.Size(115, 45);
            this.ClearAccident.TabIndex = 65;
            this.ClearAccident.Text = "Очистить";
            this.ClearAccident.UseVisualStyleBackColor = false;
            this.ClearAccident.Click += new System.EventHandler(this.ClearAccident_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(334, 20);
            this.label1.TabIndex = 66;
            this.label1.Text = "Последнее значение активной мощности: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(318, 20);
            this.label2.TabIndex = 67;
            this.label2.Text = "Последнее значение полной мощности: ";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.ActivePowerValue);
            this.panel1.Location = new System.Drawing.Point(348, 9);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(118, 37);
            this.panel1.TabIndex = 68;
            // 
            // ActivePowerValue
            // 
            this.ActivePowerValue.AutoSize = true;
            this.ActivePowerValue.BackColor = System.Drawing.Color.CornflowerBlue;
            this.ActivePowerValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ActivePowerValue.Location = new System.Drawing.Point(9, 3);
            this.ActivePowerValue.Name = "ActivePowerValue";
            this.ActivePowerValue.Size = new System.Drawing.Size(20, 25);
            this.ActivePowerValue.TabIndex = 69;
            this.ActivePowerValue.Text = "-";
            this.ActivePowerValue.Visible = false;
            // 
            // FullPowerValue
            // 
            this.FullPowerValue.AutoSize = true;
            this.FullPowerValue.BackColor = System.Drawing.Color.DarkGoldenrod;
            this.FullPowerValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FullPowerValue.Location = new System.Drawing.Point(7, 3);
            this.FullPowerValue.Name = "FullPowerValue";
            this.FullPowerValue.Size = new System.Drawing.Size(20, 25);
            this.FullPowerValue.TabIndex = 69;
            this.FullPowerValue.Text = "-";
            this.FullPowerValue.Visible = false;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.FullPowerValue);
            this.panel2.Location = new System.Drawing.Point(348, 52);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(118, 37);
            this.panel2.TabIndex = 70;
            // 
            // Time
            // 
            this.Time.AutoSize = true;
            this.Time.BackColor = System.Drawing.SystemColors.Control;
            this.Time.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Time.Location = new System.Drawing.Point(553, 37);
            this.Time.Name = "Time";
            this.Time.Size = new System.Drawing.Size(0, 25);
            this.Time.TabIndex = 70;
            this.Time.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(472, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 20);
            this.label4.TabIndex = 71;
            this.label4.Text = "кВт";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(470, 57);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 20);
            this.label5.TabIndex = 72;
            this.label5.Text = "кВА";
            // 
            // AmountCounter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1031, 664);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Time);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ClearAccident);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ChartPower);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AmountCounter";
            this.Text = "Amount";
            ((System.ComponentModel.ISupportInitialize)(this.ChartPower)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataVisualization.Charting.Chart ChartPower;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button ClearAccident;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label ActivePowerValue;
        private System.Windows.Forms.Label FullPowerValue;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label Time;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}