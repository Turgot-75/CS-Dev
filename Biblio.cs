using System;
using System.Threading.Channels;
using static System.Reflection.Metadata.BlobBuilder;

class Livre
{
    public string Titre;
    public string Auteur;
    public int AnneePublication;
    public string Genre;
    public bool EstDisponible;

    public Livre(string Titre, string Auteur, int AnneePublication, string Genre, bool EstDisponible)
    {
        this.Titre = Titre;
        this.Auteur = Auteur;
        this.Genre = Genre;
        this.AnneePublication = AnneePublication;
        this.EstDisponible = EstDisponible;
    }

    public String AfficherDetails()
    {
        return "Titre : " + this.Titre + " | Auteur : " + this.Auteur + " | Genre : " + this.Genre + " | Date : " + this.AnneePublication + " | Disponible : "+ (this.EstDisponible ? "oui" : "non");
    }

    public bool getDisponibilite()
    {
        return this.EstDisponible;
    }

    public string getTitre()
    {
        return this.Titre;
    }

    public void Emprunter()
    {
        this.EstDisponible = false;
    }
    public void Retourner()
    {
        this.EstDisponible = true;
    }
}

class Bibliotheque
{
    protected List<Livre> livreList = new List<Livre>();
    public List<Livre> GetLivres()
    {
        return this.livreList;
    }

    public void AjouterLivre(Livre livre)
    {
        this.livreList.Add(livre);
    }

    public void SupprimerLivre(string titre)
    {
        for(int i = 0; i < livreList.Count; i++)
        {
            if(livreList[i].getTitre().Equals(titre))
            {
                livreList.Remove(livreList[i]);
            }
        }
    }

    public bool RechercherLivre(string titre)
    {
        for (int i = 0; i < livreList.Count; i++)
        {
            if (livreList[i].getTitre().Equals(titre))
            {
                return true;
            }
        }
        return false;
    }

    public void AfficherTousLesLivres()
    {
        foreach(Livre l in this.livreList)
        {
            System.Console.WriteLine(l.AfficherDetails());
        }
    }

    public void EmprunterLivre(string titre)
    {
        for (int i = 0; i < livreList.Count; i++)
        {
            if (livreList[i].getDisponibilite() && livreList[i].getTitre().Equals(titre))
            {
                livreList[i].Emprunter();
            }
        }
    }
    public void RetournerLivre(string titre)
    {
        for (int i = 0; i < livreList.Count; i++)
        {
            if (!livreList[i].getDisponibilite() && livreList[i].getTitre().Equals(titre))
            {
                livreList[i].Retourner();
            }
        }
    }
}

class Program
{
    public static void Main(string[] args)
    {
        Bibliotheque biblio = new Bibliotheque(); //Init List
        int choix = 0;
        System.Console.WriteLine("Bienvennue à la bibliothèque que voulez vous faire ?");
        do
        {
            System.Console.WriteLine("1. Ajouter un livre");
            System.Console.WriteLine("2. Supprimer un livre");
            System.Console.WriteLine("3. Rechercher un livre");
            System.Console.WriteLine("4. Afficher tous les livres");
            System.Console.WriteLine("5. Emprunter un livre");
            System.Console.WriteLine("6. Retourner un livre");
            System.Console.WriteLine("7. Quitter");

            System.Console.Write("Choisissez une option : ");
            choix = Convert.ToInt32(System.Console.ReadLine());

            switch (choix)
            {
                case 1:
                    System.Console.Write("Entrez le titre du livre : ");
                    string Titre = Convert.ToString(System.Console.ReadLine());

                    System.Console.Write("Entrez l'auteur : ");
                    string Auteur = Convert.ToString(System.Console.ReadLine());

                    System.Console.Write("Entrez l'année de publication : ");
                    int AnneePublication = Convert.ToInt32(System.Console.ReadLine());

                    System.Console.Write("Entrez le genre : ");
                    string Genre = Convert.ToString(System.Console.ReadLine());

                    biblio.AjouterLivre(new Livre(Titre, Auteur, AnneePublication, Genre, true));
                    System.Console.WriteLine("Le livre a été ajouté à la bibliothèque !");
                    break;
                case 2:
                    System.Console.Write("Entrez le titre du livre à supprimer : ");
                    string titreDeleted = Convert.ToString(System.Console.ReadLine());
                    biblio.SupprimerLivre(titreDeleted);
                    break;
                case 3:
                    System.Console.Write("Entrez le titre du livre à rechercher : ");
                    string titreResearch = Convert.ToString(System.Console.ReadLine());
                    if(biblio.RechercherLivre(titreResearch))
                    {
                        System.Console.WriteLine("Le livre à été trouvé !");
                    }
                    else
                    {
                        System.Console.WriteLine("Le livre n'a pas été trouvé !");
                    }
                    break;
                case 4:
                    biblio.AfficherTousLesLivres();
                    break;
                case 5:
                    System.Console.Write("Entrez le titre du livre à emprunter : ");
                    string titreEmprunt = Convert.ToString(System.Console.ReadLine());
                    biblio.EmprunterLivre(titreEmprunt);
                    break;
                 case 6:
                    System.Console.Write("Entrez le titre du livre à retourner : ");
                    string titreReturn = Convert.ToString(System.Console.ReadLine());
                    biblio.RetournerLivre(titreReturn);
                    break;
                  case 7:
                    System.Console.WriteLine("Vous quittez la bibliothèque !");
                    break;
            }
        } while (choix != 7);
    }
}