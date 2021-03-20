using System;
using System.Data.OleDb;

namespace Test
{
    public  class DBAcces
    {
        public  string connectString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=SitesDB.mdb";
        public OleDbConnection myConnection;

        public OleDbDataReader  GetSites()
        {
            string query = "SELECT SiteName_DB, Status_DB FROM Sites";
            OleDbCommand command = new OleDbCommand(query, myConnection);
            OleDbDataReader reader = command.ExecuteReader();
            return reader;
        }
        public void WriteSites(string geturl,string getname,string gettime)
        {

            string query = "INSERT INTO Sites (URL_DB,SiteName_DB,TimeToRefresh_DB) VALUES ('" + geturl + "','"
                + getname + "','" +gettime + "')";
            OleDbCommand command = new OleDbCommand(query, myConnection);
            command.ExecuteNonQuery();

        }
    }
    
}