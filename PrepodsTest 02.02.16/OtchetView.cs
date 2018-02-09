using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace PrepodsTest
{
    public partial class OtchetView : Form
    {
        Connector myCon = new Connector();
        private System.Windows.Forms.DataGridViewComboBoxColumn listKlasses;
        private System.Windows.Forms.DataGridViewComboBoxColumn listPrepods;
        private System.Windows.Forms.DataGridViewComboBoxColumn listRooms;
        private System.Windows.Forms.DataGridViewComboBoxColumn listSpecs;
        public OtchetView()
        {
            InitializeComponent();
        }
        bool filterDate = false;
        bool filterSpec = false;
        DateTime dateBegin;
        DateTime dateEnd;
        int _F_idSpec = 0;
        int _F_idPrep = 0;
        int _F_idKlass = 0;
        int _F_idPrep1 = 0;
        private void selectToGrid()
        {
            myCon.Initialize();
            dataGridView1.DataSource = null;
            //dataGridView1.Dispose();
            string db = "";
            string de = "";
            string idSpecs = "";
            string idPrep = "";
            string idKlass = "";
            string idPrep1 = "";
            if (filterDate && dateBegin != null && dateEnd != null)
            {
                db = dateBegin.ToString("yyyy-MM-dd");
                de = dateEnd.ToString("yyyy-MM-dd");
            }
            if (_F_idSpec != 0)
            {
                idSpecs = _F_idSpec.ToString();
            }
            if (_F_idPrep != 0)
            {
                idPrep = _F_idPrep.ToString();
            }
            if (_F_idPrep1 != 0)
            {
                idPrep1 = _F_idPrep1.ToString();
            }
            if (_F_idKlass != 0)
            {
                idKlass = _F_idKlass.ToString();
            }
            BindingSource bSource;
            if (disablefilter == false)
                bSource = myCon.SelectOtchetToGrid(db, de, idSpecs, idPrep, idKlass, idPrep1);
            else
                bSource = myCon.SelectOtchetToGrid("", "", "", "","","");
            
            dataGridView1.DataSource = bSource;
            //dataGridView1.Columns.
            foreach (DataGridViewColumn col in dataGridView1.Columns)
            {
                string name = col.Name;
                string ht = col.HeaderText;
                if (ht == "id" || name == "idKlass" || name == "count" || name == "idSpec" || name == "idPrepod" || name == "idRoom" || name == "isSubGroup" || name == "numSubGroup" || name == "idReplacedPrepod")
                {
                    col.ReadOnly = true;
                    col.Visible = false;
                }
                if (name == "DateReplace")
                {
                    col.HeaderText = "Дата замены";
                    col.Width = 65;
                }
                if (name == "numDayOfWeek")
                {
                    col.HeaderText = "№ дня замены";
                    col.Width = 30;
                }
                if (name == "klassnameyear")
                {
                    col.HeaderText = "Класс";
                }
                if (name == "prepodFIO")
                {
                    col.HeaderText = "ФИО на замене";
                    col.Width = 150;
                }
                if (name == "replacedFIO")
                {
                    col.HeaderText = "ФИО замененного";
                    col.Width = 150;
                }
                if (name == "SpecName")
                {
                    col.HeaderText = "Специализация";
                    col.Width = 150;
                }
                if (name == "RoomName")
                {
                    col.HeaderText = "Аудитория №";
                    col.Width = 70;
                }

                col.ReadOnly = true;
                //MessageBox.Show(name+"  ht="+ht);
            }
        }
        Dictionary<string, string> specsL;
        Dictionary<string, string> prepodsL;
        Dictionary<string, string> klassesL;
        Dictionary<string, string> prepods1L;
        private void OtchetView_Load(object sender, EventArgs e)
        {
            
            selectToGrid();

            // Retrieve the working rectangle from the Screen class
            // using the PrimaryScreen and the WorkingArea properties.
            System.Drawing.Rectangle workingRectangle =
                Screen.PrimaryScreen.WorkingArea;

            // Set the size of the form slightly less than size of 
            // working rectangle.
            this.Size = new System.Drawing.Size(
                workingRectangle.Width - 10, workingRectangle.Height - 10);

            // Set the location so the entire form is visible.
            this.Location = new System.Drawing.Point(5, 5);

            //get specs
            myCon.Initialize();
            List<GridSpecs> specs = myCon.SelectSpecsToCheckboxes();

            specsL = new Dictionary<string, string>();
            this.comboBoxSpecs.Items.AddRange(new object[] { "---" });
            foreach (var spec in specs)
            {
                string specName = " " + spec.name + " ("  + spec.course + ")" + " (" + spec.semester + ")" ;
                this.comboBoxSpecs.Items.AddRange(new object[] { specName });
                specsL.Add(spec.ID.ToString(), specName);
            }


            //get prepods
            myCon.Initialize();
            List<GridPrepods> prepods = myCon.SelectPrepodsToGrid();
            prepodsL = new Dictionary<string, string>();
            this.comboBoxPrepods.Items.AddRange(new object[] { "---" });
            foreach (var prep in prepods)
            {
                string prepName = " " + prep.FioFull;
                this.comboBoxPrepods.Items.AddRange(new object[] { prepName });
                prepodsL.Add(prep.ID.ToString(), prepName);
            }


            //get klasses
            myCon.Initialize();
            List<GridKlasses> klasses = myCon.SelectKlassesToCheckboxes();
            klassesL = new Dictionary<string, string>();
            this.comboBoxKlasses.Items.AddRange(new object[] { "---" });
            foreach (var klass in klasses)
            {
                string klassName = " " + klass.name + " (" + klass.yearofstudy + ")"  ;
                this.comboBoxKlasses.Items.AddRange(new object[] { klassName });
                klassesL.Add(klass.ID.ToString(), klassName);
            }

            //get prepods1
            myCon.Initialize();
            List<GridPrepodsReplace> prepods1 = myCon.SelectPrepodsReplaceToGrid();
            prepods1L = new Dictionary<string, string>();
            this.comboBoxPrepods1.Items.AddRange(new object[] { "---" });
            foreach (var prep1 in prepods1)
            {
                string prep1Name = " " + prep1.FioFull;
                this.comboBoxPrepods1.Items.AddRange(new object[] { prep1Name });
                prepods1L.Add(prep1.ID.ToString(), prep1Name);
            }


        }

        private void buttonPrint_Click(object sender, EventArgs e)
        {


            PrintDialog printDialog1 = new PrintDialog();
            printDialog1.Document = printDocument1;
            DialogResult result1 = printDialog1.ShowDialog();
            if (result1 == DialogResult.OK)
            {
                printDocument1.Print();
            } 
            
           
        }
        private string DayName(int daynumber)
        {
            string ret = "";
            switch (daynumber)
            {
                case 1: ret = "понедельник"; break;
                case 2: ret = "вторник"; break;
                case 3: ret = "среда"; break;
                case 4: ret = "четверг"; break;
                case 5: ret = "пятница"; break;
                case 6: ret = "суббота"; break;
                case 7: ret = "воскресенье"; break;
                default: ret = "неизвестно";
                    break;
            }

            return ret;
        }
        private void buttonToExcel_Click(object sender, EventArgs e)
        {
            
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "csv files (*.csv)|*.csv";
            
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string path = saveFileDialog1.FileName;
                //encoding
                StreamWriter sw = new StreamWriter(path, true, Encoding.GetEncoding(1251));//File.AppendText(path);
                sw.WriteLine("Дата замены; Номер дня недели; день недели; Класс; Фио на замене; ФИО замененного; специальность; аудитория;");

                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    for (int j = 0; j < dataGridView1.Columns.Count; j++)
                    {
                        var col = dataGridView1.Columns[j];
                        string name = col.Name;
                        string ht = col.HeaderText;
                        if (ht == "id" || name == "idKlass" || name == "count" || name == "idSpec" || name == "idPrepod" || name == "idRoom" || name == "isSubGroup" || name == "numSubGroup" || name == "idReplacedPrepod")
                        {
                            continue;
                        }
                        if (dataGridView1.Rows[i].Cells[j].Value != null)
                        {
                            string toFile = dataGridView1.Rows[i].Cells[j].Value.ToString();
                            if (ht == "Дата замены")
                            {
                                toFile = ((DateTime)dataGridView1.Rows[i].Cells[j].Value).ToString("dd.MM.yyyy");
                            }
                            if (ht == "№ дня замены")
                            {
                                int num = Convert.ToInt32(toFile);
                                toFile = toFile + ";" + DayName(num);
                            }
                            
                            sw.Write(toFile + ";");
                        }
                        else
                        {
                            sw.Write("" + ";");
                        }
                    }
                    sw.WriteLine();
                }

                sw.Close();
                sw.Dispose();

                
               
            }
            
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            
            Bitmap bmp = new Bitmap(dataGridView1.Size.Width + 10, dataGridView1.Size.Height + 10);
            dataGridView1.DrawToBitmap(bmp, dataGridView1.Bounds);
            e.Graphics.DrawImage(bmp, 0, 0);
        }

        private void buttonPreview_Click(object sender, EventArgs e)
        {
            PrintPreviewDialog printPreviewDialog = new PrintPreviewDialog();
            printPreviewDialog.ClientSize = new Size(400, 300);
            printPreviewDialog.Location = new Point(29, 29);
            printPreviewDialog.Name = "Print Preview Dialog";
            printPreviewDialog.UseAntiAlias = true;
            printPreviewDialog.Document = printDocument1;
            DialogResult result = printPreviewDialog.ShowDialog();
        }

        private void buttonFilterDates_Click(object sender, EventArgs e)
        {
            string datetimeNow = DateTime.Now.ToString("yyyy_MM_dd");
            if (dateTimePicker1.Value.ToString("yyyy_MM_dd") == datetimeNow && dateTimePicker2.Value.ToString("yyyy_MM_dd") == datetimeNow)
            {
                filterDate = false;
            }
            else
            {


                filterDate = true;

                dateBegin = dateTimePicker1.Value;
                dateEnd = dateTimePicker2.Value;
            }
            //get spec id by name

            if (comboBoxSpecs.SelectedItem != null)
            {
                string curSpecName = comboBoxSpecs.SelectedItem.ToString();// (curSpecId);
                if (curSpecName != "---")
                {

                    if (!string.IsNullOrEmpty(curSpecName))
                    {
                        //LINQ
                        string sidSpec = specsL.Where(spec => spec.Value == curSpecName).First().Key.ToString();
                        _F_idSpec = Convert.ToInt32(sidSpec);
                    }
                }

            }

            if (comboBoxPrepods.SelectedItem != null)
            {
                string curPrepName = comboBoxPrepods.SelectedItem.ToString();// (curPrepods);
                if (curPrepName != "---")
                {

                    if (!string.IsNullOrEmpty(curPrepName))
                    {
                        //LINQ
                        string sidPrep = prepodsL.Where(prepods => prepods.Value == curPrepName).First().Key.ToString();
                        _F_idPrep = Convert.ToInt32(sidPrep);
                    }
                }

            }

            if (comboBoxKlasses.SelectedItem != null)
            {
                string curKlassName = comboBoxKlasses.SelectedItem.ToString();// (curKlassId);
                if (curKlassName != "---")
                {

                    if (!string.IsNullOrEmpty(curKlassName))
                    {
                        //LINQ
                        string sidKlass = klassesL.Where(klass => klass.Value == curKlassName).First().Key.ToString();
                        _F_idKlass = Convert.ToInt32(sidKlass);
                    }
                }

            }

            if (comboBoxPrepods1.SelectedItem != null)
            {
                string curPrep1Name = comboBoxPrepods1.SelectedItem.ToString();// (curPrepods1);
                if (curPrep1Name != "---")
                {

                    if (!string.IsNullOrEmpty(curPrep1Name))
                    {
                        //LINQ
                        string sidPrep1 = prepods1L.Where(prepods1 => prepods1.Value == curPrep1Name).First().Key.ToString();
                        _F_idPrep1 = Convert.ToInt32(sidPrep1);
                    }
                }

            }

            selectToGrid();
        }

        private void comboBoxSpecs_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void comboBoxPrepods_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }


        bool disablefilter = false;
        
        private void button2_Click(object sender, EventArgs e)
        {
            disablefilter = !disablefilter;
            selectToGrid();
        }

        
        
    }
}
