using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;

namespace AD_CW
{
    public sealed class DBSingleton //Use of patterns (sealed class)
    {
        public DBSingleton() { }
        public static DBSingleton instance = null;
        public static DBSingleton Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DBSingleton();
                }
                return instance;
            }

        }

        private static OleDbConnection GetConnection()
        {
            string connString;
            //  change to your connection string in the following line
            connString = @"Provider=Microsoft.JET.OLEDB.4.0;Data Source=I:\Application Development\SeaQuizGame\Quiz.mdb";
            return new OleDbConnection(connString);
        }

        public string SaveScore(string n, int s)
        {
            OleDbConnection myConnection = GetConnection();
            string myQuery = "INSERT INTO Player( pName, pScore) VALUES ( '" + n + "' , '" + s + "' )"; //Save parameter values in database
            OleDbCommand myCommand = new OleDbCommand(myQuery, myConnection);
            try
            {
                myConnection.Open();
                myCommand.ExecuteNonQuery();
                return ("Player score saved");
            }
            catch (Exception ex)
            {
                return ("Exception in DBSingleton" + ex);
            }
            finally
            {
                myConnection.Close();
            }
        }
        public List<string> ViewPlayers() 
        {
            List<string> players = new List<string>();//Collection used here for players
            OleDbConnection myConnection = GetConnection();
            string myQuery = "SELECT pName, pScore FROM Player";
            OleDbCommand myCommand = new OleDbCommand(myQuery, myConnection);
            try
            {
                myConnection.Open();
                OleDbDataReader myReader = myCommand.ExecuteReader();
                while (myReader.Read())
                {
                    players.Add(myReader["pName"].ToString() + "                              " + myReader["pScore"].ToString());
                }
                return players;
            }
            catch
            {
                return null;
            }
            finally
            {
                myConnection.Close();
            }
        }
    }
}
