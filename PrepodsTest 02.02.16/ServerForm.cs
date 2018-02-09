using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace PrepodsTest
{
    public partial class ServerForm : Form
    
    {

        Connector myCon = new Connector();
        private MySqlConnection connection;
        public ServerForm()
        {
            InitializeComponent();
        }

        
        

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

            if (checkBox1.CheckState == CheckState.Checked) { checkBox2.CheckState = CheckState.Unchecked; ; checkBox3.CheckState = CheckState.Unchecked; } 
            if (checkBox1.Checked == false) { checkBox2.Enabled = false; checkBox3.Enabled = false; checkBox1.Checked = false; } 
            
            
        }


        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true) { checkBox1.Enabled = false; checkBox3.Enabled = false; }
            if (checkBox2.Checked == false) {  checkBox3.Enabled = false; checkBox1.Checked = false; } 
           
          
        }


        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked == true) { checkBox1.Enabled = false; checkBox2.Enabled = false; }
            if (checkBox3.Checked == false) { checkBox2.Enabled = false; checkBox3.Enabled = false; checkBox1.Checked = false; } 
           
        
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true) { myCon.InsertInfoServer("195.128.124.100", "3306", "tupov-a", "3Ln7ETvKMyb3na5X", "tupov-a", "0", "0", "1"); }
            if (checkBox2.Checked == true) { myCon.InsertInfoServer(textBox2.Text, textBox5.Text, textBox4.Text, textBox6.Text, textBox7.Text, "0", "0", "2"); }
            if (checkBox3.Checked == true) { myCon.InsertInfoServer(textBox3.Text, textBox1.Text, textBox8.Text, textBox7.Text, textBox10.Text, textBox12.Text, textBox11.Text, "3"); }
            Close();
        }
       
     }
        

       
       
    }

