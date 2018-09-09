namespace CreateReport
{
    partial class CreateReportForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateReportForm));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.B1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.B2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.B3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator12 = new System.Windows.Forms.ToolStripSeparator();
            this.B4 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator11 = new System.Windows.Forms.ToolStripSeparator();
            this.B5 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.B6 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
            this.B7 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.B8 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.B9 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.B10 = new System.Windows.Forms.ToolStripButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TimePickerBefore = new System.Windows.Forms.DateTimePicker();
            this.button1 = new System.Windows.Forms.Button();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.D1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.D2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.D3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.D4 = new System.Windows.Forms.ToolStripButton();
            this.TimePickerAfter = new System.Windows.Forms.DateTimePicker();
            this.toolStrip1.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.B1,
            this.toolStripSeparator5,
            this.B2,
            this.toolStripSeparator4,
            this.B3,
            this.toolStripSeparator12,
            this.B4,
            this.toolStripSeparator11,
            this.B5,
            this.toolStripSeparator7,
            this.B6,
            this.toolStripSeparator10,
            this.B7,
            this.toolStripSeparator6,
            this.B8,
            this.toolStripSeparator8,
            this.B9,
            this.toolStripSeparator9,
            this.B10});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1298, 32);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(196, 29);
            this.toolStripLabel1.Text = "Выберите счетчики: ";
            // 
            // B1
            // 
            this.B1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.B1.Image = ((System.Drawing.Image)(resources.GetObject("B1.Image")));
            this.B1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.B1.Name = "B1";
            this.B1.Size = new System.Drawing.Size(97, 29);
            this.B1.Text = "Счетчик 1";
            this.B1.Click += new System.EventHandler(this.ButtonWork_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 32);
            // 
            // B2
            // 
            this.B2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.B2.Image = ((System.Drawing.Image)(resources.GetObject("B2.Image")));
            this.B2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.B2.Name = "B2";
            this.B2.Size = new System.Drawing.Size(97, 29);
            this.B2.Text = "Счетчик 2";
            this.B2.Click += new System.EventHandler(this.ButtonWork_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 32);
            // 
            // B3
            // 
            this.B3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.B3.Image = ((System.Drawing.Image)(resources.GetObject("B3.Image")));
            this.B3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.B3.Name = "B3";
            this.B3.Size = new System.Drawing.Size(97, 29);
            this.B3.Text = "Счетчик 3";
            this.B3.Click += new System.EventHandler(this.ButtonWork_Click);
            // 
            // toolStripSeparator12
            // 
            this.toolStripSeparator12.Name = "toolStripSeparator12";
            this.toolStripSeparator12.Size = new System.Drawing.Size(6, 32);
            // 
            // B4
            // 
            this.B4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.B4.Image = ((System.Drawing.Image)(resources.GetObject("B4.Image")));
            this.B4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.B4.Name = "B4";
            this.B4.Size = new System.Drawing.Size(97, 29);
            this.B4.Text = "Счетчик 4";
            this.B4.Click += new System.EventHandler(this.ButtonWork_Click);
            // 
            // toolStripSeparator11
            // 
            this.toolStripSeparator11.Name = "toolStripSeparator11";
            this.toolStripSeparator11.Size = new System.Drawing.Size(6, 32);
            // 
            // B5
            // 
            this.B5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.B5.Image = ((System.Drawing.Image)(resources.GetObject("B5.Image")));
            this.B5.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.B5.Name = "B5";
            this.B5.Size = new System.Drawing.Size(97, 29);
            this.B5.Text = "Счетчик 5";
            this.B5.Click += new System.EventHandler(this.ButtonWork_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 32);
            // 
            // B6
            // 
            this.B6.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.B6.Image = ((System.Drawing.Image)(resources.GetObject("B6.Image")));
            this.B6.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.B6.Name = "B6";
            this.B6.Size = new System.Drawing.Size(97, 29);
            this.B6.Text = "Счетчик 6";
            this.B6.Click += new System.EventHandler(this.ButtonWork_Click);
            // 
            // toolStripSeparator10
            // 
            this.toolStripSeparator10.Name = "toolStripSeparator10";
            this.toolStripSeparator10.Size = new System.Drawing.Size(6, 32);
            // 
            // B7
            // 
            this.B7.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.B7.Image = ((System.Drawing.Image)(resources.GetObject("B7.Image")));
            this.B7.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.B7.Name = "B7";
            this.B7.Size = new System.Drawing.Size(97, 29);
            this.B7.Text = "Счетчик 7";
            this.B7.Click += new System.EventHandler(this.ButtonWork_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 32);
            // 
            // B8
            // 
            this.B8.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.B8.Image = ((System.Drawing.Image)(resources.GetObject("B8.Image")));
            this.B8.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.B8.Name = "B8";
            this.B8.Size = new System.Drawing.Size(97, 29);
            this.B8.Text = "Счетчик 8";
            this.B8.Click += new System.EventHandler(this.ButtonWork_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(6, 32);
            // 
            // B9
            // 
            this.B9.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.B9.Image = ((System.Drawing.Image)(resources.GetObject("B9.Image")));
            this.B9.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.B9.Name = "B9";
            this.B9.Size = new System.Drawing.Size(97, 29);
            this.B9.Text = "Счетчик 9";
            this.B9.Click += new System.EventHandler(this.ButtonWork_Click);
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(6, 32);
            // 
            // B10
            // 
            this.B10.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.B10.Image = ((System.Drawing.Image)(resources.GetObject("B10.Image")));
            this.B10.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.B10.Name = "B10";
            this.B10.Size = new System.Drawing.Size(107, 29);
            this.B10.Text = "Счетчик 10";
            this.B10.Click += new System.EventHandler(this.ButtonWork_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(0, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(170, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Выберите дату:  C";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(380, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "по";
            // 
            // TimePickerBefore
            // 
            this.TimePickerBefore.CustomFormat = "dd/MM/yyyy HH:mm:ss";
            this.TimePickerBefore.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.TimePickerBefore.Location = new System.Drawing.Point(418, 39);
            this.TimePickerBefore.MinDate = new System.DateTime(2018, 4, 14, 0, 0, 0, 0);
            this.TimePickerBefore.Name = "TimePickerBefore";
            this.TimePickerBefore.ShowUpDown = true;
            this.TimePickerBefore.Size = new System.Drawing.Size(200, 31);
            this.TimePickerBefore.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(6, 119);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(102, 37);
            this.button1.TabIndex = 6;
            this.button1.Text = "Создать";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // toolStrip2
            // 
            this.toolStrip2.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip2.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel2,
            this.D1,
            this.toolStripSeparator1,
            this.D2,
            this.toolStripSeparator2,
            this.D3,
            this.toolStripSeparator3,
            this.D4});
            this.toolStrip2.Location = new System.Drawing.Point(0, 80);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(566, 32);
            this.toolStrip2.TabIndex = 5;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(178, 29);
            this.toolStripLabel2.Text = "Выберите данные:";
            // 
            // D1
            // 
            this.D1.BackColor = System.Drawing.Color.PaleGreen;
            this.D1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.D1.Image = ((System.Drawing.Image)(resources.GetObject("D1.Image")));
            this.D1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.D1.Name = "D1";
            this.D1.Size = new System.Drawing.Size(45, 29);
            this.D1.Text = "Ток";
            this.D1.Click += new System.EventHandler(this.DataSelected_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 32);
            // 
            // D2
            // 
            this.D2.BackColor = System.Drawing.Color.PaleGreen;
            this.D2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.D2.Image = ((System.Drawing.Image)(resources.GetObject("D2.Image")));
            this.D2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.D2.Name = "D2";
            this.D2.Size = new System.Drawing.Size(119, 29);
            this.D2.Text = "Напряжение";
            this.D2.Click += new System.EventHandler(this.DataSelected_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 32);
            // 
            // D3
            // 
            this.D3.BackColor = System.Drawing.Color.PaleGreen;
            this.D3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.D3.Image = ((System.Drawing.Image)(resources.GetObject("D3.Image")));
            this.D3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.D3.Name = "D3";
            this.D3.Size = new System.Drawing.Size(100, 29);
            this.D3.Text = "Косинус φ";
            this.D3.Click += new System.EventHandler(this.DataSelected_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 32);
            // 
            // D4
            // 
            this.D4.BackColor = System.Drawing.Color.PaleGreen;
            this.D4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.D4.Image = ((System.Drawing.Image)(resources.GetObject("D4.Image")));
            this.D4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.D4.Name = "D4";
            this.D4.Size = new System.Drawing.Size(103, 29);
            this.D4.Text = "Мощность";
            this.D4.Click += new System.EventHandler(this.DataSelected_Click);
            // 
            // TimePickerAfter
            // 
            this.TimePickerAfter.CustomFormat = "dd/MM/yyyy HH:mm:ss";
            this.TimePickerAfter.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.TimePickerAfter.Location = new System.Drawing.Point(174, 39);
            this.TimePickerAfter.MinDate = new System.DateTime(2018, 4, 14, 0, 0, 0, 0);
            this.TimePickerAfter.Name = "TimePickerAfter";
            this.TimePickerAfter.ShowUpDown = true;
            this.TimePickerAfter.Size = new System.Drawing.Size(200, 31);
            this.TimePickerAfter.TabIndex = 8;
            // 
            // CreateReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1298, 163);
            this.Controls.Add(this.TimePickerAfter);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.toolStrip2);
            this.Controls.Add(this.TimePickerBefore);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "CreateReportForm";
            this.Text = "Создать отчёт";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker TimePickerBefore;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripButton D2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton D1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton D3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton D4;
        private System.Windows.Forms.ToolStripButton B1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton B5;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripButton B4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripButton B10;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator12;
        private System.Windows.Forms.ToolStripButton B9;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator11;
        private System.Windows.Forms.ToolStripButton B8;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator10;
        private System.Windows.Forms.ToolStripButton B7;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        private System.Windows.Forms.ToolStripButton B6;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripButton B3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton B2;
        private System.Windows.Forms.DateTimePicker TimePickerAfter;
    }
}

