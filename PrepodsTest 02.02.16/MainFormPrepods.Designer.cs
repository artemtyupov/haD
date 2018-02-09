namespace PrepodsTest
{
    partial class MainFormPrepods
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
            this.buttonSpec = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FioFull = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FioShort = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MobNomer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Birthday = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Specs = new System.Windows.Forms.DataGridViewButtonColumn();
            this.buttonSelectToGrid = new System.Windows.Forms.Button();
            this.buttonKlasses = new System.Windows.Forms.Button();
            this.buttonRooms = new System.Windows.Forms.Button();
            this.buttonSchedule = new System.Windows.Forms.Button();
            this.buttonReplaceForm = new System.Windows.Forms.Button();
            this.buttonOtchet = new System.Windows.Forms.Button();
            this.CreateTables = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonSpec
            // 
            this.buttonSpec.Location = new System.Drawing.Point(6, 19);
            this.buttonSpec.Name = "buttonSpec";
            this.buttonSpec.Size = new System.Drawing.Size(129, 23);
            this.buttonSpec.TabIndex = 7;
            this.buttonSpec.Text = "Специализации";
            this.buttonSpec.UseVisualStyleBackColor = true;
            this.buttonSpec.Click += new System.EventHandler(this.buttonSpec_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(35, 189);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(923, 528);
            this.dataGridView1.TabIndex = 8;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView1CellEndEdit);
            this.dataGridView1.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView1CellValueChanged);
            this.dataGridView1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.dataGridView1_KeyUp);
            // 
            // id
            // 
            this.id.HeaderText = "id";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            // 
            // FioFull
            // 
            this.FioFull.HeaderText = "ФИО";
            this.FioFull.Name = "FioFull";
            // 
            // FioShort
            // 
            this.FioShort.HeaderText = "Имя";
            this.FioShort.Name = "FioShort";
            this.FioShort.ReadOnly = true;
            // 
            // MobNomer
            // 
            this.MobNomer.HeaderText = "Мобильный";
            this.MobNomer.Name = "MobNomer";
            // 
            // Birthday
            // 
            this.Birthday.HeaderText = "Дата рождения";
            this.Birthday.Name = "Birthday";
            // 
            // Specs
            // 
            this.Specs.HeaderText = "specs";
            this.Specs.Name = "Specs";
            this.Specs.Text = "red";
            this.Specs.ToolTipText = "red";
            this.Specs.UseColumnTextForButtonValue = true;
            // 
            // buttonSelectToGrid
            // 
            this.buttonSelectToGrid.Location = new System.Drawing.Point(6, 106);
            this.buttonSelectToGrid.Name = "buttonSelectToGrid";
            this.buttonSelectToGrid.Size = new System.Drawing.Size(129, 23);
            this.buttonSelectToGrid.TabIndex = 9;
            this.buttonSelectToGrid.Text = "Преподаватели";
            this.buttonSelectToGrid.UseVisualStyleBackColor = true;
            this.buttonSelectToGrid.Click += new System.EventHandler(this.ButtonSelectToGridClick);
            // 
            // buttonKlasses
            // 
            this.buttonKlasses.Location = new System.Drawing.Point(6, 48);
            this.buttonKlasses.Name = "buttonKlasses";
            this.buttonKlasses.Size = new System.Drawing.Size(129, 23);
            this.buttonKlasses.TabIndex = 12;
            this.buttonKlasses.Text = "Классы";
            this.buttonKlasses.UseVisualStyleBackColor = true;
            this.buttonKlasses.Click += new System.EventHandler(this.buttonKlasses_Click);
            // 
            // buttonRooms
            // 
            this.buttonRooms.Location = new System.Drawing.Point(6, 77);
            this.buttonRooms.Name = "buttonRooms";
            this.buttonRooms.Size = new System.Drawing.Size(129, 23);
            this.buttonRooms.TabIndex = 13;
            this.buttonRooms.Text = "Аудитории";
            this.buttonRooms.UseVisualStyleBackColor = true;
            this.buttonRooms.Click += new System.EventHandler(this.buttonRooms_Click);
            // 
            // buttonSchedule
            // 
            this.buttonSchedule.Location = new System.Drawing.Point(6, 135);
            this.buttonSchedule.Name = "buttonSchedule";
            this.buttonSchedule.Size = new System.Drawing.Size(129, 23);
            this.buttonSchedule.TabIndex = 14;
            this.buttonSchedule.Text = "Расписание";
            this.buttonSchedule.UseVisualStyleBackColor = true;
            this.buttonSchedule.Click += new System.EventHandler(this.buttonSchedule_Click);
            // 
            // buttonReplaceForm
            // 
            this.buttonReplaceForm.Location = new System.Drawing.Point(6, 19);
            this.buttonReplaceForm.Name = "buttonReplaceForm";
            this.buttonReplaceForm.Size = new System.Drawing.Size(112, 23);
            this.buttonReplaceForm.TabIndex = 15;
            this.buttonReplaceForm.Text = "Замена";
            this.buttonReplaceForm.UseVisualStyleBackColor = true;
            this.buttonReplaceForm.Click += new System.EventHandler(this.buttonReplaceForm_Click);
            // 
            // buttonOtchet
            // 
            this.buttonOtchet.Location = new System.Drawing.Point(6, 48);
            this.buttonOtchet.Name = "buttonOtchet";
            this.buttonOtchet.Size = new System.Drawing.Size(112, 23);
            this.buttonOtchet.TabIndex = 16;
            this.buttonOtchet.Text = "Отчет";
            this.buttonOtchet.UseVisualStyleBackColor = true;
            this.buttonOtchet.Click += new System.EventHandler(this.buttonOtchet_Click);
            // 
            // CreateTables
            // 
            this.CreateTables.Location = new System.Drawing.Point(6, 67);
            this.CreateTables.Name = "CreateTables";
            this.CreateTables.Size = new System.Drawing.Size(120, 23);
            this.CreateTables.TabIndex = 17;
            this.CreateTables.Text = "Создание таблиц";
            this.CreateTables.UseVisualStyleBackColor = true;
            this.CreateTables.Click += new System.EventHandler(this.CreateTables_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(6, 96);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(120, 45);
            this.button1.TabIndex = 18;
            this.button1.Text = "Поменять данные о сервере";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonSpec);
            this.groupBox1.Controls.Add(this.buttonKlasses);
            this.groupBox1.Controls.Add(this.buttonRooms);
            this.groupBox1.Controls.Add(this.buttonSelectToGrid);
            this.groupBox1.Controls.Add(this.buttonSchedule);
            this.groupBox1.Location = new System.Drawing.Point(399, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(148, 171);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Этап 2.";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Controls.Add(this.CreateTables);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Location = new System.Drawing.Point(86, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(148, 171);
            this.groupBox2.TabIndex = 20;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Этап 1.";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.buttonReplaceForm);
            this.groupBox3.Controls.Add(this.buttonOtchet);
            this.groupBox3.Location = new System.Drawing.Point(714, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(148, 171);
            this.groupBox3.TabIndex = 21;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Этап 3.";
            this.groupBox3.Enter += new System.EventHandler(this.groupBox3_Enter);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(6, 19);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(120, 42);
            this.button2.TabIndex = 22;
            this.button2.Text = "Инструкция";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // MainFormPrepods
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 729);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "MainFormPrepods";
            this.Text = "Главное меню";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonSpec;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn FioFull;
        private System.Windows.Forms.DataGridViewTextBoxColumn FioShort;
        private System.Windows.Forms.DataGridViewTextBoxColumn MobNomer;
        private System.Windows.Forms.DataGridViewTextBoxColumn Birthday;
        private System.Windows.Forms.Button buttonSelectToGrid;
        private System.Windows.Forms.DataGridViewButtonColumn Specs;
        private System.Windows.Forms.Button buttonKlasses;
        private System.Windows.Forms.Button buttonRooms;
        private System.Windows.Forms.Button buttonSchedule;
        private System.Windows.Forms.Button buttonReplaceForm;
        private System.Windows.Forms.Button buttonOtchet;
        private System.Windows.Forms.Button CreateTables;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button button2;
    }
}

