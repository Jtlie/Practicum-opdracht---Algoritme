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
           // queue = Bestelling_Toevoegen(queue);
            Verwijder_Complete_Bestellingen(queue);
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
                bestelling.Start_tijd = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            }
            else
            {
                bestelling.Start_tijd = "";
            }
            Console.WriteLine(bestelling.Start_tijd);
            bestelling.Duur = "1 dag";
            bestelling.Compleet = false;
            Console.WriteLine("Wacht de klant de bestelling op?");
            Console.WriteLine("1 = Ja");
            Console.WriteLine("andere invoer = Nee");
            bestelling.Dadelijk = Console.ReadLine() == "1";

            queue = Maak_Bestelling_Array_Langer(queue);
            queue[queue.Length-1] = bestelling;
            return queue;
        }

        static Bestelling[] Verwijder_Complete_Bestellingen(Bestelling[] queue)
        {
            Bestelling[] queue_Oud = queue;
            for (int i = 0; i < queue.Length; i++ )
            {
                if(queue[i].Compleet == true)
                {
                    
                }
            }
                return null;
        }


        static Bestelling[] Vul_Array(Bestelling[] queue)
        {
            
            for (int i = 1; i< 14; i++)
            { 
                Bestelling bestelling = new Bestelling();
                bestelling.Klant_ID = i;
                bestelling.Bestelling_ID = i;
                bestelling.Verwerking = false;
                bestelling.Start_tijd = "";
                bestelling.Duur = "1 dag";
                bestelling.Compleet = false;
                bestelling.Dadelijk = false;
                queue[i-1] = bestelling;
            }
            return queue;
        }

        static Bestelling[] Maak_Bestelling_Array_Langer(Bestelling[] Array_Oud)
        {
            Bestelling[] Array_Nieuw = new Bestelling[Array_Oud.Length + 1];
            Array.Copy(Array_Oud, Array_Nieuw, Array_Oud.Length);
            return Array_Nieuw;
        }

        static Bestelling[] Maak_Bestelling_Array_Korter(Bestelling[] Array_Oud)
        {
            Bestelling[] Array_Nieuw = new Bestelling[Array_Oud.Length - 1];
            Array.Copy(Array_Oud, Array_Nieuw, Array_Oud.Length);
            return Array_Nieuw;            
        }
    }
}
