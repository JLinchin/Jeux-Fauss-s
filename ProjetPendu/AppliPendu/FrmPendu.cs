using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppliPendu
{
    public partial class FrmPendu : Form
    {
        public FrmPendu()
        {
            InitializeComponent();
        }

        //----------------------------------------------------
        // Phrase à trouver, nombre de coups joués et d'échecs
        //----------------------------------------------------
        string phrase;
        int coup;
        int echec;

        private void FrmPendu_Load(object sender, EventArgs e)
        {
            int i;      // Compteur
            string c;   // Caractère correspodant à la touche appuyée

            //-----------------
            // Démarrage du jeu
            //-----------------
            coup = 0;   // Nb. de coups
            echec = 0;  // Nb. d'échecs

            // On recherche aléatoirement une phrase parmi les 6
            // et on initialise la variable "Phrase"
            Random r = new Random();
            i = r.Next(1, 4);
            switch (i)
            {
                case 0:
                    phrase = "IL VA NEIGER";
                    break;
                case 1:
                    phrase = "BIENVENUE LES ETUDIANTS EN SLAM";
                    break;
                case 2:
                    phrase = "J\'AIME PROGRAMMER EN LANGAGE PYTHON!";
                    break;
                case 3:
                    phrase = "DEUX POINTS EN PLUS SI J\'APPORTE DES FRAISES TAGADA A MA PROF";
                    break;
                case 4:
                    phrase = "CINQ POINTS SI CE SONT DES PINK";
                    break;
                case 5:
                    phrase = "JE N\'OUBLIE PAS MA CLE USB EN COURS";
                    break;
            }
            MessageBox.Show("Phrase a trouver : " + phrase, "Le Pendu", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // On renseigne la zone "Phrase à deviner..."
            // Pour chaque caractère de 'Phrase', affichage d'un '#'
            // s'il est dans l'alphabet ou le caractère lui-même sinon
            for (i = 0; i <= phrase.Length - 1; i++)
            {
                // On extrait le caractère en cours
                c = phrase.Substring(i, 1);

                //---------------------------------------------------------------------
                // Pour les caractères de l'alphabet (A-Z)) on place un # dans le label
                //---------------------------------------------------------------------

                // Code ASCII du caractère
                // a. La chaîne est transformée en TABLEAU de caractères
                // b. On prend le 1er élément qui est un caractère
                // c. Le "cast" (int) donne son caode ASCII
                int code = (int)c.ToCharArray()[0];
                if (code >= 65 && code <= 90)
                    Label_Mot.Text += "#";
                else
                    // Pour les autres caractères on place le caractère lui même
                    Label_Mot.Text += c;
            }
        }

        private void FrmPendu_KeyPress(object sender, KeyPressEventArgs e)
        {
            bool trouve;
            bool deja;
            int i;
            string caractere;

            // Incrémentation du nombre de coups
            coup++;

            // Si minuscule, convertir en majuscule
            caractere = e.KeyChar.ToString().ToUpper();

            // Parcours du mot à la recherche du caractère saisi
            trouve = false;
            for (i = 0; i <= phrase.Length - 1; i++)
            {
                if (caractere == phrase.Substring(i, 1))
                    trouve = true;
            }

            // Affichage eventuel du caractère non trouvé dans la zone "Lettres absentes...."
            if (!trouve)
            {
                // Il ne faut l'afficher qu'une fois !
                deja = false;
                if (Label_Lettres.Text != "")
                {
                    for (i = 0; i <= Label_Lettres.Text.Length - 1; i++)
                    {
                        if (caractere == Label_Lettres.Text.Substring(i, 1))
                        {
                            deja = true;
                            break; // Casser la boucle !
                        }
                    }
                }

                // Si le caractère n'est pas déjà présent, on l'ajoute
                if (!deja)
                {
                    // Incrémentation du nombre d'échecs
                    echec++;
                    Label_Lettres.Text += caractere;
                }

            }

            // Perdu
            if (echec == 11)
            {
                MessageBox.Show("Vous avez perdu!!! Vous êtes mort!");
                Application.Exit();
            }

            
        }
    }
}
