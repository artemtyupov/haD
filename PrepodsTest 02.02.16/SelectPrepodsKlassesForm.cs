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
    public partial class SelectPrepodsKlassesForm : Form
    {
        Connector myCon = new Connector();
        Button btnOk = new Button();
        Dictionary<string, string> _valuesWithId;
        List<CheckBox> checkboxesList = new List<CheckBox>();
        public string idPrepod;
        public SelectPrepodsKlassesForm()
        {
            InitializeComponent();
            checkboxesList = new List<CheckBox>();
            _valuesWithId = new Dictionary<string, string>();
            btnOk = new Button();
            //button
            this.btnOk.Location = new System.Drawing.Point(this.Width - 100, this.Height - 90);
            this.btnOk.Name = "buttonOK";
            this.btnOk.Size = new System.Drawing.Size(80, 40);
            this.btnOk.TabIndex = 7;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.buttonOk_Click);

            this.btnOk.Anchor = (System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom) | (System.Windows.Forms.AnchorStyles.Right));
            //FORM
            this.Controls.Add(this.btnOk);
        }

        internal void addBoxes(Dictionary<string, string> prepodsKlasses)
        {
            _valuesWithId = prepodsKlasses;
            this.ClientSize = new System.Drawing.Size(400, 240);
            int y = 20;
            int x = 0;
            myCon.Initialize();
            List<string> klassesForPrepod = myCon.SelectIdKlassesForPrepod(idPrepod);
            foreach (var pair in prepodsKlasses)
            {
                var checkBox1 = new System.Windows.Forms.CheckBox();
                // 
                // checkBox1
                // 
                checkBox1.Location = new System.Drawing.Point(39, y);
                checkBox1.Name = "checkBox1" + x.ToString();
                checkBox1.Size = new System.Drawing.Size(300, 25);
                checkBox1.TabIndex = 0;
                checkBox1.Text = pair.Value;
                checkBox1.UseVisualStyleBackColor = true;
                string curID = pair.Key;
                bool isklassForPrepod = klassesForPrepod.Contains(curID);
                checkBox1.Checked = isklassForPrepod;
                // 
                this.Controls.Add(checkBox1);
                checkboxesList.Add(checkBox1);
                y = y + 30;
                x++;
                //this.ClientSize = new System.Drawing.Size(284, 262);
                if (y > 240)
                {
                    this.ClientSize = new System.Drawing.Size(400, y + 20);
                }
                //Screen.PrimaryScreen.WorkingArea.Width
            }
        }
        string findKeyByValue(Dictionary<string, string> dict, string val)
        {
            foreach (var item in dict)
            {
                if (item.Value == val)
                {
                    return item.Key;
                }

            }

            return "";
        }
        void buttonOk_Click(object sender, EventArgs e)
        {
            List<string> idKlassesChecked = new List<string>();
            List<string> idKlassesNOTChecked = new List<string>();
            foreach (var checkboxCur in checkboxesList)
            {
                if (checkboxCur.Checked)
                {
                    string idSpec = findKeyByValue(_valuesWithId, checkboxCur.Text);
                    idKlassesChecked.Add(idSpec);

                }
                else
                {
                    string idSpec = findKeyByValue(_valuesWithId, checkboxCur.Text);
                    idKlassesNOTChecked.Add(idSpec);

                }
            }
            //selectTOGrid();
            myCon.Initialize();
            foreach (var idKlassNot in idKlassesNOTChecked)
            {
                myCon.DeletePrepodsKlassIfExist(idPrepod, idKlassNot);

            }
            foreach (var idKlass in idKlassesChecked)
            {
                myCon.InsertPrepodsKlass(idPrepod, idKlass);

            }
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
