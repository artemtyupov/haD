using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.IO;
namespace PrepodsTest
{
    public partial class MainFormPrepods : Form
    {
        Connector myCon = new Connector();
        public MainFormPrepods()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

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


//        	dataGridView1.Rows.Clear();
//        	//btcol1.DataPropertyName = "bb";
//        	var col = dataGridView1.Columns["specs"];
//        	DataGridViewButtonColumn btcol1 = (DataGridViewButtonColumn)col;
//        	Label lbl = new Label();
//        	lbl.Text = "ololo";
//        	string text="Edit";
//        	btcol1.Tag = text;
        	//btcol1.DataPropertyName = "bb";


            //-****************SETTINGS////////////////********************
            string settingsFile = "settings.txt";
            string curExeDir = Path.GetDirectoryName( Application.ExecutablePath );
            settingsFile = Path.Combine(curExeDir, settingsFile);
            if (File.Exists(settingsFile))
            {
                StreamReader reader = File.OpenText(settingsFile);
                
                string Line = "";
                

                while ( ( Line=reader.ReadLine() )  != null)
                {
                    
                    //process line
                    string[] substr = Line.Split(';');
                    //process line
                    if (substr[0] == "useCourseSemester")
                    {
                        Program.useCourseSemester = bool.Parse( substr[1] );
                    }
                    if (substr[0] == "useEvenWeeks")
                    {
                        Program.useEvenWeeks = bool.Parse(substr[1]);
                    }
                    if (substr[0] == "useEvenWeeks")
                    {
                        Program.useYearOfStudy = bool.Parse(substr[1]);
                    }
                    
                    
                    
                }

                reader.Close();
            }
            //**********************************************

        }


        private void buttonConnect_Click(object sender, EventArgs e)
        {
            myCon.Initialize();
        }

        private void buttonInsert_Click(object sender, EventArgs e)
        {
            myCon.Insert();
        }

        private void buttonSelect_Click(object sender, EventArgs e)
        {
            //var count = myCon.Count();
            //textBoxSel.Text = "Count prepods=" + count + Environment.NewLine;
            //var res = myCon.Select();
            //foreach (var list in res)
            //{
            //    string n = list.ToString();
            //    foreach (var cur in list)
            //    {
            //        textBoxSel.Text = textBoxSel.Text + cur + " ; ";
            //    }
            //    textBoxSel.Text = textBoxSel.Text + Environment.NewLine;
            //}
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        	var senderGrid = (DataGridView)sender;

        	if (senderGrid.Columns[e.ColumnIndex].Name=="specs" &&		        e.RowIndex >= 0)
		    {
        		
		        //TODO - Button Clicked - Execute Code Here
		        SelectSpecsForm fnew = new SelectSpecsForm();
		        myCon.Initialize();
		        List<GridSpecs> specs = myCon.SelectSpecsToCheckboxes();
		        object curID = senderGrid.CurrentRow.Cells["id"].Value;
		        if (curID!=DBNull.Value)
		        {
		        	fnew.idPrepod=curID.ToString();
			        Dictionary<string, string> specsL=new Dictionary<string, string>();
			        //specs.Add("t1");
			        //specs.Add("t2");
			        foreach (var spec in specs) {
			        	specsL.Add(spec.ID.ToString(), " "+spec.name+" Курс "+spec.course+" Семестр "+spec.semester);
			        }
			        
			        fnew.addBoxes(specsL);
			        fnew.Show();
		        }
		        
		    }
            if (senderGrid.Columns[e.ColumnIndex].Name == "prepodsklasses" && e.RowIndex >= 0)
            {

                //TODO - Button Clicked - Execute Code Here
                SelectPrepodsKlassesForm fnew2 = new SelectPrepodsKlassesForm();
                myCon.Initialize();
                List<GridKlasses> klasses = myCon.SelectKlassesToCheckboxes();
                object curID = senderGrid.CurrentRow.Cells["id"].Value;
                if (curID != DBNull.Value)
                {
                    fnew2.idPrepod = curID.ToString();
                    Dictionary<string, string> prepodsKlasses = new Dictionary<string, string>();
                    //specs.Add("t1");
                    //specs.Add("t2");
                    foreach (var klass in klasses)
                    {
                        prepodsKlasses.Add(klass.ID.ToString(), " " + klass.name + ", Число человек:" + klass.people + ", Год начала обучения:" + klass.yearofstudy);
                    }

                    fnew2.addBoxes(prepodsKlasses);
                    fnew2.Show();
                }

            }

        }
        private SpecsFormCrud specform=null;
        //private FormPrepods f2 = new FormPrepods();
        private void buttonSpec_Click(object sender, EventArgs e)
        {
            //f2.Show();
            specform=new SpecsFormCrud();
            specform.Show();
        }
        private void InsertUpdate(DataGridView dataGridView1, int ind)
        {
            //добавление
            int indRow = ind;
            int countRows = dataGridView1.Rows.Count;
            
            DataGridViewRow currow = dataGridView1.Rows[indRow];
            
            object idValue = currow.Cells["id"].Value;
            if (idValue == DBNull.Value || idValue==null)
            {
                //insert new

                object FioFull = currow.Cells["FioFull"].Value;

                object MobNo = currow.Cells["MobPhoneNumber"].Value;
                object BDay = currow.Cells["Birthday"].Value;
                //TODO: check mobphone & birthday
                if (FioFull != DBNull.Value && FioFull !=null)
                {
                    string[] parts = FioFull.ToString().Split(' ');
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
                        fioShort = FioFull.ToString();
                    }
                    currow.Cells["FioShort"].Value = fioShort;
                }
                object FioShort = currow.Cells["FioShort"].Value;
                bool allNotDbNull = FioFull != DBNull.Value && FioShort != DBNull.Value && MobNo != DBNull.Value && BDay != DBNull.Value ;
               
                if (allNotDbNull )
                {
                    myCon.Initialize();
                    DateTime dt = DateTime.Parse(BDay.ToString());
                    string bdayMysql = dt.ToString("yyyy-MM-dd");
                    myCon.InsertPrepod(FioFull.ToString(), FioShort.ToString(), MobNo.ToString(), bdayMysql);
                    selectTOGrid();
                }
            }
            else
            {

                //update existing
                object id = currow.Cells["id"].Value;


                object FioFull = currow.Cells["FioFull"].Value;

                object MobNo = currow.Cells["MobPhoneNumber"].Value;
                object BDay = currow.Cells["Birthday"].Value;
                //TODO: check mobphone & birthday
                if (FioFull != DBNull.Value && FioFull != null)
                {
                    string[] parts = FioFull.ToString().Split(' ');
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
                        fioShort = FioFull.ToString();
                    }
                    currow.Cells["FioShort"].Value = fioShort;
                }
                object FioShort = currow.Cells["FioShort"].Value;
                bool allNotDbNull = FioFull != DBNull.Value && FioShort != DBNull.Value && MobNo != DBNull.Value && BDay != DBNull.Value;
                bool allNotNull = FioFull != null && FioShort != null && MobNo != null && BDay != null;
                if (allNotDbNull || allNotNull)
                {
                    myCon.Initialize();
                    DateTime dt = DateTime.Parse(BDay.ToString());
                    string bdayMysql = dt.ToString("yyyy-MM-dd");
                    myCon.UpdatePrepod(FioFull.ToString(), FioShort.ToString(), MobNo.ToString(), bdayMysql, id.ToString());

                    selectTOGrid();
                }
            }
 
        }
        /// <summary>
        /// завершение редактирования ячейки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		void DataGridView1CellEndEdit(object sender, DataGridViewCellEventArgs e)
		{
            this.BeginInvoke(new MethodInvoker(() =>
            {
                InsertUpdate(dataGridView1, e.RowIndex);
            }));
			
                
	
		}
		void DataGridView1CellValueChanged(object sender, DataGridViewCellEventArgs e)
		{
	
		}
		private System.Windows.Forms.DataGridViewButtonColumn SpecsNew;
        private System.Windows.Forms.DataGridViewButtonColumn prepodsklasses;
		
		void selectTOGrid()
		{
            //object a = null; 
            //MessageBox.Show("a="+a.ToString());
			myCon.Initialize();
			var  bSource = myCon.SelectPrepodsToGridNew();
			dataGridView1.DataSource = bSource;
			//dataGridView1.Columns.
            bool containSpesc = false;
            bool containPK = false;
			foreach (DataGridViewColumn col in dataGridView1.Columns) 
			{
				string name = col.Name;
				string ht = col.HeaderText;
				if (ht=="id")				    
				{
					col.ReadOnly = true;
					col.Visible = false;
				}
                if (name == "specs")
                {
                    containSpesc = true;
                }
                if (name == "prepodsklasses")
                {
                    containPK = true;
                }
                if (name == "Birthday")
                {
                    col.HeaderText = "День рождения";
                    col.Width = 150;
                }
                if (name == "MobPhoneNumber")
                {
                    col.HeaderText = "Мобильный телефон";
                    col.Width = 150;
                }
                if (name == "FioShort")
                {
                    col.HeaderText = "Сокращенное ФИО";
                    col.Width = 150;
                }
                if (name == "FioFull")
                {
                    col.HeaderText = "Полное ФИО";
                    col.Width = 150;
                }
                if (name == "Adress")
                {
                    col.HeaderText = "Адрес(необязательно)";
                    col.Width = 150;
                }
                if (name == "Comment")
                {
                    col.HeaderText = "Комментарий(необязательно)";
                    col.Width = 180;
                }
				//MessageBox.Show(name+"  ht="+ht);
			}
            //button column
			if (dataGridView1.Columns.Contains("specs")==false)
			{
				//add button column
				this.SpecsNew = new System.Windows.Forms.DataGridViewButtonColumn();
				this.SpecsNew.HeaderText = "Специальности";
	        	this.SpecsNew.Name = "specs";
	        	this.SpecsNew.Text = "Задать";
	        	this.SpecsNew.ToolTipText = "Задать специальности";
	        	this.SpecsNew.UseColumnTextForButtonValue = true;
				this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {	this.SpecsNew});
			}
            //button column prepodsklasses
            if (dataGridView1.Columns.Contains("prepodsklasses") == false)
            {
                //add button column
                this.prepodsklasses = new System.Windows.Forms.DataGridViewButtonColumn();
                this.prepodsklasses.HeaderText = "Классы";
                this.prepodsklasses.Name = "prepodsklasses";
                this.prepodsklasses.Text = "Задать классы";
                this.prepodsklasses.ToolTipText = "Задать классы";
                this.prepodsklasses.UseColumnTextForButtonValue = true;
                this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { this.prepodsklasses });
            }
			
//			
//			try
//			{
//				List<GridPrepodsClass> res = myCon.SelectToGrid();
//				dataGridView1.Rows.Clear();
//	            foreach (GridPrepodsClass curgrid in res)
//	            {
//	                //gridview
//	                int indrow = dataGridView1.Rows.Add();
//	                
//	                var currow = dataGridView1.Rows[indrow];
//	                var idColumn = currow.Cells[0];
//	                idColumn.Value = curgrid.ID;
//	                var FioColumn = currow.Cells[1];
//	                FioColumn.Value = curgrid.FioFull;
//	                
//	                currow.Cells[2].Value = curgrid.FioShort;
//	                currow.Cells[3].Value = curgrid.MobPhone;
//	                currow.Cells[4].Value = curgrid.BirthDay;
//	            }
//	            int b=0;
//	            int c=5;
//	            //int a = c/b;
//			}
//			catch (DivideByZeroException e)
//			{
//				//dividebyzero only
//				var stack = e.StackTrace;
//				var source = e.Source;
//				var ss = e.TargetSite;
//				MessageBox.Show("DivideByZeroException "+e.Message);
//			}
//			catch (MySqlException e)
//			{
//				//mysql only
//				MessageBox.Show("MySqlException "+e.Message);
//			}
//			catch (Exception e)
//			{
//				//general execepteion
//				MessageBox.Show("General "+e.Message);
//			}
		}
		void ButtonSelectToGridClick(object sender, EventArgs e)
		{
			
			selectTOGrid();
	
		}

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //DataGridView1CellEndEdit(sender, e);

        }
        private KlassesFormCrud klassesForm = new KlassesFormCrud();
        private void buttonKlasses_Click(object sender, EventArgs e)
        {
            
            klassesForm = new KlassesFormCrud();
            klassesForm.Show();
        }

        private void dataGridView1_KeyUp(object sender, KeyEventArgs e)
        {
            //char key = e.;
            if (e.KeyData == Keys.Delete)
            {
                //delete
                int indRow = dataGridView1.CurrentRow.Index;
                var currow = dataGridView1.Rows[indRow];
                object idValue = currow.Cells["id"].Value;
                if (idValue != null && idValue != DBNull.Value)
                {
                    myCon.Initialize();
                    myCon.DeletePrepod(idValue.ToString());
                }
                selectTOGrid();
                //MessageBox.Show("delete UP row="+indRow);
            }
        }
        private RoomsFormCrud rooms = new RoomsFormCrud();
        private void buttonRooms_Click(object sender, EventArgs e)
        {
            rooms = new RoomsFormCrud();
            rooms.Show();
        }
        private ScheduleCrud shed = new ScheduleCrud();
        private void buttonSchedule_Click(object sender, EventArgs e)
        {
            shed = new ScheduleCrud();
            shed.Show();

        }
        private ReplaceForm replaceForm = new ReplaceForm();
        private void buttonReplaceForm_Click(object sender, EventArgs e)
        {
            replaceForm = new ReplaceForm();
            replaceForm.Show();

        }
        private OtchetView otchetForm = new OtchetView();
        private void buttonOtchet_Click(object sender, EventArgs e)
        {
            otchetForm = new OtchetView();
            otchetForm.Show();
        }

        private void CreateTables_Click(object sender, EventArgs e)
        {
            myCon.InitializeCreateScheme();
            myCon.CreateTable();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            myCon.Initialize();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //myCon.InitializeSSH();
        }
        private ServerForm serv = new ServerForm();
        private void button1_Click_1(object sender, EventArgs e)
        {
            serv = new ServerForm();
            serv.Show();

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }
        private InfoForm Info = new InfoForm();
        private void button2_Click_1(object sender, EventArgs e)
        {
            Info = new InfoForm();
            Info.Show();
        }

        
		

    }
}
