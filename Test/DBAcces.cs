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
    }
    
}