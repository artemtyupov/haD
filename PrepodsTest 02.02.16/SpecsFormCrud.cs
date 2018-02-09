/*
 * Created by SharpDevelop.
 * User: Administrator
 * Date: 12.12.2015
 * Time: 16:01
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace PrepodsTest
{
	/// <summary>
	/// Description of SpecsFormCrud.
	/// </summary>
	public partial class SpecsFormCrud : Form
	{
		Connector myCon = new Connector();
		public SpecsFormCrud()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			myCon.Initialize();
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		void SpecsFormCrudLoad(object sender, EventArgs e)
		{
			myCon.Initialize();
            selectTOGrid();
		}
		void ButtonSelectSpecsToGridClick(object sender, EventArgs e)
		{
			selectTOGrid();
		}
		void selectTOGrid()
		{
			
			myCon.Initialize();
			var  bSource = myCon.SelectSpecsToGrid();
			dataGridView1.DataSource = bSource;
			//dataGridView1.Columns.
			foreach (DataGridViewColumn col in dataGridView1.Columns) 
			{
				string name = col.Name;
				string ht = col.HeaderText;
                if (ht == "id")
                {
                    col.ReadOnly = true;
                    col.Visible = false;
                }
                if (name == "name")
                {
                    col.HeaderText = "Название специализации";
                    col.Width = 150;
                }
				if (name == "course")				    
				{
                    col.HeaderText = "Класс/Курс";
                    col.Width = 140;
				}
                if (name == "semester")
                {
                    col.HeaderText = "Четверть/Семестер";
                    col.Width = 140;
                }
				//MessageBox.Show(name+"  ht="+ht);
			}
		}
        private void InsertUpdate(DataGridView dataGridView1, int ind)
        {
            //update and insert 
            int indRow = ind;
            var currow = dataGridView1.Rows[indRow];
            object idValue = currow.Cells["id"].Value;
            if (idValue == null || idValue == DBNull.Value)
            {
                //insert new
                object name = currow.Cells["name"].Value;

                object course = currow.Cells["course"].Value;
                object semester = currow.Cells["semester"].Value;
                bool CanInsert = false;
                if (Program.useCourseSemester)
                {
                    bool allnotdbnull=name != DBNull.Value && course != DBNull.Value && semester != DBNull.Value;
                    if (allnotdbnull && !string.IsNullOrEmpty(course.ToString()) && !string.IsNullOrEmpty(semester.ToString()))
                    {
                        CanInsert = true;
                    }
                }
                else
                {
                    bool allnotdbnull = name != DBNull.Value;
                    if (allnotdbnull && !string.IsNullOrEmpty(name.ToString()))
                    {
                        CanInsert = true;
                    }
                }
                if (CanInsert)
                {
                    bool isNumbers = true;
                    int dcc = 0;

                    isNumbers = Int32.TryParse(course.ToString(), out dcc);
                    isNumbers = isNumbers && Int32.TryParse(semester.ToString(), out dcc);
                    bool doinsert = false;
                    if (Program.useCourseSemester)
                    {
                        if (isNumbers)
                        {

                            doinsert = true;
                        }
                        else
                        {
                            MessageBox.Show("Курс или семестр не числа!");
                        }
                    }
                    else
                    {
                        doinsert = true;

                    }

                    if (doinsert)
                    {
                        myCon.Initialize();
                        //DateTime dt = DateTime.Parse(BDay.ToString());
                        //string bdayMysql = dt.ToString("yyyy-MM-dd");
                        myCon.InsertSpec(name.ToString(), course.ToString(), semester.ToString());
                        //clearDataGrid();					
                        selectTOGrid();
                    }
                }

            }
            else
            {

                //update existing
                object id = currow.Cells["id"].Value;

                object name = currow.Cells["name"].Value;

                object course = currow.Cells["course"].Value;
                object semester = currow.Cells["semester"].Value;
                bool CanUpdate = false;
                if (Program.useCourseSemester)
                {
                    bool allnotdbnull = name != DBNull.Value && course != DBNull.Value && semester != DBNull.Value;
                    bool allnotnull = name != null && course != null && semester != null;
                    if ( (allnotdbnull||allnotnull) && !string.IsNullOrEmpty(course.ToString()) && !string.IsNullOrEmpty(semester.ToString()))
                    {
                        CanUpdate = true;
                    }
                }
                else
                {
                    bool allnotdbnull = name != DBNull.Value ;
                    bool allnotnull = name != null;
                    if ((allnotdbnull || allnotnull) && !string.IsNullOrEmpty(name.ToString()))
                    {
                        CanUpdate = true;
                    }
                }


                if (CanUpdate)
                {
                    bool isNumbers = true;
                    int dcc = 0;

                    isNumbers = Int32.TryParse(course.ToString(), out dcc);
                    isNumbers = isNumbers && Int32.TryParse(semester.ToString(), out dcc);
                    bool doupd = false;
                    if (Program.useCourseSemester)
                    {
                        if (isNumbers)
                        {
                            doupd = true;
                        }
                        else
                        {
                            MessageBox.Show("Курс или семестр не числа!");
                        }
                    }
                    else
                    {
                        doupd = true;
                    }

                    if (doupd)
                    {
                        myCon.Initialize();
                        //DateTime dt = DateTime.Parse(BDay.ToString());
                        //string bdayMysql = dt.ToString("yyyy-MM-dd");
                        myCon.UpdateSpec(id.ToString(), name.ToString(), course.ToString(), semester.ToString());
                        //clearDataGrid();
                        selectTOGrid();
                    }

                }


            }
        }
		void DataGridView1CellEndEdit(object sender, DataGridViewCellEventArgs e)
		{
            this.BeginInvoke(new MethodInvoker(() =>
            {
                InsertUpdate(dataGridView1, e.RowIndex);
            }));
			
		}
		void clearDataGrid()
		{
			
			// 
		}
		void DataGridView1KeyPress(object sender, KeyPressEventArgs e)
		{
			//char key = e.KeyChar;
			//if (e.KeyChar==(Char)Keys.Delete)
			//{
				//delete
			//	MessageBox.Show("delete press");
			//}
	
		}
		void DataGridView1KeyUp(object sender, KeyEventArgs e)
		{
			//char key = e.;
			if (e.KeyData==Keys.Delete)
			{
				//delete
				int indRow = dataGridView1.CurrentRow.Index;
				var currow = dataGridView1.Rows[indRow];
				object idValue = currow.Cells["id"].Value;
				if (idValue != null && idValue!=DBNull.Value)
            	{
					myCon.Initialize();
					myCon.DeleteSpec(idValue.ToString());
				}
                selectTOGrid();
				//MessageBox.Show("delete UP row="+indRow);
			}
	
		}

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
	}
}
