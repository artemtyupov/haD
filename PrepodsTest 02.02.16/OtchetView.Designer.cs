namespace PrepodsTest
{
    partial class OtchetView
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.buttonPrint = new System.Windows.Forms.Button();
            this.buttonToExcel = new System.Windows.Forms.Button();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.buttonPreview = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.buttonFilterDates = new System.Windows.Forms.Button();
            this.comboBoxSpecs = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBoxPrepods1 = new System.Windows.Forms.ComboBox();
            this.comboBoxPrepods = new System.Windows.Forms.ComboBox();
            this.comboBoxKlasses = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 116);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(757, 441);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // buttonPrint
            // 
            this.buttonPrint.Location = new System.Drawing.Point(775, 423);
            this.buttonPrint.Name = "buttonPrint";
            this.buttonPrint.Size = new System.Drawing.Size(114, 28);
            this.buttonPrint.TabIndex = 1;
            this.buttonPrint.Text = "Печать";
            this.buttonPrint.UseVisualStyleBackColor = true;
            this.buttonPrint.Click += new System.EventHandler(this.buttonPrint_Click);
            // 
            // buttonToExcel
            // 
            this.buttonToExcel.Location = new System.Drawing.Point(778, 457);
            this.buttonToExcel.Name = "buttonToExcel";
            this.buttonToExcel.Size = new System.Drawing.Size(111, 28);
            this.buttonToExcel.TabIndex = 2;
            this.buttonToExcel.Text = "Ексель экспорт";
            this.buttonToExcel.UseVisualStyleBackColor = true;
            this.buttonToExcel.Click += new System.EventHandler(this.buttonToExcel_Click);
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // buttonPreview
            // 
            this.buttonPreview.Location = new System.Drawing.Point(775, 389);
            this.buttonPreview.Name = "buttonPreview";
            this.buttonPreview.Size = new System.Drawing.Size(114, 28);
            this.buttonPreview.TabIndex = 3;
            this.buttonPreview.Text = "Предпросмотр";
            this.buttonPreview.UseVisualStyleBackColor = true;
            this.buttonPreview.Click += new System.EventHandler(this.buttonPreview_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dateTimePicker2);
            this.groupBox1.Controls.Add(this.dateTimePicker1);
            this.groupBox1.Location = new System.Drawing.Point(15, 36);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(377, 59);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Промежуток времени";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "С:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(171, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "ПО:";
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(203, 25);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(140, 20);
            this.dateTimePicker2.TabIndex = 1;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(36, 26);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(130, 20);
            this.dateTimePicker1.TabIndex = 0;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // buttonFilterDates
            // 
            this.buttonFilterDates.Location = new System.Drawing.Point(778, 240);
            this.buttonFilterDates.Name = "buttonFilterDates";
            this.buttonFilterDates.Size = new System.Drawing.Size(75, 53);
            this.buttonFilterDates.TabIndex = 4;
            this.buttonFilterDates.Text = "Фильтр";
            this.buttonFilterDates.UseVisualStyleBackColor = true;
            this.buttonFilterDates.Click += new System.EventHandler(this.buttonFilterDates_Click);
            // 
            // comboBoxSpecs
            // 
            this.comboBoxSpecs.FormattingEnabled = true;
            this.comboBoxSpecs.Location = new System.Drawing.Point(778, 199);
            this.comboBoxSpecs.Name = "comboBoxSpecs";
            this.comboBoxSpecs.Size = new System.Drawing.Size(175, 21);
            this.comboBoxSpecs.TabIndex = 8;
            this.comboBoxSpecs.SelectedIndexChanged += new System.EventHandler(this.comboBoxSpecs_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(775, 174);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Специализации";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 8);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "Фильтры:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(398, 38);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(152, 13);
            this.label7.TabIndex = 17;
            this.label7.Text = "Замененный преподаватель";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(678, 38);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(155, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "Заменяющий преподаватель";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(772, 116);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 13);
            this.label5.TabIndex = 19;
            this.label5.Text = "Класс";
            // 
            // comboBoxPrepods1
            // 
            this.comboBoxPrepods1.FormattingEnabled = true;
            this.comboBoxPrepods1.Location = new System.Drawing.Point(398, 66);
            this.comboBoxPrepods1.Name = "comboBoxPrepods1";
            this.comboBoxPrepods1.Size = new System.Drawing.Size(258, 21);
            this.comboBoxPrepods1.TabIndex = 20;
            // 
            // comboBoxPrepods
            // 
            this.comboBoxPrepods.FormattingEnabled = true;
            this.comboBoxPrepods.Location = new System.Drawing.Point(681, 66);
            this.comboBoxPrepods.Name = "comboBoxPrepods";
            this.comboBoxPrepods.Size = new System.Drawing.Size(247, 21);
            this.comboBoxPrepods.TabIndex = 21;
            this.comboBoxPrepods.SelectedIndexChanged += new System.EventHandler(this.comboBoxPrepods_SelectedIndexChanged);
            // 
            // comboBoxKlasses
            // 
            this.comboBoxKlasses.FormattingEnabled = true;
            this.comboBoxKlasses.Location = new System.Drawing.Point(775, 141);
            this.comboBoxKlasses.Name = "comboBoxKlasses";
            this.comboBoxKlasses.Size = new System.Drawing.Size(129, 21);
            this.comboBoxKlasses.TabIndex = 22;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(874, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 23;
            this.button1.Text = "Назад";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(775, 373);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(43, 13);
            this.label8.TabIndex = 24;
            this.label8.Text = "Вывод:";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(859, 240);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 53);
            this.button2.TabIndex = 25;
            this.button2.Text = "Сброс фльтров";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // OtchetView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(961, 569);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.comboBoxKlasses);
            this.Controls.Add(this.comboBoxPrepods);
            this.Controls.Add(this.comboBoxPrepods1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.buttonFilterDates);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBoxSpecs);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.buttonPreview);
            this.Controls.Add(this.buttonToExcel);
            this.Controls.Add(this.buttonPrint);
            this.Controls.Add(this.dataGridView1);
            this.Name = "OtchetView";
            this.Text = "Вывод отчета";
            this.Load += new System.EventHandler(this.OtchetView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button buttonPrint;
        private System.Windows.Forms.Button buttonToExcel;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.Button buttonPreview;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonFilterDates;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.ComboBox comboBoxSpecs;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBoxPrepods1;
        private System.Windows.Forms.ComboBox comboBoxPrepods;
        private System.Windows.Forms.ComboBox comboBoxKlasses;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button2;
    }
}