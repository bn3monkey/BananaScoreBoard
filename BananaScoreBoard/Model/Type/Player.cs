using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace BananaScoreBoard.Model.Type
{
    class Player
    {
        public string name;
        public int score;

        public Player(string name, int score)
        {
            this.name = name;
            this.score = score;
        }

        private static string DBfile = "Player.db";
        private static string password = "SANS";
        private static string open_connection = "Data Source=" + DBfile + ";Version=3;";

        private SQLiteConnection conn = null;
        public static bool openPlayerList()
        {
            bool exists = true;

            if (!System.IO.File.Exists(DBfile))
            {
                SQLiteConnection.CreateFile(DBfile);
                if (!System.IO.File.Exists(DBfile))
                    return false;
                using (SQLiteConnection conn = new SQLiteConnection(open_connection))
                {
                    try
                    {
                        conn.Open();
                    }
                    catch (Exception e)
                    {
                        e.ToString();
                        conn.Close();
                        System.IO.File.Delete(DBfile);
                        return false;
                    }
                    string sql = "create table if not exists Player (name varchar(32) UNIQUE)";
                    var command = new SQLiteCommand(sql, conn);
                    int result = command.ExecuteNonQuery();
                    if (result < 0)
                    {
                        command.Dispose();
                        conn.Close();
                        return false;
                    }
                    sql = "create index index01 on Player(name)";
                    command = new SQLiteCommand(sql, conn);
                    result = command.ExecuteNonQuery();
                    if (result < 0)
                    {

                        command.Dispose();
                        conn.Close();
                        return false;
                    }

                    command.Dispose();
                    conn.Close();
                }
            }
            
            return true;
        }

        public static List<string> listPlayer(string name)
        {
            var ret = new List<string>();
            using (SQLiteConnection conn = new SQLiteConnection(open_connection))
            {
                conn.Open();
                var command = new SQLiteCommand(conn);
                command.CommandText = @"SELECT * FROM Player WHERE name like '" + name + "%' ORDER BY name ASC";
                SQLiteDataReader rdr = command.ExecuteReader();


                while (rdr.Read())
                {
                    string player_name = rdr["name"] as string;
                    ret.Add(player_name);
                }

                rdr.Close();
                command.Dispose();
                conn.Close();
            }
            return ret;
        }
        public bool addPlayer()
        {
            if (!String.IsNullOrEmpty(name))
            {
                using (SQLiteConnection conn = new SQLiteConnection(open_connection))
                {
                    conn.Open();
                    var command = new SQLiteCommand(conn);
                    command.CommandText = @"INSERT OR IGNORE INTO Player (name) VALUES ($name)";
                    command.Parameters.AddWithValue("$name", name);
                    int result = command.ExecuteNonQuery();
                    command.Dispose();
                    conn.Close();
                    if (result < 0)
                        return false;
                    return true;
                }
            }
            return true;
        }

        


    }
}
