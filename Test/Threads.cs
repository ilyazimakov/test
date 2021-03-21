using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Data.OleDb;
using System.Net;
namespace Test
{
    class Threads
    {
        
        public static void ParallelFunction(object obj)
        {
            DBAcces DataBase = (DBAcces)obj;
            while (true)
            {
                DataBase.UpdateTime();
               
                OleDbDataReader URLToCheck = DataBase.GetSitesReadyToCheck();
                
                while (URLToCheck.Read())
                {
                    string URL= URLToCheck[0].ToString();
                    
                    DataBase.UpdateDataAboutWorking(CheckIfWorking(URL), URL);
                }
                URLToCheck.Close();
                DataBase.RefreshTime();

                Thread.Sleep(1000);
            }
           
        }
        static bool CheckIfWorking(string URL)
        {
            try
            {
                Uri uri = new Uri(URL);


                HttpWebRequest httpWebRequest = (HttpWebRequest)HttpWebRequest.Create(uri);
                HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            }
            catch
            {
                return false;
            }
            return true;
        }
        
    }
}
