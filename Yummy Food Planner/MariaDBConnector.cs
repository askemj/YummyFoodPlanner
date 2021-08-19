using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.IO;
using System.Text.RegularExpressions;

namespace Model
{
    public class MariaDBConnector : IDBConnection
    {
        private static MySqlConnectionStringBuilder ConnectionStringBuilder = new MySqlConnectionStringBuilder();
        private static MySqlConnection SqlConnection;

        public static void SetupConnection()
        {
            Dictionary<string, string> databaseCredentials = LoadFromCredFile();
            Console.WriteLine(databaseCredentials.ToString());
            ConnectionStringBuilder.Port = 3306;
            ConnectionStringBuilder.Server = databaseCredentials["IP"];
            ConnectionStringBuilder.Database = "opskrifter";
            ConnectionStringBuilder.UserID = databaseCredentials["Username"];
            ConnectionStringBuilder.Password = databaseCredentials["Password"];
            SqlConnection = new MySqlConnection(ConnectionStringBuilder.ConnectionString);
        }

        public static Dictionary<string, string> LoadFromCredFile()
        {
            Dictionary<string, string> loginCredentials = new Dictionary<string, string>();

            Regex re_pass = new Regex(@"(^Password\t+)(\w*)");
            Regex re_user = new Regex(@"(^User\t+)(\w*)");
            Regex re_ip = new Regex(@"(^IP\t+)(\d+.\d+.\d+.\d+)");


            var path = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\credentials.cred"));

            Console.WriteLine(path);

            using (StreamReader reader = new StreamReader(path)) 
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    Match match_pass = re_pass.Match(line);
                    Match match_user = re_user.Match(line);
                    Match match_IP = re_ip.Match(line);


                    if (match_pass.Success)
                    {
                        loginCredentials.Add("Password", match_pass.Groups[2].Value.Trim());
                    }

                    if (match_user.Success)
                    {
                        loginCredentials.Add("Username", match_user.Groups[2].Value.Trim());
                        Console.WriteLine(loginCredentials["Username"]);
                    }

                    if (match_IP.Success)
                    {
                        loginCredentials.Add("IP", match_IP.Groups[2].Value.Trim());
                    }
                }
            }
            return loginCredentials;
        }

        public static Dictionary<string, string> GetRecipeInfo(string recipeID)
        {
            Dictionary<string, string> recipeInfo = new Dictionary<string, string>();
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

                //while (reader.Read())
                //{
                //    recipeDetails.Add(reader[0].ToString());
                //    recipeDetails.Add(reader[1].ToString());
                //    recipeDetails.Add(reader[2].ToString());
                //    recipeDetails.Add(reader[3].ToString());
                //    recipeDetails.Add(reader[4].ToString());
                //    recipeDetails.Add(reader[5].ToString());
                //}
                //Console.WriteLine("GroceryApp: Query OK");

                while (reader.Read())
                {
                    recipeInfo.Add("ID", reader[0].ToString() );
                    recipeInfo.Add("Notes", reader[1].ToString() );
                    recipeInfo.Add("Number of Servings", reader[2].ToString() );
                    recipeInfo.Add("Preparation Time", reader[3].ToString() );
                    recipeInfo.Add("Total Time", reader[4].ToString() );
                    recipeInfo.Add("Recipe Type", reader[5].ToString() );
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
            return recipeInfo;
        }

        public static List<string> GetTags(string recipeName)
        {
            List<string> sqlResult = new List<string>();
            string sqlString = "SELECT Tag.tag_tekst " +
            "FROM Ret, RetTag, Tag " +
            "WHERE Ret.ret_id = RetTag.Ret_ret_id " +
            "AND Tag.tag_id = RetTag.Tag_tag_id " +
            "AND Ret.ret_navn = \"" + recipeName + "\"";
            // sqlResult = SqlListQuery(sqlString);
            return sqlResult;
        }

        public static DataTable GetRecipeIngredients() { 
            DataTable dt = new DataTable("Recipe Details"); 
            return dt;
        }
    }
}
