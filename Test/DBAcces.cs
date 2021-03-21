using System;
using System.Data.OleDb;

namespace Test
{
    public class DBAcces
    {
        public string connectString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=SitesDB.mdb";
        public OleDbConnection myConnection;

        public OleDbDataReader GetSites()
        {
            string query = "SELECT SiteName_DB, Status_DB FROM Sites";
            OleDbCommand command = new OleDbCommand(query, myConnection);
            OleDbDataReader reader = command.ExecuteReader();
            return reader;
        }
        public void WriteSites(string geturl, string getname, string gettime)
        {

            string query = "INSERT INTO Sites (URL_DB,SiteName_DB,TimeToRefresh_DB,TimeBeforeCheck_DB) VALUES ('" + geturl + "','"
                + getname + "','" + gettime + "',1)";
            OleDbCommand command = new OleDbCommand(query, myConnection);
            command.ExecuteNonQuery();

        }
        public OleDbDataReader GetUrlAndTime(string NAME)
        {
            string query = "SELECT URL_DB, TimeToRefresh_DB FROM Sites WHERE SiteName_DB='" + NAME + "'";
            OleDbCommand command = new OleDbCommand(query, myConnection);
            OleDbDataReader reader = command.ExecuteReader();
            return reader;
        }
        public void UpdateData(string url, string name, string time, string oldname)
        {
            string query = "UPDATE Sites SET TimeBeforeCheck_DB=1, URL_DB='" + url + "',SiteName_DB='" + name + "',TimeToRefresh_DB='" + time + "' WHERE SiteName_DB='" + oldname + "'";
            OleDbCommand command = new OleDbCommand(query, myConnection);
            command.ExecuteNonQuery();
        }
        public void DeleteData(string name)
        {
            string query = "DELETE FROM Sites WHERE SiteName_DB='" + name + "'";
            OleDbCommand command = new OleDbCommand(query, myConnection);
            command.ExecuteNonQuery();
        }
        
        public int GetSitesNum()
        {
            string query = "SELECT Count(*) FROM Sites";
            OleDbCommand command = new OleDbCommand(query, myConnection);
            int count = (int)command.ExecuteScalar();
            return count;

        }
        public void UpdateTime()
        {
            string query = "UPDATE Sites SET TimeBeforeCheck_DB=TimeBeforecheck_DB-1";
            OleDbCommand command = new OleDbCommand(query, myConnection);
            command.ExecuteNonQuery();
        }
        public OleDbDataReader GetSitesReadyToCheck()
        {
            string query = "SELECT URL_DB FROM Sites WHERE TimeBeforeCheck_DB<=0";
            OleDbCommand command = new OleDbCommand(query, myConnection);
            OleDbDataReader reader = command.ExecuteReader();
            return reader;
        }
        public void RefreshTime()
        {
            string query = "UPDATE Sites SET TimeBeforeCheck_DB=TimeToRefresh_DB WHERE TimeBeforeCheck_DB<=0";
            OleDbCommand command = new OleDbCommand(query, myConnection);
            command.ExecuteNonQuery();
        }
        public void UpdateDataAboutWorking(bool status,string url)
        {
            string query = "UPDATE Sites SET Status_DB=" + Convert.ToString(status) + " WHERE URL_DB='" + url + "'";
            OleDbCommand command = new OleDbCommand(query, myConnection);
            command.ExecuteNonQuery();
        }
    }
    
}