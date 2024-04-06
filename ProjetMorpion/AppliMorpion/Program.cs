using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppliMorpion
{
    class Program
    {
        // Programme principal
        static void Main(string[] args)
        {
            //--- Déclarations et initialisations --

            int[,] grille = new int[3, 3];     // matrice pour stocker les coups joués
            int joueur = 1;                    // 1 pour la premier joueur, 2 pour le second
            int l, c;                          // numéro de ligne et de colonne
            int j, k;                          // indices de parcours de matrice
            bool gagne = false;

            //--- Initialisation de la grille ---
            for (j = 0; j <= 2; j++)
                for (k = 0; k <= 2; k++)
                    grille[j, k] = 10;

            //--- Le jeu ---
            while (!gagne)
            {
                //--- Saisie de la position et contrôle de saisie ---
                Console.WriteLine("C'est au tour du joueur " + joueur);

                Console.Write("Ligne   =    "); l = int.Parse(Console.ReadLine());
                while (l > 3 || l < 1)
                {
                    Console.WriteLine("Erreur ! Vous devez saisir un nombre compris entre 1 et 3");
                    Console.Write("Ligne   =    "); l = int.Parse(Console.ReadLine());
                }

                Console.Write("Colonne =    "); c = int.Parse(Console.ReadLine());
                while (c > 3 || c < 1)
                {
                    Console.WriteLine("Erreur ! Vous devez saisir un nombre compris entre 1 et 3");
                    Console.Write("Colonne =    "); c = int.Parse(Console.ReadLine());
                }

                //--- Sauvegarde du nouveau coup joué ---

                while (grille[l - 1, c - 1] != 10)
                {
                    Console.WriteLine("Erreur ! La case est déjà prise ! ");

                    Console.Write("Ligne   =    "); l = int.Parse(Console.ReadLine());
                    while (l > 3 || l < 1)
                    {
                        Console.WriteLine("Erreur ! Vous devez saisir un nombre compris entre 1 et 3");
                        Console.Write("Ligne   =    "); l = int.Parse(Console.ReadLine());
                    }

                    Console.Write("Colonne =    "); c = int.Parse(Console.ReadLine());
                    while (c > 3 || c < 1)
                    {
                        Console.WriteLine("Erreur ! Vous devez saisir un nombre compris entre 1 et 3");
                        Console.Write("Colonne =    "); c = int.Parse(Console.ReadLine());
                    }
                }

                grille[l - 1, c - 1] = joueur;

                //--- Vérification de la ligne ---
                if (grille[l - 1, 0] + grille[l - 1, 1] + grille[l - 1, 2] == 3 * joueur ||
                     grille[0, c - 1] + grille[1, c - 1] + grille[2, c - 1] == 3 * joueur ||
                     grille[0, 0] + grille[1, 1] + grille[2, 2] == 3 * joueur ||
                     grille[0, 2] + grille[1, 1] + grille[2, 0] == 3 * joueur)
                    gagne = true;

                //--- Compteur d'essais  et changement de joueur ---
                if (!gagne)
                {
                    if (joueur == 1)
                        joueur = 2;
                    else
                        joueur = 1;
                }
            } // Fin TQ

            //--- Fin de la partie ---
            if (gagne)
                Console.Write("Le joueur " + joueur + " a gagné !");
            

            Console.ReadLine();
        }
    }
}
