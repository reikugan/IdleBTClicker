using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdleBTClicker
{
    public class Player
    {
        public int id { get; set; }
        public string username { get; set; }
        public string nickname { get; set; }
        public double usdt { get; set; }
        public double incpersec { get; set; }
        public double clickmine {  get; set; }
        public long offlinefor {  get; set; }

        public Player (int id, string username, string nickname, double usdt, double incpersec, double clickmine, long offlinefor)
        {
            this.id = id;
            this.username = username;
            this.nickname = nickname;
            this.usdt = usdt;
            this.incpersec = incpersec;
            this.clickmine = clickmine;
            this.offlinefor = offlinefor;
        }
        
        public static int PurchaseUpgrade(int id, string upgrade, int tier)
        {
            int currentTier = GetUpgradeLvl(id, upgrade);
            int success = 0;

            if ((tier - currentTier) == 1)
            {
                try
                {
                    using (SQLiteConnection con = new SQLiteConnection(Program.playersconnect))
                    {
                        con.Open();
                        string query = $"UPDATE players SET {upgrade} = {upgrade} + 1 WHERE id = @id";
                        using (SQLiteCommand cmd = new SQLiteCommand(query, con))
                        {
                            cmd.Parameters.AddWithValue("@id", id);
                            success = cmd.ExecuteNonQuery();
                        }
                    }
                }   
                catch (Exception e)
                {
                    MessageBox.Show($"Error trying to purchase upgrade {upgrade} for player {id} " + e.Message);
                }
            } 
            else
            {
                MessageBox.Show("You must purchase previous tier upgrade first!");
            }
            return success;
        }

        public static int GetUpgradeLvl(int id, string upgrade)
        {
            int lvl = 0;
            try
            {
                using (SQLiteConnection con = new SQLiteConnection(Program.playersconnect))
                {
                    con.Open();
                    string query = $"SELECT {upgrade} from players WHERE id = {id}";
                    using (SQLiteCommand cmd = new SQLiteCommand(query, con))
                    {
                        lvl = Convert.ToInt32(cmd.ExecuteScalar());
                    }
                }

            }
            catch (Exception e)
            {
                MessageBox.Show($"Error getting players upgrade level for + {upgrade} " + e.Message);
            }
            return lvl;
        }

    }

}
