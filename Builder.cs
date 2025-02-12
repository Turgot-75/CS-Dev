using System;

public class Book
{
    private Properties p;
    public Book(Properties properties)
    {
        this.p = properties;
    }
    public class Properties
    {
        public string n, a, d, g;
        public int s;
        public Properties title(string name)
        {
            this.n=name;
            return this;
        }

        public Properties author(string author)
        {
            this.a=author;
            return this;
        }

        public Properties description(string description)
        {
            this.d=description;
            return this;
        }

        public Properties sortieEn(int sortie)
        {
            this.s = sortie;
            return this;
        }

        public Properties genre(string genre)
        {
            this.g = genre;
            return this;
        }
    }
    public void afficherInfo()
    {
        Console.WriteLine("Titre : " + p.n);
        Console.WriteLine("Author : " + p.a);
        Console.WriteLine("Desc : " + p.d);
        Console.WriteLine("Sortie en : " + p.s);
        Console.WriteLine("Genre : " + p.g);
    }
}

class Program
{
    public static void Main(string[] args)
    {
        Book book1 = new Book(new Book.Properties().title("1984").author("George Orwell")
        .description("1984 est un roman dystopique qui se déroule dans une société totalitaire où la liberté individuelle est supprimée.")
        .genre("Science-fiction, dystopie").sortieEn(1949));

        book1.afficherInfo();
    }
}