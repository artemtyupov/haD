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
    public partial class KlassesFormCrud : Form
    {
        Connector myCon = new Connector();
        public KlassesFormCrud()
        {
            InitializeComponent();
        }

        private void buttonSelectToGrid_Click(object sender, EventArgs e)
        {
            selectTOGrid();
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            this.BeginInvoke(new MethodInvoker(() =>
            {
                InsertUpdate(dataGridView1, e.RowIndex);
            }));

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

                object People = currow.Cells["People"].Value;
                object yearOfStudy = currow.Cells["yearOfStudy"].Value;
                bool CanInsert = false;
                if (Program.useYearOfStudy)
                {
                    bool allNotDbNull = name != DBNull.Value && People != DBNull.Value && yearOfStudy != DBNull.Value;
                    if (allNotDbNull && !string.IsNullOrEmpty(yearOfStudy.ToString()) && !string.IsNullOrEmpty(People.ToString()))
                    {
                        CanInsert = true;
                    }
                }
                else
                {
                    bool namePeopleNotDbNull = name != DBNull.Value &&  People != DBNull.Value;
                    if (namePeopleNotDbNull && !string.IsNullOrEmpty(name.ToString()))
                    {
                        CanInsert = true;
                    }
                }
                if (CanInsert)
                {
                    

                    
                        myCon.Initialize();
                        //DateTime dt = DateTime.Parse(BDay.ToString());
                        //string bdayMysql = dt.ToString("yyyy-MM-dd");
                        myCon.InsertKlass(name.ToString(), People.ToString(), yearOfStudy.ToString());
                        //clearDataGrid();					
                        selectTOGrid();
                    
                }

            }
            else
            {

                //update existing
                object id = currow.Cells["id"].Value;

                
                object name = currow.Cells["name"].Value;

                object People = currow.Cells["People"].Value;
                object yearOfStudy = currow.Cells["yearOfStudy"].Value;
                bool CanUpd = false;
                if (Program.useYearOfStudy)
                {
                    bool allNotDbNull = name != DBNull.Value && People != DBNull.Value && yearOfStudy != DBNull.Value;
                    bool allNotNull = name != null && People != null && yearOfStudy != null;
                    if ( ( allNotDbNull || allNotNull) && !string.IsNullOrEmpty(yearOfStudy.ToString()) && !string.IsNullOrEmpty(People.ToString()))
                    {
                        CanUpd = true;
                    }
                }
                else
                {
                    bool allNotDbNull = name != DBNull.Value && People != DBNull.Value;
                    bool allNotNull = name != null && People != null;
                    if ((allNotDbNull || allNotNull) && !string.IsNullOrEmpty(name.ToString()))
                    {
                        CanUpd = true;
                    }
                }



                if (CanUpd)
                {
                    
                        myCon.Initialize();
                        //DateTime dt = DateTime.Parse(BDay.ToString());
                        //string bdayMysql = dt.ToString("yyyy-MM-dd");
                        myCon.UpdateKlass(id.ToString(), name.ToString(), People.ToString(), yearOfStudy.ToString());
                        //clearDataGrid();
                        selectTOGrid();
                   

                }


            }
        }
        private void KlassesFormCrud_Load(object sender, EventArgs e)
        {
            myCon.Initialize();
        }
        void selectTOGrid()
        {

            myCon.Initialize();
            dataGridView1.DataSource = null;
            //dataGridView1.Dispose();
            var bSource = myCon.SelectKlassesToGrid();
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
                    col.HeaderText = "Название класса";
                    col.Width = 150;
                }
                if (name == "People")
                {
                    col.HeaderText = "Количество человек";
                    col.Width = 150;
                }
                if (name == "yearOfStudy")
                {
                    col.HeaderText = "Год начала обучения";
                    col.Width = 150;
                }
                //MessageBox.Show(name+"  ht="+ht);
            }
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
                    myCon.DeleteKlass(idValue.ToString());
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
