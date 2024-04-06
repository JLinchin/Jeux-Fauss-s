using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppliMastermind
{
    class Program
    {
        static void Main(string[] args)
        {
            //--- Déclarations ---
            char[] combinaison = new char[5];	// Tableau contenant la combinaison de 5 couleurs à trouver
            char[] copie = new char[5];         // Tableau contenant la copie du tableau combinaison
            char[] essai = new char[5]; 	    // Tableau contenant chacun des essais
            string listColor = "brnvjog",       // Chaîne contanant la liste de couleurs
            affichage,                          // Chaîne contenant ce qui est affiché à l'écran
            nouvEssai;                          // Utilisée pour choisir de relancer une partie
            int i, j,   			            // Indices de parcours des tableaux
            nbEssai,                            // Compteur d'essais avant de trouver la formule
            bp,                                 // Compteur de bien placés
            mp,            	                    // Compteur de mal placés
            testCouleur = 0;                    // Variable pour tester le contenu de combinaison et essai
            bool boolNouvEssai = true;          // Booléen pour relancer une partie

            affichage = "\t\t\t\tMASTERMIND";
            while(boolNouvEssai)
            {
                Console.Clear();
                Console.WriteLine(affichage);

                //--- Saisie de la combinaison à trouver ---
                Console.Write("1er joueur, saisissez une combinaison secrète de 5 couleurs : ");
                string saisie = Console.ReadLine();
                saisie = saisie.ToLower();

                //--- Test des critères (longueur combinaison = 5, combinaison composée de couleurs) ---
                while (testCouleur != 5)
                {
                    testCouleur = 0;

                    //--- Test de la longueur ---
                    while (saisie.Count() != 5)
                    {
                        switch (saisie.Count())
                        {
                            case int n when (n < 5):
                                Console.Write("Erreur : pas assez de caractères, réessayez : ");
                                saisie = Console.ReadLine();
                                saisie = saisie.ToLower();
                                break;
                            case int n when (n > 5):
                                Console.Write("Erreur : trop de caractères, réessayez : ");
                                saisie = Console.ReadLine();
                                saisie = saisie.ToLower();
                                break;
                        }
                    }

                    //--- Test des couleurs ---
                    for (j = 0; j < 5; j++)
                        for (int k = 0; k < 7; k++)
                            if (saisie[j] == listColor[k])
                                testCouleur++;

                    if (testCouleur != 5)
                    {
                        Console.Write("Erreur : les caractères ne sont pas des couleurs, réessayez : ");
                        saisie = Console.ReadLine();
                        saisie = saisie.ToLower();
                    }
                }

                char[] tempo = new char[5];
                tempo = saisie.ToCharArray();
                for (i = 0; i < 5; i++)
                    combinaison[i] = tempo[i];  // Pour saisir un caractère + ENTREE

                nbEssai = 0;
                Console.Clear();
                Console.WriteLine(affichage);
                Console.WriteLine("2eme joueur, saisissez une combinaison de 5 couleurs :");

                //--- Proposition d'une combinaison tant que les 5 couleurs n'ont pas été bien placées ---
                do
                {
                    testCouleur = 0;
                    nbEssai++;

                    //--- Saisie de l'essai
                    Console.Write("essai n°" + nbEssai + " : ");
                    saisie = Console.ReadLine();
                    tempo = saisie.ToCharArray();

                    //--- Test des critères (longueur combinaison = 5, combinaison composée de couleurs) ---
                    while (testCouleur != 5)
                    {
                        testCouleur = 0;

                        //--- Test de la longueur ---
                        while (saisie.Count() != 5)
                        {
                            switch (saisie.Count())
                            {
                                case int n when (n < 5):
                                    Console.Write("Erreur : pas assez de caractères, réessayez : ");
                                    saisie = Console.ReadLine();
                                    saisie = saisie.ToLower();
                                    tempo = saisie.ToCharArray();
                                    break;

                                case int n when (n > 5):
                                    Console.Write("Erreur : trop de caractères, réessayez : ");
                                    saisie = Console.ReadLine();
                                    saisie = saisie.ToLower();
                                    tempo = saisie.ToCharArray();
                                    break;
                            }
                        }

                        //--- Test de couleurs ---
                        for (i = 0; i < 5; i++)
                        {
                            essai[i] = tempo[i];
                            copie[i] = combinaison[i];
                        }

                        for (j = 0; j < 5; j++)
                            for (int k = 0; k < 7; k++)
                                if (saisie[j] == listColor[k])
                                    testCouleur++;

                        if (testCouleur != 5)
                        {
                            Console.Write("Erreur : les caractères ne sont pas des couleurs, réessayez : ");
                            saisie = Console.ReadLine();
                            saisie = saisie.ToLower();
                            tempo = saisie.ToCharArray();
                        }
                    }



                    //--- Calcul des bien placés ---
                    bp = 0;
                    for (i = 0; i < 5; i++)
                    {
                        if (copie[i] == essai[i])
                        {
                            bp++;
                            // Marquer ces éléments pour qu'ils ne soient pas traités lors
                            // du calcul des mal placés...
                            copie[i] = 'X';
                            essai[i] = 'Y';
                        };
                    }

                    //--- Calcul des mal placés
                    mp = 0;
                    for (i = 0; i < 5; i++)
                        for (j = 0; j < 5; j++)
                            if (copie[i] == essai[j])
                            {
                                mp++;
                                // Marquer les éléments pour qu'ils ne soient plus compatibilisés
                                copie[i] = 'X';
                                essai[j] = 'Y';
                            }


                    //--- Affichage du résultat ---
                    Console.WriteLine("\tBien places : " + bp.ToString());
                    Console.WriteLine("\tMal places : " + mp.ToString() + "\n");
                }
                while (bp < 5);

                //--- Affichage final ---
                Console.Write("\n\nVous avez trouve en " + nbEssai + " essais... ");
                if (nbEssai < 5)
                    Console.WriteLine(" Bravo !!!");
                else
                {
                    if (nbEssai < 10)
                        Console.WriteLine(" Correct");
                    else
                        Console.WriteLine(" Décevant");
                }

                //--- Lancement d'une nouvelle partie
                Console.Write("\nSouhaitez-vous rejouer ?(O/N) : ");
                nouvEssai = Console.ReadLine();

                while(nouvEssai != "O" && nouvEssai != "o" && nouvEssai != "N" && nouvEssai != "n")
                {
                    Console.Write("Erreur, réssayez (O/N): ");
                    nouvEssai = Console.ReadLine();
                }

                switch(nouvEssai)
                {
                    case "O":
                    case "o":
                        boolNouvEssai = true;
                        break;

                    case "N":
                    case "n":
                        boolNouvEssai = false;
                        break;
                }
            }
        }
    }
}
