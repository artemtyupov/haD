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
    public partial class RoomsFormCrud : Form
    {
        Connector myCon = new Connector();
        public RoomsFormCrud()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            this.BeginInvoke(new MethodInvoker(() =>
            {
                InsertUpdate(dataGridView1, e.RowIndex);
            }));
        }

        private void dataGridView1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Delete)
            {
                //delete
                int indRow = dataGridView1.CurrentRow.Index;
                var currow = dataGridView1.Rows[indRow];
                object idValue = currow.Cells["id"].Value;
                if (idValue != null && idValue != DBNull.Value)
                {
                    myCon.Initialize();
                    myCon.DeleteRoom(idValue.ToString());
                }
                selectTOGrid();
                //MessageBox.Show("delete UP row="+indRow);
            }
        }
        private void InsertUpdate(DataGridView dataGridView1, int ind)
        {
            //добавление
            int indRow = ind;
            int countRows = dataGridView1.Rows.Count;

            DataGridViewRow currow = dataGridView1.Rows[indRow];

            object idValue = currow.Cells["id"].Value;
            if (idValue == DBNull.Value || idValue == null)
            {
                //insert new

                object capacity = currow.Cells["capacity"].Value;

                object roomname = currow.Cells["name"].Value;
                
                

                bool allNotDbNull = capacity != DBNull.Value && roomname != DBNull.Value;
                
                if (allNotDbNull)
                {
                    myCon.Initialize();
                    //DateTime dt = DateTime.Parse(BDay.ToString());
                    
                    myCon.InsertRoom(roomname.ToString(), capacity.ToString(), "");
                    selectTOGrid();
                }
            }
            else
            {
                //update existing
                object id = currow.Cells["id"].Value;
                //update existing
                object capacity = currow.Cells["capacity"].Value;

                object roomname = currow.Cells["name"].Value;
                



                bool allNotDbNull = capacity != DBNull.Value && roomname != DBNull.Value;
                bool allNotNull = capacity != null && roomname != null;
                
                if (allNotDbNull || allNotNull)
                {
                    myCon.Initialize();


                    myCon.UpdateRoom(capacity.ToString(), roomname.ToString(), "", id.ToString());

                    selectTOGrid();
                }
            }

        }
        void selectTOGrid()
        {

            myCon.Initialize();
            dataGridView1.DataSource = null;
            //dataGridView1.Dispose();
            var bSource = myCon.SelectRoomsToGrid();
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
                    col.HeaderText = "Название аудитории";
                    col.Width = 150;
                }
                if (name == "capacity")
                {
                    col.HeaderText = "Вместимость аудитории";
                    col.Width = 150;
                }
                //MessageBox.Show(name+"  ht="+ht);
            }
        }
        private void buttonSelect_Click(object sender, EventArgs e)
        {
            selectTOGrid();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
