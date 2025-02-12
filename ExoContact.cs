using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Dev
{
    internal class ExoContact
    {
        public ExoContact() { }

        public void launch()
        {
            FileStream contactsSaved = File.Create("contact.txt");

            int choix = 0;

            do
            {
                System.Console.WriteLine("1-Ajouter un contact.");
                System.Console.WriteLine("2-Lister tous les contacts.");
                System.Console.WriteLine("3-Enregistrer les contacts dans un fichier texte.");
                System.Console.WriteLine("4-Charger les contacts à partir d'un fichier texte.");
                System.Console.WriteLine("5-Quitter");
                System.Console.Write("-> ");
                choix = Convert.ToInt32(Console.ReadLine());

                switch (choix)
                {
                    case 1:

                        break;
                    case 5:
                        System.Console.WriteLine("Vous quittez l'application contacts");
                        break;
                    default:
                        break;
                }
            } while (choix != 5);
        }
    }
}
