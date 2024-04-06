using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormMorpion
{
    public partial class FrmMorpion : Form
    {
        //Variables globales
        //Couleur juste : 255;113;78
        //Couleur normale : 35;40;45
        int tour = 0;
        int[,] tab = new int[3, 3];
        PictureBox[,] tabPct = new PictureBox[3, 3];
        PictureBox[,] tabPctRep = new PictureBox[3, 3];

        public FrmMorpion()
        {
            InitializeComponent();
            PctRep11.Visible = false;
            PctRep12.Visible = false;
            PctRep13.Visible = false;
            PctRep21.Visible = false;
            PctRep22.Visible = false;
            PctRep23.Visible = false;
            PctRep31.Visible = false;
            PctRep32.Visible = false;
            PctRep33.Visible = false;

            tabPctRep[0, 0] = PctRep11;
            tabPctRep[0, 1] = PctRep12;
            tabPctRep[0, 2] = PctRep13;
            tabPctRep[1, 0] = PctRep21;
            tabPctRep[1, 1] = PctRep22;
            tabPctRep[1, 2] = PctRep23;
            tabPctRep[2, 0] = PctRep31;
            tabPctRep[2, 1] = PctRep32;
            tabPctRep[2, 2] = PctRep33;

            tabPct[0, 0] = Pct11;
            tabPct[0, 1] = Pct12;
            tabPct[0, 2] = Pct13;
            tabPct[1, 0] = Pct21;
            tabPct[1, 1] = Pct22;
            tabPct[1, 2] = Pct23;
            tabPct[2, 0] = Pct31;
            tabPct[2, 1] = Pct32;
            tabPct[2, 2] = Pct33;

            tab = GenerTab(tab);
        }

        private int[,] GenerTab(int[,] tab)
        {
            for (int i = 0; i <= 2; i++)
                for (int j = 0; j <= 2; j++)
                    tab[i, j] = 10;

            return tab;
        }

        private void Bouton(PictureBox button)
        {
            if (!button.Visible)
            {
                if (tour == 0)
                {
                    button.Image = Properties.Resources.O;
                    tour = 1;
                }
                else
                {
                    button.Image = Properties.Resources.X;
                    tour = 0;
                }
            }
            button.Visible = true;
        }

        private void Victoire(PictureBox[,] pctBox)
        {
            for (int i = 0; i <= 2; i++)
                if (tab[i, 0] + tab[i, 1] + tab[i, 2] == 3 * tour)
                {
                    tabPctRep[i, 0].BackColor = Color.FromArgb(255, 113, 78);
                    tabPctRep[i, 1].BackColor = Color.FromArgb(255, 113, 78);
                    tabPctRep[i, 2].BackColor = Color.FromArgb(255, 113, 78);

                    tabPct[i, 0].Image = Properties.Resources.Carré_victoire;
                    tabPct[i, 1].Image = Properties.Resources.Carré_victoire;
                    tabPct[i, 2].Image = Properties.Resources.Carré_victoire;
                }

            for (int j = 0; j <= 2; j++)
                if (tab[0, j] + tab[1, j] + tab[2, j] == 3 * tour)
                {
                    tabPctRep[0, j].BackColor = Color.FromArgb(255, 113, 78);
                    tabPctRep[1, j].BackColor = Color.FromArgb(255, 113, 78);
                    tabPctRep[2, j].BackColor = Color.FromArgb(255, 113, 78);

                    tabPct[0, j].Image = Properties.Resources.Carré_victoire;
                    tabPct[1, j].Image = Properties.Resources.Carré_victoire;
                    tabPct[2, j].Image = Properties.Resources.Carré_victoire;
                }

            if (tab[0, 0] + tab[1, 1] + tab[2, 2] == 3 * tour)
            {
                tabPctRep[0, 0].BackColor = Color.FromArgb(255, 113, 78);
                tabPctRep[1, 1].BackColor = Color.FromArgb(255, 113, 78);
                tabPctRep[2, 2].BackColor = Color.FromArgb(255, 113, 78);

                tabPct[0, 0].Image = Properties.Resources.Carré_victoire;
                tabPct[1, 1].Image = Properties.Resources.Carré_victoire;
                tabPct[2, 2].Image = Properties.Resources.Carré_victoire;
            }

            if (tab[0, 2] + tab[1, 1] + tab[2, 0] == 3 * tour)
            {
                tabPctRep[0, 2].BackColor = Color.FromArgb(255, 113, 78);
                tabPctRep[1, 1].BackColor = Color.FromArgb(255, 113, 78);
                tabPctRep[2, 0].BackColor = Color.FromArgb(255, 113, 78);

                tabPct[0, 2].Image = Properties.Resources.Carré_victoire;
                tabPct[1, 1].Image = Properties.Resources.Carré_victoire;
                tabPct[2, 0].Image = Properties.Resources.Carré_victoire;
            }

            for (int i = 0; i < 2; i++)
                for (int j = 0; j < 2; j++)
                    tabPct[i, j].Enabled = false;
        }

        private bool TestGagne(int[,] tab)
        {
            bool res = false;

            for (int i = 0; i <= 2; i++)
                for (int j = 0; j <= 2; j++)
                    if (tab[i, 0] + tab[i, 1] + tab[i, 2] == 3 * tour ||
                     tab[0, j] + tab[1, j] + tab[2, j] == 3 * tour ||
                     tab[0, 0] + tab[1, 1] + tab[2, 2] == 3 * tour ||
                     tab[0, 2] + tab[1, 1] + tab[2, 0] == 3 * tour)
                        res = true;

            if (res)
                MessageBox.Show($"Le joueur {tour + 1} à gagné !");
            Victoire(tabPctRep);
            return res;
        }

        private void Pct11_Click(object sender, EventArgs e)
        {
            tab[0, 0] = tour;
            Bouton(PctRep11);
            TestGagne(tab);
        }

        private void Pct12_Click(object sender, EventArgs e)
        {
            tab[0, 1] = tour;
            Bouton(PctRep12);
            TestGagne(tab);
        }

        private void Pct13_Click(object sender, EventArgs e)
        {
            tab[0, 2] = tour;
            Bouton(PctRep13);
            TestGagne(tab);
        }

        private void Pct21_Click(object sender, EventArgs e)
        {
            tab[1, 0] = tour;
            Bouton(PctRep21);
            TestGagne(tab);
        }

        private void Pct22_Click(object sender, EventArgs e)
        {
            tab[1, 1] = tour;
            Bouton(PctRep22);
            TestGagne(tab);
        }

        private void Pct23_Click(object sender, EventArgs e)
        {
            tab[1, 2] = tour;
            Bouton(PctRep23);
            TestGagne(tab);
        }

        private void Pct31_Click(object sender, EventArgs e)
        {
            tab[2, 0] = tour;
            Bouton(PctRep31);
            TestGagne(tab);
        }

        private void Pct32_Click(object sender, EventArgs e)
        {
            tab[2, 1] = tour;
            Bouton(PctRep32);
            TestGagne(tab);
        }

        private void Pct33_Click(object sender, EventArgs e)
        {
            tab[2, 2] = tour;
            Bouton(PctRep33);
            TestGagne(tab);
        }

        private void BtnRestart_Click(object sender, EventArgs e)
        {
            PctRep11.Visible = false;
            PctRep12.Visible = false;
            PctRep13.Visible = false;
            PctRep21.Visible = false;
            PctRep22.Visible = false;
            PctRep23.Visible = false;
            PctRep31.Visible = false;
            PctRep32.Visible = false;
            PctRep33.Visible = false;

            Pct11.Enabled = true;
            Pct12.Enabled = true;
            Pct13.Enabled = true;
            Pct21.Enabled = true;
            Pct22.Enabled = true;
            Pct23.Enabled = true;
            Pct31.Enabled = true;
            Pct32.Enabled = true;
            Pct31.Enabled = true;

            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    tabPctRep[i, j].BackColor = Color.FromArgb(35, 40, 45);

            tabPct[0, 0].Image = Properties.Resources.Carré_haut_gauche;
            tabPct[0, 1].Image = Properties.Resources.Carré_haut_milieu;
            tabPct[0, 2].Image = Properties.Resources.Carré_haut_droite;
            tabPct[1, 0].Image = Properties.Resources.Carré_centre_gauche;
            tabPct[1, 1].Image = Properties.Resources.Carré_centre_milieu;
            tabPct[1, 2].Image = Properties.Resources.Carré_centre_droite;
            tabPct[2, 0].Image = Properties.Resources.Carré_bas_gauche;
            tabPct[2, 1].Image = Properties.Resources.Carré_bas_milieu;
            tabPct[2, 2].Image = Properties.Resources.Carré_bas_droite;

            tab = GenerTab(tab);
            tour = 0;
        }
    }
}
