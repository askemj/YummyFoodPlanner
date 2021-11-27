using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Model
{
    public class MariaDBConnector : IDBConnection
    {
        private MySqlConnectionStringBuilder ConnectionStringBuilder = new MySqlConnectionStringBuilder();
        private MySqlConnection SqlConnection;
        public string ConnectionStatus;

        public MariaDBConnector()
        {
            Dictionary<string, string> databaseCredentials = LoadFromCredFile();
            Console.WriteLine(databaseCredentials.ToString());
            ConnectionStringBuilder.Port = 3306;
            ConnectionStringBuilder.Server = databaseCredentials["IP"];
            ConnectionStringBuilder.Database = "opskrifter";
            ConnectionStringBuilder.UserID = databaseCredentials["Username"];
            ConnectionStringBuilder.Password = databaseCredentials["Password"];
            ConnectionStringBuilder.SslMode = MySqlSslMode.None;
            SqlConnection = new MySqlConnection(ConnectionStringBuilder.ConnectionString);
            ConnectionStatus = "unavailable";
            TestConnection();
            Console.WriteLine("MariaDB Connection finished setting up");
        }

        public string TestConnection(){
            string serverInfo = "N/A";

            try
            {
                Console.WriteLine("Testing MySQL connection ...");
                SqlConnection.Open();
                ConnectionStatus = "available"; 
                serverInfo = SqlConnection.ServerVersion + " " + SqlConnection.State.ToString();
                Console.WriteLine("MySQL connection is live: " + serverInfo); 
            }
            catch (Exception Ex)
            {
                Console.WriteLine(Ex.ToString());
                ConnectionStatus = "unavailable";
            }
            finally
            {
                if (SqlConnection.State.ToString() == "Open")
                {
                    SqlConnection.Close();
                }
            }
                return serverInfo;
        }

        public Dictionary<string, string> LoadFromCredFile()
        {
            Dictionary<string, string> loginCredentials = new Dictionary<string, string>();

            Regex re_pass = new Regex(@"(^Password\t+)(\w*)");
            Regex re_user = new Regex(@"(^Username\t+)(\w*)");
            Regex re_ip = new Regex(@"(^IP\t+)(\d+.\d+.\d+.\d+)");


            var path = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\..\credentials.cred"));
            Console.WriteLine(path.ToString());

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

        public DataTable SQLQuery(string queryString)
        {
            DataTable dataTable = new DataTable();
            try
            {
                SqlConnection.Open();
                MySqlCommand sqlCommand = new MySqlCommand(queryString, SqlConnection);
                MySqlDataAdapter mySqlDataAdapter= new MySqlDataAdapter(sqlCommand);
                mySqlDataAdapter.Fill(dataTable);
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
            
            return dataTable;
        }

        public DataTable GetRecipeInfo(int recipeID)
        {
            string query = $"SELECT Ret.ret_id, Ret.ret_navn, Ret.noter, Ret.antal_portioner, Tilberedningstid.tilberedningstid_tid, " +
                            $"Arbejdstid.arbejdstid_tid, Opskriftstype.opskriftstype_tekst " +
                            $"FROM Ret, Tilberedningstid, Arbejdstid, Opskriftstype " +
                            $"WHERE Ret.Tilberedningstid_tilberedningstid_id = Tilberedningstid.tilberedningstid_id " +
                            $"AND Ret.Arbejdstid_arbejdstid_id = Arbejdstid.arbejdstid_id " +
                            $"AND Ret.Opskriftstype_opskriftstype_id = Opskriftstype.opskriftstype_id " +
                            $"AND Ret.ret_ID = \"{recipeID.ToString()}\";";
            DataTable dT = SQLQuery(query);
            return dT;
        }

        public DataTable GetRecipeTags(int recipeID)
        {
            string query = "SELECT Tag.tag_tekst " +
                            "FROM Ret, RetTag, Tag " +
                            "WHERE Ret.ret_id = RetTag.Ret_ret_id " +
                            "AND Tag.tag_id = RetTag.Tag_tag_id " +
                            $"AND Ret.ret_id = \"{recipeID.ToString()}\"";
            DataTable dT = SQLQuery(query);
            return dT; 
        }

        public DataTable GetIngredients(int recipeID)
        {
            string query = "SELECT Vare.vare_id, RetVare.maengde, Enhed.enhed_navn, Vare.vare_navn, Varetype.varetype_tekst, Vare.basisvare " + //, Vare.basisvare " + 
                                    "FROM Ret, RetVare, Enhed, Vare, Varetype " +
                                    "WHERE Ret.ret_id = RetVare.Ret_ret_id " +
                                    "AND Vare.vare_id = RetVare.Vare_vare_id " +
                                    "AND Enhed.enhed_id = RetVare.Enhed_enhed_id " +
                                    "AND Vare.Varetype_varetype_id = Varetype.varetype_id " +
                                    $"AND Ret.ret_id = \"{recipeID.ToString()}\";";
            DataTable dT = SQLQuery(query);

            dT.Columns["vare_id"].ColumnName = "ID";
            dT.Columns["maengde"].ColumnName = "Quantity";
            dT.Columns["enhed_navn"].ColumnName = "Unit";
            dT.Columns["vare_navn"].ColumnName = "Name";
            dT.Columns["vare_type"].ColumnName = "SuperMarketSection";
            dT.Columns["basisvare"].ColumnName = "IsBasicItem";
            DataColumn dC = new DataColumn("Role", typeof(string) );
            dC.DefaultValue = "hovedingrediens";
            dT.Columns.Add(dC);

            return new DataTable();
        }

        public List<SimpleRecipe> GetMenu(string searchKey)
        {
            string sqlString = $"SELECT Ret.ret_id FROM Ret, Tag, RetTag " + // NB makes many calls to format.string and many strings in memory :(
            $"WHERE Ret.ret_id = RetTag.Ret_ret_id " +
            $"AND Tag.tag_id = RetTag.Tag_tag_id " + 
            $"AND Tag.tag_tekst LIKE \"%{searchKey}%\" " + 
            $"UNION  " +
            $"SELECT Ret.ret_id FROM Ret " +
            $"WHERE ret_navn LIKE \"%{searchKey}% \" " +
            $"UNION  " +
            $"SELECT Ret.ret_id  " +
            $"FROM Ret, Vare, RetVare  " +
            $"WHERE Ret.ret_id = RetVare.Ret_ret_id  " +
            $"AND Vare.vare_id = RetVare.Vare_vare_id  " +
            $"AND Vare.vare_navn LIKE \"%{searchKey}%\";";

            //string sqlString = $"SELECT Ret.ret_navn FROM Ret, Tag, RetTag " + // NB makes many calls to format.string and many strings in memory :(
            //$"WHERE Ret.ret_id = RetTag.Ret_ret_id " +
            //$"AND Tag.tag_id = RetTag.Tag_tag_id " +
            //$"AND Tag.tag_tekst LIKE \"%{searchKey}%\" " +
            //$"UNION  " +
            //$"SELECT Ret.ret_navn FROM Ret " +
            //$"WHERE ret_navn LIKE \"%{searchKey}% \" " +
            //$"UNION  " +
            //$"SELECT Ret.ret_navn  " +
            //$"FROM Ret, Vare, RetVare  " +
            //$"WHERE Ret.ret_id = RetVare.Ret_ret_id  " +
            //$"AND Vare.vare_id = RetVare.Vare_vare_id  " +
            //$"AND Vare.vare_navn LIKE \"%{searchKey}%\";";

            DataTable dT = SQLQuery(sqlString);

            List<int> menuIDs = new List<int>();
            for (int i = 0; i < dT.Rows.Count; i++)
            {
                menuIDs.Add(Convert.ToInt32(dT.Rows[i]["ret_id"]));
            }

            List<SimpleRecipe> menuList = new List<SimpleRecipe>();
            foreach (int recipeID in menuIDs)
            {
                SimpleRecipe recipe = new SimpleRecipe();
                recipe.LoadFromDB(recipeID, this);
                menuList.Add(recipe);
            }
            return menuList;    
        }
    }
}
