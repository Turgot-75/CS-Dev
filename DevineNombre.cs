using System;

class Program
{
    public static void Main(string[] args)
    {
        string rejouer = "yes";
        while (rejouer.Equals("yes"))
        {
            System.Console.Write("Voulez vous customizer les bornes (defaut: 1 à 100) et le nombre de tentative (defaut: 10) [yes/no] : ");
            string Customize = "no";
            Customize = Convert.ToString(System.Console.ReadLine());

            int min = 1;
            int max = 100;
            int baseTentative = 10;

            if (Customize.Equals("yes"))
            {
                do
                {
                    System.Console.Write("Entrez le nombre minimum de la borne : ");
                    min = Convert.ToInt32(System.Console.ReadLine());

                    System.Console.Write("Entrez le nombre maximum de la borne : ");
                    max = Convert.ToInt32(System.Console.ReadLine());

                    System.Console.Write("Entrez le nombre de tentatives : ");
                    baseTentative = Convert.ToInt32(System.Console.ReadLine());
                } while (baseTentative <= 0 && min < max);
            }

            Random rnd = new Random();
            if(min > max) { min = 1; max = 100; System.Console.WriteLine("ERREUR min > max changement pour les valeurs par défauts !"); }
            int mysteriousNumber = rnd.Next(min, max);
            System.Console.WriteLine("J'ai générer un nombre entre " + min + " et " + max + ", à toi de le trouver !");
            int entreeUtilisateur = 0;
            int nbTentative = baseTentative;
            do
            {
                System.Console.Write("Entrez votre réponse (Tentatives : " + nbTentative + " : ");
                entreeUtilisateur = Convert.ToInt32(System.Console.ReadLine());

                if (entreeUtilisateur == mysteriousNumber)
                {
                    System.Console.WriteLine("Bravo tu as trouvé mon nombre (" + mysteriousNumber + ") en " + (baseTentative - nbTentative) + " tentatives.");
                    break;
                }
                else if (entreeUtilisateur > mysteriousNumber)
                {
                    System.Console.WriteLine("Plus petit");
                    nbTentative -= 1;
                }
                else
                {
                    System.Console.WriteLine("Plus grand");
                    nbTentative -= 1;
                }
            } while (entreeUtilisateur != mysteriousNumber || nbTentative > 0);

            if (nbTentative == 0)
            {
                System.Console.WriteLine("Vous avez effectué trop de tentatives, Perdu...");
            }

            System.Console.Write("Voulez vous rejouer (yes/no) : ");
            rejouer = Convert.ToString(System.Console.ReadLine());
        }
    }
}