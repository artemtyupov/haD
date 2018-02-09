namespace PrepodsTest
{
    partial class FormPrepods
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
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxFio = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxMobNo = new System.Windows.Forms.TextBox();
            this.dtPickerBirthday = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxSnils = new System.Windows.Forms.TextBox();
            this.buttonInsert = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "FIO";
            // 
            // textBoxFio
            // 
            this.textBoxFio.Location = new System.Drawing.Point(78, 25);
            this.textBoxFio.Name = "textBoxFio";
            this.textBoxFio.Size = new System.Drawing.Size(244, 20);
            this.textBoxFio.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "mob no";
            // 
            // textBoxMobNo
            // 
            this.textBoxMobNo.Location = new System.Drawing.Point(78, 58);
            this.textBoxMobNo.Name = "textBoxMobNo";
            this.textBoxMobNo.Size = new System.Drawing.Size(244, 20);
            this.textBoxMobNo.TabIndex = 3;
            // 
            // dtPickerBirthday
            // 
            this.dtPickerBirthday.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtPickerBirthday.Location = new System.Drawing.Point(78, 99);
            this.dtPickerBirthday.Name = "dtPickerBirthday";
            this.dtPickerBirthday.ShowUpDown = true;
            this.dtPickerBirthday.Size = new System.Drawing.Size(200, 20);
            this.dtPickerBirthday.TabIndex = 4;
            this.dtPickerBirthday.ValueChanged += new System.EventHandler(this.dtPickerBirthday_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "birthday";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 138);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(27, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "snils";
            // 
            // textBoxSnils
            // 
            this.textBoxSnils.Location = new System.Drawing.Point(78, 138);
            this.textBoxSnils.Name = "textBoxSnils";
            this.textBoxSnils.Size = new System.Drawing.Size(244, 20);
            this.textBoxSnils.TabIndex = 7;
            // 
            // buttonInsert
            // 
            this.buttonInsert.Location = new System.Drawing.Point(13, 178);
            this.buttonInsert.Name = "buttonInsert";
            this.buttonInsert.Size = new System.Drawing.Size(309, 23);
            this.buttonInsert.TabIndex = 8;
            this.buttonInsert.Text = "insert";
            this.buttonInsert.UseVisualStyleBackColor = true;
            this.buttonInsert.Click += new System.EventHandler(this.buttonInsert_Click);
            // 
            // FormPrepods
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(479, 575);
            this.Controls.Add(this.buttonInsert);
            this.Controls.Add(this.textBoxSnils);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dtPickerBirthday);
            this.Controls.Add(this.textBoxMobNo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxFio);
            this.Controls.Add(this.label1);
            this.Name = "FormPrepods";
            this.Text = "FormPrepods";
            this.Load += new System.EventHandler(this.FormPrepods_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxFio;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxMobNo;
        private System.Windows.Forms.DateTimePicker dtPickerBirthday;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxSnils;
        private System.Windows.Forms.Button buttonInsert;
    }
}