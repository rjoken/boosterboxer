using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace BoosterBoxer
{
    public partial class frm_selector : Form
    {
        List<CardSet> sets;

        public frm_selector()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            sets = new List<CardSet>();
            string dbpath = Environment.CurrentDirectory + "\\sets.db";

            if (File.Exists(dbpath))
            {
                using (SQLiteConnection conn = new SQLiteConnection("Data Source=" + dbpath + ";"))
                {
                    //get set information
                    using (SQLiteCommand cmd = new SQLiteCommand("SELECT * FROM Sets", conn))
                    {
                        conn.Open();
                        using (SQLiteDataReader reader = cmd.ExecuteReader())
                        {
                            while(reader.Read())
                            {
                                CardSet set = new CardSet(reader.GetString(0), reader.GetString(1), reader.GetInt32(2));
                                sets.Add(set);
                            }
                        }
                        conn.Close();
                    }
                }
            }
            else
            {
                MessageBox.Show("Could not find database file.", "Error 1", MessageBoxButtons.OK);
                Application.Exit();
            }

            lbxSets.DataSource = sets;
            lbxSets.DisplayMember = "toString";
            lblNoCards.Text = $"Opening {nudPacksToOpen.Value} packs will \nnet {nudPacksToOpen.Value * sets[lbxSets.SelectedIndex].getCardsPerPack()} cards.";
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
