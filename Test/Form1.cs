using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
namespace Test
{
    public partial class Form1 : Form
    {
        DBAcces DateBase;
        public Form1(DBAcces Base)
        {
            InitializeComponent();
            DateBase = Base;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            OleDbDataReader Result = DateBase.GetSites();
            listBox1.Items.Clear();
            while (Result.Read())
            {
                listBox1.Items.Add(Result[0].ToString() + " " + Result[1].ToString());
            }
            Result.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.DataBase = DateBase;
            form2.form1 = this;
            form2.Show();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.DataBase = DateBase;
            form3.form1 = this;
            string NameAndStatus = listBox1.SelectedItem.ToString();
            string[] SplittedString = NameAndStatus.Split(' ');
           
          form3.SiteName = SplittedString[0]; 
           form3.Show();
        }
    }
}
