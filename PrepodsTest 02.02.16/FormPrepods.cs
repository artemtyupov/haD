using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PrepodsTest
{
    public partial class FormPrepods : Form
    {
        Connector myCon = new Connector();

        public FormPrepods()
        {
            InitializeComponent();
        }
        DateTime crrr;
        private void dtPickerBirthday_ValueChanged(object sender, EventArgs e)
        {
            DateTime cur = dtPickerBirthday.Value;
            crrr = cur;
        }

        private void buttonInsert_Click(object sender, EventArgs e)
        {
            myCon.Initialize();

            string fio = textBoxFio.Text;
            string snils = textBoxSnils.Text;
            DateTime datetime = dtPickerBirthday.Value;
            string bday1 = datetime.ToString("yyyy-MM-dd-HH-mm-ss");
            string bday = datetime.ToString("yyyy-MM-dd");
            string mobno = textBoxMobNo.Text;
            //var parts1 = fio.Split(' ');
            string[] parts = fio.Split(' ');
            int len = parts.Length;
            string fioShort = "";
            if (len == 3)
            {
                fioShort = parts[0] + " " + parts[1][0] + ". " + parts[2][0] + ".";
            }
            else if (len == 2)
            {
                fioShort = parts[0] + " " + parts[1][0] + ". ";
            }
            else 
            {
                fioShort = fio;
            }
            myCon.InsertPrepod(fio, fioShort, mobno, bday);
        }

        private void FormPrepods_Load(object sender, EventArgs e)
        {

        }
    }
}
