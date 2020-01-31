using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BoosterBoxer
{
    public partial class frm_viewer : Form
    {
        CardSet selectedSet;
        List<Card> setCards;
        List<Card> commons;
        List<Card> shortprints;
        List<Card> supershortprints;
        List<Card> rares;
        List<Card> supers;
        List<Card> ultras;
        List<Card> secrets;
        List<Card> pulls;
        List<Card> sorted;
        static Random RNG;
        int packsToOpen;

        public frm_viewer(CardSet selectedSet, int packsToOpen)
        {
            this.selectedSet = selectedSet;
            this.packsToOpen = packsToOpen;
            setCards = new List<Card>();
            commons = new List<Card>();
            shortprints = new List<Card>();
            supershortprints = new List<Card>();
            rares = new List<Card>();
            supers = new List<Card>();
            ultras = new List<Card>();
            secrets = new List<Card>();
            pulls = new List<Card>();
            RNG = new Random();
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            string dbpath = Environment.CurrentDirectory + "\\sets.db";
            if (File.Exists(dbpath))
            {
                using (SQLiteConnection conn = new SQLiteConnection("Data Source=" + dbpath + ";"))
                {
                    using (SQLiteCommand cmd = new SQLiteCommand($"SELECT * FROM {selectedSet.getAbbreviation}", conn))
                    {
                        conn.Open();
                        using (SQLiteDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Card card = new Card(reader.GetString(0), reader.GetString(1),
                                    Consts.getCardTypeByStringValue(reader.GetString(2)),
                                    Consts.getRarityByStringValue(reader.GetString(3)),
                                    Consts.getAttribByStringValue(reader.GetString(4)),
                                    Consts.getClassByStringValue(reader.GetString(5)),
                                    reader.GetString(6), reader.GetString(7), reader.GetString(8), reader.GetString(9));
                                setCards.Add(card);
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


            foreach (Card c in setCards)
            {
                if (c.getRarity() == Consts.Rarity.Common)
                {
                    commons.Add(c);
                }
                else if (c.getRarity() == Consts.Rarity.ShortPrint)
                {
                    shortprints.Add(c);
                }
                else if (c.getRarity() == Consts.Rarity.SuperShortPrint)
                {
                    supershortprints.Add(c);
                }
                else if ((c.getRarity() == Consts.Rarity.Rare) || (c.getRarity() == Consts.Rarity.RareUltimate))
                {
                    rares.Add(c);
                }
                else if ((c.getRarity() == Consts.Rarity.SuperRare) || (c.getRarity() == Consts.Rarity.SuperUltimate))
                {
                    supers.Add(c);
                }
                else if ((c.getRarity() == Consts.Rarity.UltraRare) || (c.getRarity() == Consts.Rarity.UltraUltimate))
                {
                    ultras.Add(c);
                }
                else if (c.getRarity() == Consts.Rarity.SecretRare)
                {
                    secrets.Add(c);
                }
                else
                {
                    commons.Add(c);
                }
            }

            for (int i = 0; i < packsToOpen; i++)
            {
                foreach (Card c in openPack(setCards))
                {
                    pulls.Add(c);
                }
            }

            lbxCards.DataSource = pulls;
            lbxCards.DisplayMember = "displayName";

        }

        private void updateDetails()
        {
            string cardTextNoBackslash = pulls[lbxCards.SelectedIndex].getCardText().Replace("\\", String.Empty);
            lblName.Text = pulls[lbxCards.SelectedIndex].displayName;
            rtbDesc.Text = $"{pulls[lbxCards.SelectedIndex].getCardID()}\n{Consts.GetStringValue(pulls[lbxCards.SelectedIndex].getAttrib())} {Consts.GetStringValue(pulls[lbxCards.SelectedIndex].getClass())} {Consts.GetStringValue(pulls[lbxCards.SelectedIndex].getType())}\n{cardTextNoBackslash}";
            lblAtk.Text = $"ATK {pulls[lbxCards.SelectedIndex].getAttack()}";
            lblDef.Text = $"DEF {pulls[lbxCards.SelectedIndex].getDefense()}";
            lblRarity.Text = $"Rarity: {Consts.GetStringValue(pulls[lbxCards.SelectedIndex].getRarity())}";
        }

        public List<Card> openPack(List<Card> setCards)
        {
            List<Card> pulls = new List<Card>();
            bool hasSP = false;
            bool hasSSP = false;
            //select commons

            //determine if pack will contain a shortprint
            if (supershortprints.Count > 0)
            {
                if (RNG.Next(0, 4) == 0)
                {
                    hasSSP = true;
                }
            }
            if (shortprints.Count > 0)
            {
                if (RNG.Next(0, 2) == 0)
                {
                    hasSP = true;
                }
            }
            for (int i = 0; i < selectedSet.getCardsPerPack() - 1; i++)
            {
                if (hasSP)
                {
                    pulls.Add(shortprints[RNG.Next(0, shortprints.Count - 1)]);
                    hasSP = false;
                    continue;
                }
                if (hasSSP)
                {
                    pulls.Add(supershortprints[RNG.Next(0, supershortprints.Count - 1)]);
                    hasSSP = false;
                    continue;
                }
                else
                {
                    pulls.Add(commons[RNG.Next(0, commons.Count - 1)]);
                }
            }

            //determine rare
            if (secrets.Count > 0 && RNG.Next(0, 30) == 0)
            {
                pulls.Add(secrets[RNG.Next(0, secrets.Count - 1)]);
            }
            else if (ultras.Count > 0 && RNG.Next(0, 23) == 0)
            {
                pulls.Add(ultras[RNG.Next(0, ultras.Count - 1)]);
            }
            else if (supers.Count > 0 && RNG.Next(0, 4) == 0)
            {
                pulls.Add(supers[RNG.Next(0, supers.Count - 1)]);
            }
            else
            {
                pulls.Add(rares[RNG.Next(0, rares.Count - 1)]);
            }

            return pulls;
        }

        private void lbxCards_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateDetails();
        }

        private void btnSort_Click(object sender, EventArgs e)
        {
            sorted = pulls.OrderBy(x => x.getCardID()).ToList();
            pulls = new List<Card>(sorted);
            lbxCards.DataSource = pulls;
            lbxCards.SelectedIndex = 0;
            updateDetails();
        }

        private void btnSortRarity_Click(object sender, EventArgs e)
        {
            sorted = pulls.OrderBy(x => x.getRarity()).ToList();
            pulls = new List<Card>(sorted);
            lbxCards.DataSource = pulls;
            lbxCards.SelectedIndex = 0;
            updateDetails();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            string path;

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.InitialDirectory = Environment.CurrentDirectory;
            sfd.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            sfd.RestoreDirectory = true;

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                path = sfd.FileName;

                var fileStream = sfd.OpenFile();

                using (StreamWriter writer = new StreamWriter(fileStream))
                {
                    foreach(Card c in pulls)
                    {
                        writer.WriteLine(c.displayName);
                    }
                }
                MessageBox.Show("Cards exported!", "Status", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("The file was not saved.", "Status", MessageBoxButtons.OK);
            }
            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
