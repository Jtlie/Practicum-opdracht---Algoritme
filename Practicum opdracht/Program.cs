using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practicum_opdracht
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Bestelling[] queue = new Bestelling[13];
            queue = Vul_Array(queue);            
            Console.WriteLine("Kies uw nummer: \n 1 - Bestelling Toevoegen \n 2 - Verwijder Complete Bestellingen \n 3 - Bestelling updaten");
            int opdracht = 0;
            try
            {
                opdracht = Int32.Parse(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Geen Juiste invoer");
            }
            switch (opdracht)
            {
                case 1:
                    queue = Bestelling_Toevoegen(queue);
                    break;
                case 2:
                    Console.WriteLine("Weet u Zeker dat U ze wilt verwijderen? [j/n]");
                    string Antwoord = Console.ReadLine();
                    if(Antwoord == "j" | Antwoord =="J")
                    {
                        Verwijder_Complete_Bestellingen(queue);
                        Console.WriteLine("Complete Bestellingen Verwijderd");
                    }
                    else if (Antwoord == "n" | Antwoord == "N")
                    {
                        Console.WriteLine("Complete Bestellingen  Niet Verwijderd");
                    }
                    else
                    {
                        Console.WriteLine("Verkeerde Input \n Complete Bestellingen Niet Verwijderd");
                    }
                    break;
                case 3:
                    queue = Update_Bestellingen(queue);
                    Console.WriteLine("Bestelling zijn geupdate");
                    break;
                default:
                    Console.WriteLine("Geen Juiste invoer");
                    break;
            }
            Console.ReadKey();
        }

        static Bestelling[] Bestelling_Toevoegen(Bestelling[] queue)
        {
            int queue_length = queue.Length;
            Bestelling Laatste_Bestelling = queue[queue_length-1];
            Bestelling bestelling = new Bestelling();
            Console.WriteLine("Voer een Klant_ID in (Cijfers)");
            try
            {
                bestelling.Klant_ID = Int32.Parse(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Geen geldige ID ingevoerd");
                return null;
            }
            bestelling.Bestelling_ID = Laatste_Bestelling.Bestelling_ID + 1;
            Console.WriteLine("is de bestelling in verwerking?");
            Console.WriteLine("1 = Ja");
            Console.WriteLine("andere invoer = Nee");
            bestelling.Verwerking = Console.ReadLine() == "1";
            if (bestelling.Verwerking == true)
            {
                bestelling.Start_tijd = DateTime.Now;
            }
            Console.WriteLine("Hoe lang duurt de bestelling (In Uren)?");
            try
            {
                bestelling.Duur = Int32.Parse(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Geen geldige Invoer");
                return null;
            }
            bestelling.Compleet = false;
            Console.WriteLine("Wacht de klant de bestelling op?");
            Console.WriteLine("1 = Ja");
            Console.WriteLine("andere invoer = Nee");
            bestelling.Dadelijk = Console.ReadLine() == "1";

            queue = Voeg_index_Toe(queue);
            queue[queue.Length-1] = bestelling;
            Console.WriteLine("bestelling toegevoegd");
            return queue;
        }

        static Bestelling[] Verwijder_Complete_Bestellingen(Bestelling[] queue)
        {
            int j = 0;
            int Aantal_Compleet = 0;
            
            Bestelling[] queue_Zonder_Complete_Bestellingen = new Bestelling[queue.Length];
            for (int i = 0; i < queue.Length; i++ )
            {
                if(queue[i].Compleet =! true)
                {
                    queue_Zonder_Complete_Bestellingen[j] = queue[i];
                    j++;
                }
                else
                {
                    Aantal_Compleet++;
                }
            }
            Bestelling[] queue_nieuw = new Bestelling[queue.Length];
            for (int k = 0; k > Aantal_Compleet; k++)
            {
                queue_nieuw = Maak_Bestelling_Array_Korter(queue_nieuw);
            }
            Array.Copy(queue_Zonder_Complete_Bestellingen, queue_nieuw, queue_nieuw.Length);
            return queue_nieuw;
        }

        static Bestelling[] Update_Bestellingen(Bestelling[] queue)
        {
            bool Bestelling_In_Verwerking = false;
            for (int i = 0; i < queue.Length; i++)
            {
                if (queue[i].Verwerking ==  true)
                {
                    Bestelling_In_Verwerking = true; ;
                }
            }
            if (Bestelling_In_Verwerking == false)
            {
                queue[0].Verwerking = true;
                queue[0].Start_tijd = DateTime.Now;
            }

            for (int i = 0; i < queue.Length; i++)
            {
                DateTime Eind_tijd = queue[i].Start_tijd.AddHours(queue[i].Duur);
                if(DateTime.Now > Eind_tijd )
                {
                    queue[i].Compleet = true;
                    queue[i].Verwerking = false;
                }
            }
            

            return queue;
        }
        
        static Bestelling[] Vul_Array(Bestelling[] queue)
        {
            
            for (int i = 1; i< 14; i++)
            { 
                Bestelling bestelling = new Bestelling();
                bestelling.Klant_ID = i;
                bestelling.Bestelling_ID = i;
                bestelling.Verwerking = false;
                bestelling.Duur = 1 | 2 | 3 | 4;
                bestelling.Compleet = false;
                bestelling.Dadelijk = false;
                queue[i-1] = bestelling;
            }
            return queue;
        }

        static Bestelling[] Voeg_index_Toe(Bestelling[] Array_Oud)
        {
            Bestelling[] Array_Nieuw = new Bestelling[Array_Oud.Length + 1];
            Array.Copy(Array_Oud, Array_Nieuw, Array_Oud.Length);
            return Array_Nieuw;
        }

        static Bestelling[] Maak_Bestelling_Array_Korter(Bestelling[] Array_Oud)
        {
            Bestelling[] Array_Nieuw = new Bestelling[Array_Oud.Length - 1];
            return Array_Nieuw;            
        }
    }
}
