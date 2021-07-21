using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace Model
{
    public class MariaDBConnector : IDBConnection
    {
        private static MySqlConnectionStringBuilder ConnectionStringBuilder = new MySqlConnectionStringBuilder();
        private static MySqlConnection SqlConnection;

        public static void SetupConnection()
        {
            ConnectionStringBuilder.Port = 3306;
            ConnectionStringBuilder.Server = ip;
            ConnectionStringBuilder.Database = "opskrifter";
            ConnectionStringBuilder.UserID = u;
            ConnectionStringBuilder.Password = p;
            SqlConnection = new MySqlConnection(ConnectionStringBuilder.ConnectionString);
        }

        public static List<string> GetRecipeDetails(string recipeID)
        {
            List<string> recipeDetails = new List<string>();
            string sqlQueryStr = $"SELECT Ret.ret_id, Ret.noter, Ret.antal_portioner, Tilberedningstid.tilberedningstid_tid, " +
                "Arbejdstid.arbejdstid_tid, Opskriftstype.opskriftstype_tekst " +
                "FROM Ret, Tilberedningstid, Arbejdstid, Opskriftstype " +
                "WHERE Ret.Tilberedningstid_tilberedningstid_id = Tilberedningstid.tilberedningstid_id " +
                "AND Ret.Arbejdstid_arbejdstid_id = Arbejdstid.arbejdstid_id " +
                "AND Ret.Opskriftstype_opskriftstype_id = Opskriftstype.opskriftstype_id " +
                "AND Ret.ret_ID = \"{recipeID}\";";
            try
            { 
                Console.WriteLine("Yummyfoodplanner: opening MariaDB connection and executing query: \"" + sqlQueryStr);
                SqlConnection.Open();
                MySqlCommand sqlCommand = new MySqlCommand(sqlQueryStr, SqlConnection);
                MySqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    recipeDetails.Add(reader[0].ToString());
                    recipeDetails.Add(reader[1].ToString());
                    recipeDetails.Add(reader[2].ToString());
                    recipeDetails.Add(reader[3].ToString());
                    recipeDetails.Add(reader[4].ToString());
                    recipeDetails.Add(reader[5].ToString());
                }
                Console.WriteLine("GroceryApp: Query OK");
            }
            catch (Exception Ex)
            {
                Console.WriteLine(Ex.ToString());
            }
            finally
            {
                if (SqlConnection.State.ToString() == "Open")
                {
                    SqlConnection.Close();
                }
            }
            return recipeDetails;
        }

        public static DataTable GetRecipeIngredients() { 
            DataTable dt = new DataTable("Recipe Details"); 
            return dt;
        }
    }
}
