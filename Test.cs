﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Timers;
using System.Threading.Tasks;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace IdleBTClicker
{
    public partial class Test : Form
    {
        //List<Coin> coinList = new List<Coin>() { new Coin("Ada", 100, 1), new Coin("TRX", 250, 3), new Coin("Matic", 1000, 7), new Coin("DYDX", 5000, 10) };
        public static List<Coin> coinList = Program.GetCoins();
        System.Windows.Forms.Timer timer;
        public static Player? player;
        static CultureInfo usCulture = new CultureInfo("en-US");

        public static double clickmulti;
        public static double offhours;
        public static double stakemulti;
        public static double pricediscount;


        //Creating dynamic labels
        static Label usdt = new Label();
        static Label passive_inc = new Label();
        public static Label cpc_lbl = new();


        //Lists and variables for animation
        private List<Label> activeLabels = new List<Label>();
        private List<System.Windows.Forms.Timer> activeTimers = new List<System.Windows.Forms.Timer>();
        private float opacity = 1.0f;

        public Test(Player p)
        {

            InitializeComponent();
            this.MaximizeBox = false;
            this.FormClosing += new FormClosingEventHandler(QuitGame);
            player = p;

            clickmulti = Player.GetUpgradeLvl(player.id, "upclickmulti") > 0 ? Upgrades.GetUpgradeBonus("upclickmulti", Player.GetUpgradeLvl(player.id, "upclickmulti")) : 1;
            offhours = Player.GetUpgradeLvl(player.id, "upoffhours") > 0 ? Upgrades.GetUpgradeBonus("upoffhours", Player.GetUpgradeLvl(player.id, "upoffhours")) : 2;
            stakemulti = Player.GetUpgradeLvl(player.id, "upstakemulti") > 0 ? Upgrades.GetUpgradeBonus("upstakemulti", Player.GetUpgradeLvl(player.id, "upstakemulti")) : 1;
            pricediscount = 1 - Upgrades.GetUpgradeBonus("upcoinprice", Player.GetUpgradeLvl(player.id, "upcoinprice"));

            foreach (Coin c in coinList)
            {
                c.price = Program.PriceCalc(c.price, Program.PlayerAssets(player.id, c.name));
            }


            //db_test.Visible = false;

            usdt.ForeColor = Color.SpringGreen;
            usdt.Font = new Font("Ebrima", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            //usdt.Location = new Point(12, 9);
            usdt.AutoSize = true;
            usdt.Dock = DockStyle.Fill;
            usdt.TextAlign = ContentAlignment.TopCenter;
            usdt.Anchor = AnchorStyles.Top;
            usdt.Text = $"USDT: {player.usdt.ToString("C0", usCulture)}";
            t_layout2.Controls.Add(usdt, 0, 0);
            //Controls.Add(usdt);

            passive_inc.ForeColor = Color.Gold;
            passive_inc.Font = new Font("Ebrima", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            //passive_inc.Location = new Point(18, 356);
            passive_inc.Dock = DockStyle.Fill;
            passive_inc.AutoSize = true;
            passive_inc.TextAlign = ContentAlignment.MiddleCenter;
            passive_inc.Anchor = AnchorStyles.Bottom;
            passive_inc.Text = "Passive income: " + (player.incpersec * stakemulti).ToString("C0", usCulture);
            t_layout2.Controls.Add(passive_inc, 0, 1);
            //Controls.Add(passive_inc);

            cpc_lbl.ForeColor = Color.Gold;
            cpc_lbl.BackColor = Color.Transparent;
            cpc_lbl.Font = new Font("Ebrima", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            //cpc_lbl.Location = new Point(383, 356);
            cpc_lbl.Dock = DockStyle.Fill;
            cpc_lbl.AutoSize = true;
            cpc_lbl.TextAlign = ContentAlignment.BottomRight;
            cpc_lbl.Anchor = AnchorStyles.Bottom;
            cpc_lbl.Text = "Click mine: " + FormatNum(player.clickmine * clickmulti, usCulture);
            layout_table.Controls.Add(cpc_lbl, 1, 2);
            //Controls.Add(cpc_lbl);

            /*
            panel.AutoSizeMode = AutoSizeMode.GrowOnly;
            panel.AutoSize = true;
            panel.Location = new Point(6, 22);
            panel.Size = new Size(548, 291);
            panel.AutoScroll = true;
            assetbox.Controls.Add(panel);
            */


            main_btn.FlatAppearance.MouseOverBackColor = Color.Transparent;
            main_btn.FlatAppearance.MouseDownBackColor = Color.Transparent;
            panel.HorizontalScroll.Enabled = false;


            Program.clickUpPrice = Math.Floor(Program.clickUpPrice * Math.Pow(1.75, player.clickmine));
            clicklvl.Text = "Level Up\n" + FormatNum(Program.clickUpPrice, usCulture);
            ListCoins(panel);

            //Timer for passive income addition to players balance each second
            timer = new System.Windows.Forms.Timer();
            timer.Interval = 1000;
            timer.Tick += Timer_Tick;
            timer.Start();

            var secspast = DateTimeOffset.UtcNow.ToUnixTimeSeconds() - player.offlinefor;
            if (secspast >= (offhours * 3600))
            {
                player.usdt += player.incpersec * (offhours * 3600);
                var i = player.incpersec * (offhours * 3600);
                MessageBox.Show($"You mined {i.ToString("C0", usCulture)} USDT in offline mode! {pricediscount}");
            }
            else
            {
                player.usdt += (secspast * player.incpersec);
                var i = secspast * player.incpersec;
                MessageBox.Show($"You mined {i.ToString("C0", usCulture)} USDT in offline mode! {pricediscount}");
            }
            usdtupdate();
        }

        private void Timer_Tick(object? sender, EventArgs e)
        {
            player.usdt += player.incpersec * stakemulti;
            usdtupdate();
        }

        /*
        private void Timer_Elapsed(object sender, EventArgs e)
        {
            player.usdt += player.incpersec * stakemulti;
            usdtupdate();
        }
        */

        private void main_btn_Click(object sender, EventArgs e)
        {
            player.usdt += player.clickmine * clickmulti;
            usdtupdate();
            //Animate();
        }


        private void QuitGame(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to exit? \nGame will automatically save your progress.", "Exit Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.No)
            {
                e.Cancel = true;
            }
            else
            {
                try
                {
                    using (SQLiteConnection con = new SQLiteConnection(Program.playersconnect))
                    {
                        con.Open();

                        string query = "UPDATE players SET usdt = @usdt, income = @income, clickmine = @clickmine, online = @online WHERE id = @id";
                        using (SQLiteCommand cmd = new SQLiteCommand(query, con))
                        {
                            cmd.Parameters.AddWithValue("@usdt", player.usdt);
                            cmd.Parameters.AddWithValue("@income", player.incpersec);
                            cmd.Parameters.AddWithValue("@clickmine", player.clickmine);
                            cmd.Parameters.AddWithValue("@online", DateTimeOffset.UtcNow.ToUnixTimeSeconds());
                            cmd.Parameters.AddWithValue("@id", player.id);
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                Application.Exit();
            }
        }

        private void clicklvl_Click(object sender, EventArgs e)
        {
            if (player.usdt >= Program.clickUpPrice)
            {
                player.usdt -= Program.clickUpPrice;
                player.clickmine++;
                Program.clickUpPrice = Math.Floor(Program.clickUpPrice * 1.75);
                ButtonTxtUpdate(clicklvl, Program.clickUpPrice);
                cpc_lbl.Text = "Click mine: " + (player.clickmine * clickmulti).ToString("C0", usCulture);
                usdtupdate();
            }
        }


        //                                                      <<< UTILITY Methods >>>
        private void ButtonTxtUpdate(Button button, double price)
        {
            button.Text = "Level Up\n" + price.ToString("C0", usCulture);
        }
        public static void usdtupdate()
        {
            usdt.Text = $"USDT: {player.usdt.ToString("C0", usCulture)}";
            usdt.Invalidate();
        }

        public static void passiveIncUpd()
        {
            CultureInfo usCulture = new CultureInfo("en-US");
            passive_inc.Text = "Passive income: " + (player.incpersec * stakemulti).ToString("C0", usCulture);
        }



        //                                                      Drawing panel with coins:
        public static void ListCoins(Panel panel)
        {
            int x = 1;
            int y = 1;

            foreach (Coin c in coinList)
            {
                //Coin Groupbox
                GroupBox box = new GroupBox();
                box.Name = c.name;
                box.Text = "";
                panel.Controls.Add(box);
                box.Location = new Point(x, y);
                box.Size = new Size(box.Parent.Width - 25, 85);
                box.Margin = new Padding(0, 0, 0, 0);

                //icon picture box
                PictureBox pb = new PictureBox
                {
                    SizeMode = PictureBoxSizeMode.Zoom,
                    Location = new Point(5, 15),
                    Size = new Size(60, 60),
                    Padding = new Padding(0),
                    Margin = new Padding(0),
                    Image = Program.GetImage(c.name)
                };
                box.Controls.Add(pb);

                //Name label
                Label lbl = new Label
                {
                    Text = c.name,
                    ForeColor = Color.Gold,
                    Font = new Font("Ebrima", 11F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 0),
                    Location = new Point(80, 15)
                };
                box.Controls.Add(lbl);

                //Income per 1 coin label
                Label cincome = new Label
                {
                    AutoSize = true,
                    ForeColor = Color.SpringGreen,
                    Font = new Font("Ebrima", 9F, FontStyle.Bold, GraphicsUnit.Point, 0),
                    Location = new Point(80, 45),
                    Text = $"+ {c.income} USDT/s"
                };
                box.Controls.Add(cincome);

                //Amount of coins owned label
                Label amount = new Label
                {
                    Name = c.name,
                    AutoSize = true,
                    ForeColor = Color.SpringGreen,
                    Font = new Font("Ebrima", 9F, FontStyle.Bold, GraphicsUnit.Point, 0),
                    Location = new Point(80, 60)
                };
                double i = (Program.PlayerAssets(player.id, c.name) * c.income);
                player.incpersec += i;
                passiveIncUpd();
                amount.Text = $"Owned: {Program.PlayerAssets(player.id, c.name)} (+{i} USDT/s)";
                box.Controls.Add(amount);

                /**Label with Staking income from coin
                Label stake = new Label
                {
                    Text = $"Staking income: {(i * c.income).ToString("C0", usCulture)}",
                    AutoSize = true,
                    ForeColor = Color.Gold,
                    Font = new Font("Ebrima", 10F, FontStyle.Bold, GraphicsUnit.Point, 0),
                    Location = new Point(80, 55)
                };
                box.Controls.Add(stake);
                **/

                //'Buy' button
                Button button = new Button();
                button.Size = new Size(90, 55);
                //button.Margin = new Padding(0, 15, 0, 15);

                button.BackColor = Color.Cyan;
                button.ForeColor = Color.DarkGreen;
                button.Location = new Point(450, 20);
                button.Text = "Buy\n" + FormatNum(c.price * pricediscount, usCulture);
                button.Font = new Font("Ebrima", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
                box.Controls.Add(button);
                button.Click += (sender, e) => { BuyCoin(sender, e, c, amount); };

                y += 80;
            }
        }

        public static void BuyCoin(Object sender, EventArgs e, Coin coin, Label amount)
        {
            if (player.usdt >= coin.price * pricediscount)
            {
                player.usdt -= coin.price * pricediscount;
                Program.BuyCoin(coin.name, player.id);
                usdtupdate();
                player.incpersec += coin.income;
                passiveIncUpd();
                coin.price = coin.price * 1.2;

                Button button = sender as Button;
                button.Text = "Buy\n" + FormatNum(coin.price * pricediscount, usCulture);

                amount.Text = $"Owned: {Program.PlayerAssets(player.id, coin.name)} (+{Program.PlayerAssets(player.id, coin.name) * coin.income} USDT/s)";

            }

        }


        public static string FormatNum(double num, CultureInfo culture)
        {
            if (num >= 1_000_000_000)
            {
                return "$" + (num / 1_000_000_000).ToString("0.0#", culture) + "Bil";
            }
            else if (num >= 1_000_000)
            {
                return "$" + (num / 1_000_000).ToString("0.0#", culture) + "Mil";
            }
            else if (num >= 100_000)
            {
                return "$" + (num / 1_000).ToString("000.#", culture) + "k";
            }
            else
            {
                return "$" + num.ToString(culture);
            }
        }

        private void db_test_Click(object sender, EventArgs e)
        {
            StringBuilder ss = new StringBuilder();
            foreach (Coin c in Program.GetCoins())
            {
                ss.Append(c.name + " " + c.price + " " + c.income);
                ss.Append('\n');
            }
            MessageBox.Show(ss.ToString());
        }

        private void cpc_lbl_Click(object sender, EventArgs e)
        {

        }

        private void viptab_Click(object sender, EventArgs e)
        {
            var up = new Upgrades(player);
            up.Show();
        }

        private void passive_inc_Click(object sender, EventArgs e)
        {

        }



        private void Animate()
        {          
            Point cursorPosition = this.PointToClient(Cursor.Position);

            //Label settings
            Label newLabel = new Label();
            newLabel.Text = $" +{player.clickmine + clickmulti}$";
            newLabel.AutoSize = true;
            newLabel.Location = cursorPosition;
            newLabel.Visible = true;
            newLabel.ForeColor = Color.SpringGreen;
            newLabel.BackColor = Color.Transparent;
            newLabel.Parent = this;

            this.Controls.Add(newLabel);
            //this.Controls.SetChildIndex(newLabel, 0);
            newLabel.BringToFront();
            activeLabels.Add(newLabel);

            System.Windows.Forms.Timer lblTimer = new System.Windows.Forms.Timer();
            lblTimer.Interval = 20;
            lblTimer.Tag = newLabel;
            lblTimer.Tick += (s, args) =>
            {
                Label label = (Label)((System.Windows.Forms.Timer)s).Tag;

                //Label movement
                label.Location = new Point(label.Location.X, label.Location.Y - 2);

                //Label opacity
                opacity -= 0.05f;
                label.ForeColor = Color.FromArgb((int)(opacity * 255), label.ForeColor.R, label.ForeColor.G, label.ForeColor.B);

                //Hide label when opacity reaches 0, then refresh opacity
                if (opacity <= 0)
                {
                    label.Visible = false;
                    lblTimer.Stop();
                    activeTimers.Remove(lblTimer);
                    activeLabels.Remove(label);
                    opacity = 1.0f;
                }
            };
            lblTimer.Start();
            activeTimers.Add(lblTimer);
        }
    }
}
