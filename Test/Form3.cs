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
    public partial class Form3 : Form
    {
        public DBAcces DataBase;
        public Form1 form1;
        public string SiteName;
        public Form3()
        {
            InitializeComponent();
            
        }

        private void Form3_Shown(object sender, EventArgs e)
        {
            textBox2.Text = SiteName;
            OleDbDataReader result = DataBase.GetUrlAndTime(SiteName);
            result.Read();
            textBox1.Text = result[0].ToString();
            textBox3.Text = result[1].ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataBase.UpdateData(textBox1.Text, textBox2.Text, textBox3.Text, SiteName);
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataBase.DeleteData(SiteName);
            this.Close();
        }
    }
}
