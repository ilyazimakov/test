using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

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

            Threads ParallelThread = new Threads();
            DBAcces DataBase = new DBAcces();
            DataBase.myConnection = new System.Data.OleDb.OleDbConnection(DataBase.connectString);
            DataBase.myConnection.Open();
           // ParallelThread.DataBase = DataBase;
            Thread parallelThread = new Thread(new ParameterizedThreadStart(Threads.ParallelFunction));
            
            parallelThread.Start(DataBase);


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1(DataBase,parallelThread));
        }

    }
}
