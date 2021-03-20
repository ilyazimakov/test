using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            DBAcces DataBase = new DBAcces();
            DataBase.myConnection = new System.Data.OleDb.OleDbConnection(DataBase.connectString);
            DataBase.myConnection.Open();
 
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1(DataBase));
        }
    }
}
