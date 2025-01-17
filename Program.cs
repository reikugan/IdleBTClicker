using System.CodeDom;
using System.Data.SQLite;
using System.Numerics;

namespace IdleBTClicker
{
    internal static class Program
    {

        public static double clickUpPrice = 5;


        //----BASE DIRECTORY APPROACH---
        static string dir = AppDomain.CurrentDomain.BaseDirectory;

        static string projectDir = Path.GetFullPath(Path.Combine(dir, @"..\..\.."));

        static string assetsdbpath = Path.Combine(projectDir, "Resources", "assets.db");
        static string playersdbpath = Path.Combine(projectDir, "Resources", "players.db");
        static string coinsdbpath = Path.Combine(projectDir, "Resources", "coins.db");
        static string upgradesdbpath = Path.Combine(projectDir, "Resources", "upgrades.db");

        public static string coinsconnect = $"Data Source={coinsdbpath}";
        public static string playersconnect = $"Data Source={playersdbpath}";
        public static string assetsconnect = $"Data Source={assetsdbpath}";
        public static string upgradesconnect = $"Data Source={upgradesdbpath}";


        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new LogIn());

        }

        public static void SaveImage(string filePath, string coin_name)
        {
            try
            {
                using (SQLiteConnection con = new SQLiteConnection(coinsconnect))
                {
                    con.Open();

                    byte[] imageData = File.ReadAllBytes(filePath);

                    //string query = "INSERT INTO coins (img) VALUES (@ImageData)";
                    string query = "UPDATE Images SET ImageData = @ImageData WHERE coin = @Name";

                    using (SQLiteCommand cmd = new SQLiteCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@ImageData", imageData);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static Image GetImage(string coinName)
        {
            byte[] image = null;
            Image img = null;
            try
            {
                using (SQLiteConnection con = new SQLiteConnection(coinsconnect))
                {
                    con.Open();

                    string query = "SELECT img from coins WHERE coin = @coinname";
                    using(SQLiteCommand cmd = new SQLiteCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue(@"coinname", coinName);
                        image = (byte[])cmd.ExecuteScalar();
                    }

                }
                using (MemoryStream ms = new MemoryStream(image))
                {
                    img = Image.FromStream(ms);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return img;
        }

        public static List<Coin> GetCoins()
        {
            List<Coin> coinList = new List<Coin>();

            List<Coin> testList = new List<Coin>();
            try
            {
                using (SQLiteConnection con = new SQLiteConnection(coinsconnect))
                {
                    con.Open();

                    string query = "SELECT coin, price, income, img FROM coins";
                    using (SQLiteCommand cmd = new SQLiteCommand(query, con))
                    {
                        using (SQLiteDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string coin = reader.GetString(0);
                                double price = reader.GetDouble(1);
                                int income = reader.GetInt32(2);

                                /**
                                if ((byte[])reader["img"] != null)
                                {
                                   byte[] icon = (byte[])reader["img"];
                                   Coin c = new Coin(coin, price, income, icon);
                                   coinList.Add(c);
                                }
                                **/
                                byte[] icon = reader.IsDBNull(3) ? null : (byte[])reader["img"];

                                //Coin c = new Coin(coin, price, income, icon);
                                Coin testCoin = new Coin(coin, price, income);
                                //coinList.Add(c);
                                testList.Add(testCoin);

                            }
                        }
                    }
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }

            return testList;

        }

        public static double PriceCalc(double price, int numb)
        {
            return Math.Floor(price * Math.Pow(1.2, numb));
        }


        public static void RegPlayer(string username, string nick)
        {
            int id = -1;
            int userExists = -1;

            try
            {
                using (SQLiteConnection con = new SQLiteConnection(playersconnect))
                {
                    con.Open();
                    string checkQuery = "SELECT 1 FROM players WHERE username = @username LIMIT 1";
                    SQLiteCommand checkCmd = new SQLiteCommand(checkQuery, con);
                    checkCmd.Parameters.AddWithValue("@username", username);

                    userExists = Convert.ToInt32(checkCmd.ExecuteScalar());
                    con.Close();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR during user check: " + ex.Message);
            }

            if (userExists == 0)
            {
                using (SQLiteConnection pcon = new SQLiteConnection(playersconnect))
                using (SQLiteConnection acon = new SQLiteConnection(assetsconnect))
                {
                    pcon.Open();
                    acon.Open();

                    using (SQLiteTransaction ptrans = pcon.BeginTransaction())
                    using (SQLiteTransaction atrans = acon.BeginTransaction())
                    {
                        try
                        {
                            //REGISTERING PLAYER IN 'PLAYERS' DB
                            string regpquery = "INSERT INTO players (username, nickname, usdt, income, clickmine, online) VALUES (@username, @nickname, @usdt, @income, @clickmine, @online)";
                            var cmd = new SQLiteCommand(regpquery, pcon, ptrans);
                            cmd.Parameters.AddWithValue("@username", username);
                            cmd.Parameters.AddWithValue("@nickname", nick);
                            cmd.Parameters.AddWithValue("@usdt", 0);
                            cmd.Parameters.AddWithValue("@income", 0);
                            cmd.Parameters.AddWithValue("@clickmine", 1);
                            cmd.Parameters.AddWithValue("@online", DateTimeOffset.UtcNow.ToUnixTimeSeconds());
                            int success = cmd.ExecuteNonQuery();

                            if (success == 1)
                            {
                                //GETTING LAST REGISTERED ID FROM 'PLAYERS' DB
                                string lastID = "SELECT LAST_INSERT_ROWID();";
                                var cmd2 = new SQLiteCommand(lastID, pcon, ptrans);
                                id = Convert.ToInt32(cmd2.ExecuteScalar());
                                MessageBox.Show("Player registered successfully!");
                            }
                            else
                            {
                                MessageBox.Show("Registration went wrong :(");
                            }

                            //ADDING RECORD TO 'ASSETS' DB USING NEW PLAYERS ID
                            if(id > 0)
                            {
                                string regpassets = "INSERT INTO assets (id, Ada, TRX, Matic, DYDX, IMX, NEAR, ATOM, DOT, LINK, AVAX, AAVE, SOL, BNB, ETH, BTC) VALUES (@id, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)";
                                var cmd3 = new SQLiteCommand(regpassets, acon, atrans);
                                cmd3.Parameters.AddWithValue("@id", id);
                                cmd3.ExecuteNonQuery();

                            } else
                            {
                                MessageBox.Show($"Id was {id}. Not registered :(");
                            }
                           
                            ptrans.Commit();
                            atrans.Commit();
                        }
                        catch (Exception ex)
                        { 
                            ptrans.Rollback();
                            atrans.Rollback();
                            MessageBox.Show("Transaction failed: " + ex.Message); 
                        }
                    }

                }
               
            }
            else
            {
                MessageBox.Show("Error: user with such username already exists");
            }
        }

        public static Player LogPlayer(string username)
        {
            Player player = null;

            try
            {
                using (SQLiteConnection con = new SQLiteConnection(playersconnect))
                {
                    con.Open();

                    string query = "SELECT id, username, nickname, usdt, clickmine, online FROM players WHERE username = @username";
                    using (SQLiteCommand cmd = new SQLiteCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@username", username);
                        using (SQLiteDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int id = reader.GetInt32(0);
                                string usrname = reader.GetString(1);
                                string nickname = reader.GetString(2);
                                double usdt = reader.GetDouble(3);
                                double income = 0;
                                double clickmine = reader.GetDouble(4);
                                var off = reader.GetInt64(5);

                                player = new Player(id, usrname, nickname, usdt, income, clickmine, off);
                                //return player;
                            }
                        }
                    }
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }

            if (player != null)
            {
                return player;
            }
            else
            {
                throw new Exception("Players is null");
            }
        }


        public static int PlayerAssets(int id, string coinName)
        {
            int i = 0;
            try
            {
                using (SQLiteConnection con = new SQLiteConnection(assetsconnect))
                {
                    con.Open();
                    string query = $"SELECT {coinName} FROM assets WHERE id = @id";
                    using (SQLiteCommand cmd = new SQLiteCommand(query, con))
                    {
                        //cmd.Parameters.AddWithValue("@coinName", coinName);
                        cmd.Parameters.AddWithValue("@id", id);
                        using (SQLiteDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                i = reader.GetInt32(0);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return i;
        }

        public static void BuyCoin(string coinName, int id)
        {
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(assetsconnect))
                {
                    conn.Open();
                    string query = $"UPDATE assets SET {coinName} = {coinName} + 1 WHERE id = @id";

                    using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        int check = cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

    }
}