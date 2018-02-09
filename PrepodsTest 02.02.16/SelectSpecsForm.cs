/*
 * Created by SharpDevelop.
 * User: kornout
 * Date: 27.11.2015
 * Time: 19:28
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;

using System.Collections.Generic;
namespace PrepodsTest
{
	/// <summary>
	/// Description of FormSpecs.
	/// </summary>
	public partial class SelectSpecsForm : Form
	{
        Connector myCon = new Connector();
		public string idPrepod;
		public SelectSpecsForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
            checkboxesList = new List<CheckBox>();
            _valuesWithId = new Dictionary<string, string>();
            btnOk = new Button();
            //button
            this.btnOk.Location = new System.Drawing.Point(this.Width-100, this.Height-90);
            this.btnOk.Name = "buttonOK";
            this.btnOk.Size = new System.Drawing.Size(80, 40);
            this.btnOk.TabIndex = 7;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.buttonOk_Click);

            this.btnOk.Anchor = (System.Windows.Forms.AnchorStyles)( (System.Windows.Forms.AnchorStyles.Bottom)  | (System.Windows.Forms.AnchorStyles.Right) );
            //FORM
            this.Controls.Add(this.btnOk);
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
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
            List<string> idSpecsChecked = new List<string>();
            List<string> idSpecsNOTChecked = new List<string>();
            foreach (var checkboxCur in checkboxesList)
            {
                if (checkboxCur.Checked)
                {
                    string idSpec = findKeyByValue(_valuesWithId, checkboxCur.Text);
                    idSpecsChecked.Add(idSpec);

                }
                else
                {
                    string idSpec = findKeyByValue(_valuesWithId, checkboxCur.Text);
                    idSpecsNOTChecked.Add(idSpec);

                }
            }
            //selectTOGrid();
            myCon.Initialize();
            foreach (var idspecNotCHecked in idSpecsNOTChecked)
            {
                myCon.DeletePrepodsSpecIfExist(idPrepod, idspecNotCHecked);

            }
            foreach (var idspec in idSpecsChecked)
            {
                myCon.InsertPrepodsSpec(idPrepod, idspec);
                
            }
            Close();
        }
        Button btnOk = new Button();
        Dictionary<string, string> _valuesWithId;
        List<CheckBox> checkboxesList = new List<CheckBox>();
        public void addBoxes(Dictionary<string, string> valuesWithId)
		{
            _valuesWithId = valuesWithId;
			this.ClientSize = new System.Drawing.Size(384,240);
			int y=20;
			int x=0;
            myCon.Initialize();
            List<string> specsForPrepod = myCon.SelectIdSpecsForPrepod(idPrepod);
            foreach (var pair in valuesWithId) 
			{
				var checkBox1 = new System.Windows.Forms.CheckBox();
				// 
				// checkBox1
				// 
				checkBox1.Location = new System.Drawing.Point(39, y);
				checkBox1.Name = "checkBox1"+x.ToString();
				checkBox1.Size = new System.Drawing.Size(204, 25);
				checkBox1.TabIndex = 0;
				checkBox1.Text = pair.Value;
				checkBox1.UseVisualStyleBackColor = true;
                string curID = pair.Key;
                bool isSpecForPrepod = specsForPrepod.Contains(curID);
                checkBox1.Checked = isSpecForPrepod;
				// 
				this.Controls.Add(checkBox1);
                checkboxesList.Add(checkBox1);
				y=y+30;
				x++;
				//this.ClientSize = new System.Drawing.Size(284, 262);
				if (y>240)
				{
					this.ClientSize = new System.Drawing.Size(384, y+20);
				}
				//Screen.PrimaryScreen.WorkingArea.Width
			}

            //this.btnOk.Location = new System.Drawing.Point(this.Width - 130, this.Height - 80);
			
			
		}

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
		
	}
}
