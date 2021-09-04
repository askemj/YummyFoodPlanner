﻿using System;
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
        private MySqlConnectionStringBuilder ConnectionStringBuilder = new MySqlConnectionStringBuilder();
        private MySqlConnection SqlConnection;

        public MariaDBConnector()
        {
            Dictionary<string, string> databaseCredentials = LoadFromCredFile();
            Console.WriteLine(databaseCredentials.ToString());
            ConnectionStringBuilder.Port = 3306;
            ConnectionStringBuilder.Server = databaseCredentials["IP"];
            ConnectionStringBuilder.Database = "opskrifter";
            ConnectionStringBuilder.UserID = databaseCredentials["Username"];
            ConnectionStringBuilder.Password = databaseCredentials["Password"];
            SqlConnection = new MySqlConnection(ConnectionStringBuilder.ConnectionString);
            Console.WriteLine("MariaDB Connection finished setting up");
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

        public DataTable SQLQuery(string queryString, DataTable dataTable)
        {
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

        public DataTable GetRecipeInfo(string recipeID)
        {
            DataTable dt = new DataTable("Recipe Info");
            foreach (string col in new List<string>(new string[] { "ID", "Name", "Notes", "Number of Servings", "Preparation Time", "Total Time", "Recipe Type" })) {
                dt.Columns.Add(col);
            }           

            string query = $"SELECT Ret.ret_id, Ret.ret_navn, Ret.noter, Ret.antal_portioner, Tilberedningstid.tilberedningstid_tid, " +
                            "Arbejdstid.arbejdstid_tid, Opskriftstype.opskriftstype_tekst " +
                            "FROM Ret, Tilberedningstid, Arbejdstid, Opskriftstype " +
                            "WHERE Ret.Tilberedningstid_tilberedningstid_id = Tilberedningstid.tilberedningstid_id " +
                            "AND Ret.Arbejdstid_arbejdstid_id = Arbejdstid.arbejdstid_id " +
                            "AND Ret.Opskriftstype_opskriftstype_id = Opskriftstype.opskriftstype_id " +
                            "AND Ret.ret_ID = \"{recipeID}\";";
            return SQLQuery(query, dt);
        }

        public DataTable GetRecipeTags(string recipeID)
        {
            DataTable dt = new DataTable("Tags");
            dt.Columns.Add("Tag");

            string query = $"SELECT Tag.tag_tekst " +
                            "FROM Ret, RetTag, Tag " +
                            "WHERE Ret.ret_id = RetTag.Ret_ret_id " +
                            "AND Tag.tag_id = RetTag.Tag_tag_id " +
                            "AND Ret.ret_id = \"{recipeID}\"";

            return SQLQuery(query, dt);
        }
    }
}
