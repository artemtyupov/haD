namespace PrepodsTest
{
    partial class ReplaceForm
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
            this.buttonReplace = new System.Windows.Forms.Button();
            this.textBoxNumDay = new System.Windows.Forms.TextBox();
            this.comboBoxprepodReplace = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonFillOthcet = new System.Windows.Forms.Button();
            this.checkBoxEvenWeek = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(46, 103);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(792, 262);
            this.dataGridView1.TabIndex = 0;
            // 
            // buttonReplace
            // 
            this.buttonReplace.Location = new System.Drawing.Point(46, 65);
            this.buttonReplace.Name = "buttonReplace";
            this.buttonReplace.Size = new System.Drawing.Size(145, 23);
            this.buttonReplace.TabIndex = 1;
            this.buttonReplace.Text = "Подобрать замены";
            this.buttonReplace.UseVisualStyleBackColor = true;
            this.buttonReplace.Click += new System.EventHandler(this.buttonReplace_Click);
            // 
            // textBoxNumDay
            // 
            this.textBoxNumDay.Location = new System.Drawing.Point(46, 39);
            this.textBoxNumDay.Name = "textBoxNumDay";
            this.textBoxNumDay.Size = new System.Drawing.Size(100, 20);
            this.textBoxNumDay.TabIndex = 2;
            // 
            // comboBoxprepodReplace
            // 
            this.comboBoxprepodReplace.FormattingEnabled = true;
            this.comboBoxprepodReplace.Location = new System.Drawing.Point(282, 39);
            this.comboBoxprepodReplace.Name = "comboBoxprepodReplace";
            this.comboBoxprepodReplace.Size = new System.Drawing.Size(416, 21);
            this.comboBoxprepodReplace.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(46, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Номер дня ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(279, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(196, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Преподаватель, которого заменяем:";
            // 
            // buttonFillOthcet
            // 
            this.buttonFillOthcet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonFillOthcet.Location = new System.Drawing.Point(552, 66);
            this.buttonFillOthcet.Name = "buttonFillOthcet";
            this.buttonFillOthcet.Size = new System.Drawing.Size(286, 23);
            this.buttonFillOthcet.TabIndex = 6;
            this.buttonFillOthcet.Text = "Записать выбранные замены для отчета";
            this.buttonFillOthcet.UseVisualStyleBackColor = true;
            this.buttonFillOthcet.Click += new System.EventHandler(this.buttonFillOthcet_Click);
            // 
            // checkBoxEvenWeek
            // 
            this.checkBoxEvenWeek.AutoSize = true;
            this.checkBoxEvenWeek.Location = new System.Drawing.Point(164, 41);
            this.checkBoxEvenWeek.Name = "checkBoxEvenWeek";
            this.checkBoxEvenWeek.Size = new System.Drawing.Size(99, 17);
            this.checkBoxEvenWeek.TabIndex = 7;
            this.checkBoxEvenWeek.Text = "четная неделя";
            this.checkBoxEvenWeek.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(778, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 24;
            this.button1.Text = "Назад";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ReplaceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(865, 377);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.checkBoxEvenWeek);
            this.Controls.Add(this.buttonFillOthcet);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxprepodReplace);
            this.Controls.Add(this.textBoxNumDay);
            this.Controls.Add(this.buttonReplace);
            this.Controls.Add(this.dataGridView1);
            this.Name = "ReplaceForm";
            this.Text = "Выполнение замены";
            this.Load += new System.EventHandler(this.ReplaceForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button buttonReplace;
        private System.Windows.Forms.TextBox textBoxNumDay;
        private System.Windows.Forms.ComboBox comboBoxprepodReplace;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonFillOthcet;
        private System.Windows.Forms.CheckBox checkBoxEvenWeek;
        private System.Windows.Forms.Button button1;
    }
}