using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace BoosterBoxer
{
    public partial class frm_selector : Form
    {
        List<CardSet> sets;
        string dbpath;

        public frm_selector()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            sets = new List<CardSet>();
            dbpath = Environment.CurrentDirectory + "\\sets.db";

            if (File.Exists(dbpath))
            {
                string version;
                string latestVersion;
                //check latest db version from string stored at clefable.net
                using (SQLiteConnection conn = new SQLiteConnection("Data Source=" + dbpath + ";"))
                {
                    using (SQLiteCommand cmd = new SQLiteCommand("SELECT * FROM Version", conn))
                    {
                        conn.Open();
                        using (SQLiteDataReader reader = cmd.ExecuteReader())
                        {
                            reader.Read();
                            version = reader.GetString(0);
                        }
                    }
                }
                using (var client = new WebClient())
                {
                    Stream stream = client.OpenRead("http://clefable.net/booster/version");
                    StreamReader reader = new StreamReader(stream);
                    latestVersion = reader.ReadToEnd();
                    client.Dispose();
                }
                if(version != latestVersion)
                {
                    DialogResult downloadDb = MessageBox.Show("There is a database update available! Would you like to update?", "Database Update!", MessageBoxButtons.YesNo);
                    if(downloadDb == DialogResult.Yes)
                    {
                        DownloadDb();
                    }
                }
                ImportDatabase();
            }
            else
            {
                DialogResult downloadDb = MessageBox.Show("Could not find database file.\nWould you like to download the latest version?", "No Database!", MessageBoxButtons.YesNo);
                if(downloadDb == DialogResult.Yes)
                {
                    DownloadDb();
                    ImportDatabase();
                }
                else
                {
                    MessageBox.Show("The application cannot continue without the database file.\nBoosterBoxer will now close.", "No Database!", MessageBoxButtons.OK);
                    Application.Exit();
                }
            }
        }

        private void ImportDatabase()
        {
            using (SQLiteConnection conn = new SQLiteConnection("Data Source=" + dbpath + ";"))
            {
                //get set information
                using (SQLiteCommand cmd = new SQLiteCommand("SELECT * FROM Sets", conn))
                {
                    conn.Open();
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            CardSet set = new CardSet(reader.GetString(0), reader.GetString(1), reader.GetInt32(2));
                            sets.Add(set);
                        }
                    }
                    conn.Close();
                }
            }
            lbxSets.DataSource = sets;
            lbxSets.DisplayMember = "toString";
            lblNoCards.Text = $"Opening {nudPacksToOpen.Value} packs will \nnet {nudPacksToOpen.Value * sets[lbxSets.SelectedIndex].getCardsPerPack()} cards.";
        }

        private void DownloadDb()
        {
            using (var client = new WebClient())
            {
                client.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/46.0.2490.33 Safari/537.36");
                client.DownloadFile("http://clefable.net/booster/sets.db", "sets.db");
                client.Dispose();
            }
        }

        private void lbxSets_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblNoCards.Text = $"Opening {nudPacksToOpen.Value} packs will \nnet {nudPacksToOpen.Value * sets[lbxSets.SelectedIndex].getCardsPerPack()} cards.";
        }

        private void nudPacksToOpen_ValueChanged(object sender, EventArgs e)
        {
            lblNoCards.Text = $"Opening {nudPacksToOpen.Value} packs will \nnet {nudPacksToOpen.Value * sets[lbxSets.SelectedIndex].getCardsPerPack()} cards.";
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            CardSet selectedSet = sets[lbxSets.SelectedIndex];
            frm_viewer frm2 = new frm_viewer(selectedSet, (int)nudPacksToOpen.Value);
            frm2.Show();
        }
    }
}
