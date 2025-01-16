using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using GroupBox = System.Windows.Forms.GroupBox;

namespace IdleBTClicker
{
    public partial class Upgrades : Form
    {
        Player p;
        CultureInfo usCulture = new CultureInfo("en-US");

        public Upgrades(Player player)
        {
            InitializeComponent();
            this.MaximizeBox = false;
            int stakemulti;
            p = player;
            money_lbl.Visible = false;
            //money_lbl.Text = "Available CASH: " + p.usdt.ToString("C0", usCulture);
            Draw();
        }

        public void Draw()
        {
            //RETRIEVE ALL UPGRADES FROM DB AND MAKE A LIST
            List<string> allupgrades = new List<string>();
            try
            {
                using (SQLiteConnection con = new SQLiteConnection(Program.upgradesconnect))
                {
                    con.Open();
                    string query = "SELECT name from upgrades";
                    using (SQLiteCommand com = new SQLiteCommand(query, con))
                    {
                        using (SQLiteDataReader reader = com.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                allupgrades.Add(reader["name"].ToString());
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to retried upgrade names " + ex.Message);
            }

            //DRAW GROUPBOX AND COMPONENTS FOR EVERY UPGRADE FROM LIST
            int y = 45;
            foreach (string upgrade in allupgrades) 
            { 
                GroupBox box = new GroupBox();
                box.Location = new Point(12, y);
                box.Name = upgrade;
                box.Size = new Size(560, 120);
                box.Text = "";
                box.ForeColor = Color.White;
                this.Controls.Add(box);

                int pgrade = Player.GetUpgradeLvl(p.id, upgrade);

                int x = 40;
                for (int i = 1; i <= 5; i++)
                {
                    Button button = new Button();
                    button.Name = i.ToString();
                    button.Location = new Point(x, 35);
                    button.Size = new Size(80, 50);
                    double p = GetGradePrice(upgrade, i);
                    button.ForeColor = Color.Gold;
                    button.Font = new Font("Ebrima", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
                    button.Text = Test.FormatNum(p, usCulture);
                    button.FlatStyle = FlatStyle.Standard;
                    button.Click += (sender, e) => { BuyUpgrade(sender, e, upgrade, Convert.ToInt32(button.Name)); };
                    if (pgrade >= i)
                    {
                        button.BackColor = Color.SpringGreen;
                        button.FlatStyle = FlatStyle.Flat;
                        button.Text = "Purchased";
                        button.Enabled = false;
                    } else
                    {
                        button.BackColor = Color.DarkRed;
                        button.Enabled = true;
                    }
                    box.Controls.Add(button);

                    Label bonus_lbl = new Label();
                    bonus_lbl.Location = new Point(x, 90);
                    bonus_lbl.AutoSize = false;
                    bonus_lbl.Size = new Size(80, 20);
                    bonus_lbl.TextAlign = ContentAlignment.MiddleCenter;
                    bonus_lbl.BorderStyle = BorderStyle.FixedSingle;
                    bonus_lbl.Text = MakeSuffix(upgrade, GetUpgradeBonus(upgrade, i));
                    bonus_lbl.ForeColor = Color.Gold;
                    bonus_lbl.Font = new Font("Ebrima", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
                    box.Controls.Add(bonus_lbl);

                    x += 100;
                }

                //LABEL WITH DESCRITPION
                Label desc = new Label();
                desc.Name = upgrade;
                desc.Tag = upgrade;
                desc.Location = new Point(10, 10);
                desc.AutoSize = true;
                desc.ForeColor = Color.Gold;
                desc.Font = new Font("Ebrima", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
                double d = GetUpgradeBonus(upgrade, Player.GetUpgradeLvl(Test.player.id, upgrade));
                desc.Text = $"{GetUpgradeDesc(upgrade)}. Current bonus: {MakeSuffix(upgrade, d)}";
                box.Controls.Add(desc);

                y += 125;
            }

        }

        public void BuyUpgrade(Object sender, EventArgs e, string upname, int tier)
        {
            double price = GetGradePrice(upname, tier);
            if (Test.player.usdt >= price && Player.PurchaseUpgrade(Test.player.id, upname, tier) == 1)
            {
                Test.player.usdt -= price;
                Test.usdtupdate();
                if (upname == "upstakemulti")
                {
                    Test.stakemulti = Upgrades.GetUpgradeBonus("upstakemulti", Player.GetUpgradeLvl(Test.player.id, "upstakemulti"));
                    Test.passiveIncUpd();
                } else if (upname == "upclickmulti")
                {
                    Test.clickmulti = Upgrades.GetUpgradeBonus("upclickmulti", Player.GetUpgradeLvl(Test.player.id, "upclickmulti"));
                    Test.cpc_lbl.Text = "Click mine: " + Test.FormatNum(Test.player.clickmine * Test.clickmulti, usCulture);
                } else if (upname ==  "upcoinprice")
                {
                    Test.pricediscount = 1 - Upgrades.GetUpgradeBonus("upcoinprice", Player.GetUpgradeLvl(Test.player.id, "upcoinprice"));
                    
                    foreach (Control ctrl in Test.panel.Controls)
                    {
                        ctrl.Dispose();
                    }
                    Test.panel.Controls.Clear();
                    Test.player.incpersec = 0;
                    Test.passiveIncUpd();
                    Test.ListCoins(Test.panel);
                }

                Button button = sender as Button;
                button.BackColor = Color.SpringGreen;
                button.FlatStyle = FlatStyle.Flat;
                button.Text = "Purchased";
                button.Enabled = false;

                GroupBox gp = button.Parent as GroupBox;
                if (gp != null && gp.Name == upname)
                {
                    Label label = gp.Controls[upname] as Label;
                    if (label != null)
                    {
                        double d = GetUpgradeBonus(upname, Player.GetUpgradeLvl(Test.player.id, upname));
                        label.Text = $"{GetUpgradeDesc(upname)}. Current bonus: {MakeSuffix(upname, d)}";
                    }
                } else
                {
                    MessageBox.Show($"Error changing upgrade description! GP name is {gp.Name}");
                }
               // money_lbl.Text = Test.player.usdt.ToString("C0", usCulture);
            }
        }

        public double GetGradePrice(string upgradename, int tier)
        {
            double price = 0;
            if (upgradename != null && tier > 0 && tier <= 5) {
                try
                {
                    using (SQLiteConnection con = new SQLiteConnection(Program.upgradesconnect))
                    {
                        con.Open();
                        string query = $"SELECT priceT{tier} from upgrades WHERE name = @upname";
                        using (SQLiteCommand cmd = new SQLiteCommand(query, con))
                        {
                            cmd.Parameters.AddWithValue("@upname", upgradename);
                            var obj = cmd.ExecuteScalar();
                            price = Convert.ToDouble(obj);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            } else
            {
                MessageBox.Show($"Error in GetGradePrice(). Name was {upgradename}. Upgrade tier {tier}");
            }
            return price;
        }

        public static double GetUpgradeBonus(string upgrade, int tier)
        {
            double bonus = 0;
            if (tier != 0)
            {
                try
                {
                    using (SQLiteConnection con = new SQLiteConnection(Program.upgradesconnect))
                    {
                        con.Open();
                        string query = $"SELECT T{tier} from upgrades WHERE name = @upgrade";
                        using (SQLiteCommand cmd = new SQLiteCommand(query, con))
                        {
                            cmd.Parameters.AddWithValue("@upgrade", upgrade);
                            var obj = cmd.ExecuteScalar();
                            bonus = Convert.ToDouble(obj);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error getting upgrade ({upgrade}) bonus" + ex.Message);
                }
                //MessageBox.Show($"Returned bonus {bonus.ToString("F1")} for upgrade {upgrade}");
            }
            return bonus;
        }

        public static string GetUpgradeDesc(string upgrade)
        {
            string desc = "";

            try
            {
                using(SQLiteConnection con = new SQLiteConnection(Program.upgradesconnect))
                {
                    con.Open();
                    string query = "SELECT description FROM upgrades WHERE name = @upgrade";
                    using (SQLiteCommand cmd = new SQLiteCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@upgrade", upgrade);
                        var obj = cmd.ExecuteScalar();
                        desc = (string)obj;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getting upgrade description " + ex.Message);
            }
            return desc;
        }

        public string MakeSuffix(string upgrade, double bonus)
        {
            string suffix;
            switch (upgrade)
            {
                case "upclickmulti":
                    suffix = "x" + bonus.ToString();
                    break;
                case "upoffhours":
                    suffix = bonus.ToString() + " hours";
                    break;
                case "upstakemulti":
                    suffix = "x" + bonus.ToString();
                    break;
                case "upcoinprice":
                    suffix = (bonus * 100).ToString() + "%";
                    break;
                default:
                    suffix = "Oops :(";
                    break;
            }
            return suffix;
        }

        private void done_btn_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
