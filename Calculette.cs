using System;
class Program
{
    static void Main(string[] args)
    {
        String reload = "yes";

        do
        {
            Console.Write("Nbr 1 : ");
            double nb1 = Convert.ToDouble(Console.ReadLine());
            Console.Write("Signe de calcul : ");
            char signe = Convert.ToChar(Console.ReadLine());
            Console.Write("Nbr 2 : ");
            double nb2 = Convert.ToDouble(Console.ReadLine());
            double result = calculette(nb1, signe, nb2);
            bool divBy0 = signe == '/' && nb2 == 0;
            Console.WriteLine("Le résultat du calcul : " + (divBy0 ? "ERREUR MATHS" : nb1 + " " + signe + " " + nb2 + " = " + result));
            Console.Write("Voulez vous relancez la calculatrice (yes/no) : ");
            reload = Convert.ToString(Console.ReadLine());
        } while (reload == "yes");
    }

    static double calculette(double nb1, char signe, double nb2)
    {
        double result = 0.0;

        switch (signe)
        {
            case '+':
                result = nb1 + nb2;
                break;
            case '-':
                result = nb1 - nb2;
                break;
            case '*':
                result = nb1 * nb2;
                break;
            case '/':
                if (nb2 == 0)
                {
                    Console.WriteLine("Erreur division par 0 impossible");
                }
                else
                {
                    result = nb1 / nb2;
                }
                break;
            default:
                Console.WriteLine("Erreur signe inconnu");
                break;
        }

        return result;
    }
}