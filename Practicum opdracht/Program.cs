﻿using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Practicum_opdracht
{
    class Program
    {
        /// <summary>
        /// entry point
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            // maak bestellingen en klanten array aan
            Bestelling[] queue = new Bestelling[13];
            Klant[] Klanten = new Klant[10];
            bool start = true;

            // vul arrays
            queue = Vul_Array(queue);
            Klanten = Vul__Klant_Array(Klanten);
            
            // opties loop
            while (start == true)
            {
                Console.WriteLine("Kies uw nummer:");
                Console.WriteLine(" 1 - Bestelling Toevoegen");
                Console.WriteLine(" 2 - Verwijder Complete Bestellingen");
                Console.WriteLine(" 3 - Bestelling updaten");
                Console.WriteLine(" 4 - STOP");
                Console.WriteLine(" 5 - Print de Queue");
                Console.WriteLine(" 6 - Print Klanten");
                Console.WriteLine(" 7 - sorteer/zoek Klantendatabase");
                Console.WriteLine(" 8 - binary tree");

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
                        if (Antwoord == "j" | Antwoord == "J")
                        {
                            queue = Verwijder_Complete_Bestellingen(queue);
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
                    case 4:
                        Console.WriteLine("Process gestopt");
                        start = false;
                        break;
                    case 5:
                        Print_queue(queue);
                        break;
                    case 6:
                        Print_Klanten(Klanten);
                        break;
                    case 7:
                        int klantensortkeuze;
                        Console.WriteLine("Kies 1 om te sorteren , kies 2 om zoeken");
                        klantensortkeuze = opdracht = Int32.Parse(Console.ReadLine());

                        if(klantensortkeuze == 1)
                        {
                           int klantensortkeuze2;
                           Console.WriteLine("Kies 1 om op achternaam te sorteren , kies 2 om op leeftijd te sorteren, Kies 3 om de laatste klant op achternaam te sorteren");
                           klantensortkeuze2 = opdracht = Int32.Parse(Console.ReadLine());

                            if (klantensortkeuze2 == 1)
                            {
                                Klanten = Sorteer_klanten_op_achternaam(Klanten);
                            }
                            else if (klantensortkeuze2 == 2)
                            {
                                Klanten = Sorteer_klanten_Op_Leeftijd(Klanten, 0, Klanten.Length-1);
                            }
                            else if (klantensortkeuze2 == 3)
                            {
                                Klanten = Sort_laatste_Klant_op_achternaam(Klanten);
                            }
                            Print_Klanten(Klanten);
                        }

                        else if (klantensortkeuze == 2)
                        {
                            int klantensortkeuze2;
                            Console.WriteLine("Kies 1 om op achternaam te zoeken , kies 2 om op leeftijd te zoeken");
                            klantensortkeuze2 = opdracht = Int32.Parse(Console.ReadLine());

                            if (klantensortkeuze2 == 1)
                            {
                                Console.WriteLine("Voer achternaam in");
                                String achternaam = Console.ReadLine();
                                Zoek_klant_op_achternaam(Klanten, achternaam, 0, Klanten.Length-1);
                            }
                            else if (klantensortkeuze2 == 2)
                            {
                                Console.WriteLine("Voer leeftijd in");
                                int leeftijd = Int32.Parse(Console.ReadLine());
                                Zoek_klant_op_leeftijd(Klanten, leeftijd);
                            }
                        }                        
                        break;
                    case 8:

                        Klant[] tempKlanten = new Klant[Klanten.Length];
                        tempKlanten = Klanten;

                        // maak binary tree van klanten array
                        BinaryTree tree = binary_Tree(Klanten);
                        
                        int keuze = 0;

                        Console.WriteLine("Kies 1 op een nieuwe Klant toe te voegen, kies 2 om een bestaande klant te verwijderen.");

                        keuze = Int32.Parse(Console.ReadLine());

                        if (keuze == 1)
                        {
                            tempKlanten = new Klant[Klanten.Length + 1];
                            tempKlanten = Klanten;

                            int debug = tempKlanten.Length - 1;

                            Console.WriteLine("Voer een Klant ID in (cijfers):");
                            tempKlanten[tempKlanten.Length - 1].Klant_ID = Int32.Parse(Console.ReadLine());
                            Console.WriteLine("Voer een Klant Voornaam in:");
                            tempKlanten[tempKlanten.Length - 1].Voornaam = Console.ReadLine();
                            Console.WriteLine("Voer een Klant Tussenvoegsel in:");
                            tempKlanten[tempKlanten.Length - 1].Tussenvoegsel = Console.ReadLine();
                            Console.WriteLine("Voer een Klant Achternaam in:");
                            tempKlanten[tempKlanten.Length - 1].Achternaam = Console.ReadLine();
                            Console.WriteLine("Voer een Klant Leeftijd in (cijfers):");
                            tempKlanten[tempKlanten.Length - 1].Leeftijd = Int32.Parse(Console.ReadLine());
                            Console.WriteLine("Voer een Klant Geslacht in:");
                            tempKlanten[tempKlanten.Length - 1].Geslacht = Console.ReadLine();
                            Console.WriteLine("Voer een Klant Plaats in:");
                            tempKlanten[tempKlanten.Length - 1].Plaats = Console.ReadLine();
                            Console.WriteLine("Voer een Klant Email in:");
                            tempKlanten[tempKlanten.Length - 1].Email = Console.ReadLine();

                            tree = binary_Tree(tempKlanten);

                            //Klant tklant = new Klant();

                            //Console.WriteLine("Voer een Klant ID in (cijfers):");
                            //tklant.Klant_ID = Int32.Parse(Console.ReadLine());
                            //Console.WriteLine("Voer een Klant Voornaam in:");
                            //tklant.Voornaam = Console.ReadLine();
                            //Console.WriteLine("Voer een Klant Tussenvoegsel in:");
                            //tklant.Tussenvoegsel = Console.ReadLine();
                            //Console.WriteLine("Voer een Klant Achternaam in:");
                            //tklant.Achternaam = Console.ReadLine();
                            //Console.WriteLine("Voer een Klant Leeftijd in (cijfers):");
                            //tklant.Leeftijd = Int32.Parse(Console.ReadLine());
                            //Console.WriteLine("Voer een Klant Geslacht in:");
                            //tklant.Geslacht = Console.ReadLine();
                            //Console.WriteLine("Voer een Klant Plaats in:");
                            //tklant.Plaats = Console.ReadLine(); 
                            //Console.WriteLine("Voer een Klant Email in:");
                            //tklant.Email = Console.ReadLine();

                            //Klant[] tempklant = new Klant[1];
                            //tempklant[0] = tklant;

                            //tree.Insert(tempklant);
                        }
                        else
                        {
                            tempKlanten = new Klant[Klanten.Length];
                            tempKlanten = Klanten;
                            int i = 0;

                            Console.WriteLine("voer Klant ID in (cijfers)");
                            int input = Int32.Parse(Console.ReadLine());

                            tempKlanten = Verwijder_Klanten(tempKlanten, input);

                            tree = binary_Tree(tempKlanten);
                        }
                        
                        
                        
                        break;
                    default:
                        Console.WriteLine("Geen Juiste invoer");
                        break;
                }
            }
        }

        /// <summary>
        /// methode om bestelling aan de bestellingen array toe te voegen
        /// </summary>
        /// <param name="queue">bestelling array</param>
        /// <returns>bestellingen array</returns>
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

            Console.WriteLine("Hoe lang duurt de bestelling (In Minuten)?");

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

        /// <summary>
        /// methode om complete bestellingen te verwijderen
        /// </summary>
        /// <param name="queue">bestellingen array</param>
        /// <returns>bestellingen array</returns>
        static Bestelling[] Verwijder_Complete_Bestellingen(Bestelling[] queue)
        {
            int j = 0;
            int Aantal_Compleet = 0;
            
            Bestelling[] queue_Zonder_Complete_Bestellingen = new Bestelling[queue.Length];

            for (int i = 0; i < queue.Length; i++ )
            {
                if(queue[i].Compleet == false)
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

            for (int k = 0; k < Aantal_Compleet; k++)
            {
                queue_nieuw = Maak_Bestelling_Array_Korter(queue_nieuw);
            }

            Array.Copy(queue_Zonder_Complete_Bestellingen, queue_nieuw, queue_nieuw.Length);
            return queue_nieuw;
        }

        /// <summary>
        /// methode om klant te verwijderen
        /// </summary>
        /// <param name="queue">klantarray</param>
        /// <param name="invoer">klant id int</param>
        /// <returns>klantarray</returns>
        static Klant[] Verwijder_Klanten(Klant[] queue, int invoer)
        {
            int j = 0;
            int Aantal_Compleet = 0;

            Klant[] queue_Zonder_Complete_Bestellingen = new Klant[queue.Length];

            for (int i = 0; i < queue.Length; i++)
            {
                if (queue[i].Klant_ID == invoer)
                {
                    Aantal_Compleet++;
                }
                else
                {                   
                    queue_Zonder_Complete_Bestellingen[j] = queue[i];
                    j++;
                }
            }

            Klant[] queue_nieuw = new Klant[queue.Length];

            for (int k = 0; k < Aantal_Compleet; k++)
            {
                queue_nieuw = Maak_Klant_Array_Korter(queue_nieuw);
            }

            Array.Copy(queue_Zonder_Complete_Bestellingen, queue_nieuw, queue_nieuw.Length);
            return queue_nieuw;
        }

        /// <summary>
        /// methode om de complete bestelling op "compleet" te zetten
        /// </summary>
        /// <param name="queue">bestellingen array</param>
        /// <returns>bestellingen array</returns>
        static Bestelling[] Update_Bestellingen(Bestelling[] queue)
        {
            bool Bestelling_In_Verwerking = false;

            for (int i = 0; i < queue.Length; i++)
            {
                DateTime Eind_tijd = queue[i].Start_tijd.AddMinutes(queue[i].Duur);
                if (DateTime.Now > Eind_tijd && queue[i].Start_tijd != DateTime.MinValue)
                {
                    queue[i].Compleet = true;
                    queue[i].Verwerking = false;
                }
            }

            for (int i = 0; i < queue.Length; i++)
            {
                if (queue[i].Verwerking ==  true)
                {
                    Bestelling_In_Verwerking = true;
                }
            }

            for (int i = 0; i < queue.Length; i++)
            {
                 if (Bestelling_In_Verwerking == false && queue[i].Compleet == false)
                 {
                     queue[i].Verwerking = true;
                     queue[i].Start_tijd = DateTime.Now;
                     break;
                 }            
            }

            return queue;
        }

        /// <summary>
        /// methode om de bestellingen array te vullen
        /// </summary>
        /// <param name="queue">bestellingen array</param>
        /// <returns>bestellingen array</returns>
        static Bestelling[] Vul_Array(Bestelling[] queue)
        {
            Random rnd = new Random();

            for (int i = 1; i< 14; i++)
            { 
                Bestelling bestelling = new Bestelling();
                bestelling.Klant_ID = i;
                bestelling.Bestelling_ID = i;
                bestelling.Verwerking = false;
                bestelling.Duur = rnd.Next(1, 3); 
                bestelling.Compleet = false;
                bestelling.Dadelijk = false;
                queue[i-1] = bestelling;
            }

            return queue;
        }

        /// <summary>
        /// methode om de klanten array te vullen
        /// </summary>
        /// <param name="klanten">klanten array</param>
        /// <returns>klantenarray</returns>
        static Klant[] Vul__Klant_Array(Klant[] klanten)
        {
            Random rnd = new Random();
            string[] klantenstring = new string[13] { "Liam", "Emma", "Noah", "Olivia", "Ethan", "Ethan", "Mason", "Ava", "Logan", "Isabella", "Andre", "Mia", "Jacob" }; 

            for (int i = 1; i < klanten.Length+1; i++)
            {                
                Klant klant = new Klant();
                //klant.Achternaam = Random_naam(10);
                klant.Achternaam = klantenstring[i];
                //klant.Email = Random_naam(15);
                klant.Email = klantenstring[i];
                int random_geslacht = rnd.Next(1, 2); 
                if(random_geslacht == 1)
                {
                    klant.Geslacht = "m";
                }
                else{
                    klant.Geslacht = "v";
                }
                klant.Klant_ID = i;
                klant.Leeftijd = rnd.Next(18, 60);
                //klant.Plaats = Random_naam(20);
                klant.Plaats = klantenstring[i];
                //klant.Voornaam = Random_naam(6);
                klant.Voornaam = klantenstring[i];
                klant.Tussenvoegsel = Random_naam(3);
                klanten[i - 1] = klant;
            }

            return klanten;
        }

        /// <summary>
        /// sorteer klanten op leeftijd
        /// </summary>
        /// <param name="input">klantenarray</param>
        /// <param name="left">int 0</param>
        /// <param name="right">klanten array lengte</param>
        /// <returns>klantenarray</returns>
        public static Klant[] Sorteer_klanten_Op_Leeftijd(Klant[] input, int left, int right)
        {
            if (left < right)
            {
                int middle = (left + right) / 2;

                Sorteer_klanten_Op_Leeftijd(input, left, middle);
                Sorteer_klanten_Op_Leeftijd(input, middle + 1, right);

                //Merge
                Klant[] leftArray = new Klant[middle - left + 1];
                Klant[] rightArray = new Klant[right - middle];

                Array.Copy(input, left, leftArray, 0, middle - left + 1);
                Array.Copy(input, middle + 1, rightArray, 0, right - middle);

                int i = 0;
                int j = 0;
                for (int k = left; k < right + 1; k++)
                {
                    if (i == leftArray.Length)
                    {
                        input[k] = rightArray[j];
                        j++;
                    }
                    else if (j == rightArray.Length)
                    {
                        input[k] = leftArray[i];
                        i++;
                    }
                    else if (leftArray[i].Leeftijd <= rightArray[j].Leeftijd)
                    {
                        input[k] = leftArray[i];
                        i++;
                    }
                    else
                    {
                        input[k] = rightArray[j];
                        j++;
                    }
                }
            }

            return input;
        }

        /// <summary>
        /// sorteer klant op achternaam
        /// </summary>
        /// <param name="Klanten">klantenarray</param>
        /// <returns>klantenarray</returns>
        public static Klant[] Sorteer_klanten_op_achternaam(Klant[] Klanten)
        {
            Klant X;
            int i, j;
            for (j = 1; j < Klanten.Length; j++)
            {
                X = Klanten[j];
                i = j - 1;
                while (i>= 0)
                {
                    if (X.Achternaam.CompareTo(Klanten[i].Achternaam) > 0)
                    {
                        break;
                    }
                    Klanten[i + 1] = Klanten[i];
                    i--;
                }
                Klanten[i + 1] = X;
            }
            return Klanten;
        }

        public static Klant[] Sort_laatste_Klant_op_achternaam(Klant[] Klanten)
        {
            Klant X;
            int i, j;
            
            j = Klanten.Length - 1;
                X = Klanten[j];
                i = j - 1;
                while (i >= 0)
                {
                    if (X.Achternaam.CompareTo(Klanten[i].Achternaam) > 0)
                    {
                        break;
                    }
                    Klanten[i + 1] = Klanten[i];
                    i--;
                }
                Klanten[i + 1] = X;
            return Klanten;
        }

        /// <summary>
        /// methode om een klant uit klanten array op achternaam te vinden
        /// </summary>
        /// <param name="klanten">klantenarray</param>
        /// <param name="achternaam">string achternaam</param>
        public static void Zoek_klant_op_achternaam(Klant[] klanten, String achternaam, int imin, int imax)
        {
            int imid = (imin + imax) / 2;
            if (klanten[imid].Achternaam.CompareTo(achternaam) > 0)
            {
                Zoek_klant_op_achternaam(klanten, achternaam, imin, imid - 1);
            }
            else if(klanten[imid].Achternaam.CompareTo(achternaam) < 0)
            {
                Zoek_klant_op_achternaam(klanten, achternaam, imid + 1, imax);
            }
            else
            {
                Console.WriteLine("Klant " + imid);
                Console.WriteLine("Klant_ID:       " + klanten[imid].Klant_ID);
                Console.WriteLine("Voornaam:       " + klanten[imid].Voornaam);
                Console.WriteLine("Tussenvoegsel:  " + klanten[imid].Tussenvoegsel);
                Console.WriteLine("Achternaam:     " + klanten[imid].Achternaam);
                Console.WriteLine("Leeftijd:       " + klanten[imid].Leeftijd);
                Console.WriteLine("Geslacht:       " + klanten[imid].Geslacht);
                Console.WriteLine("Plaats:         " + klanten[imid].Plaats);
                Console.WriteLine("E-mail:         " + klanten[imid].Email);
                Console.WriteLine("");
                Binary_search_Improved_Up(klanten, achternaam, imid);
                Binary_search_Improved_Down(klanten, achternaam, imid);
            }

        }
        public static void Binary_search_Improved_Up(Klant[] klanten, string achternaam, int start)
        {
            int newstart = start+1;
            if (klanten[newstart].Achternaam == achternaam)
            {
                Console.WriteLine("Klant " + newstart);
                Console.WriteLine("Klant_ID:       " + klanten[newstart].Klant_ID);
                Console.WriteLine("Voornaam:       " + klanten[newstart].Voornaam);
                Console.WriteLine("Tussenvoegsel:  " + klanten[newstart].Tussenvoegsel);
                Console.WriteLine("Achternaam:     " + klanten[newstart].Achternaam);
                Console.WriteLine("Leeftijd:       " + klanten[newstart].Leeftijd);
                Console.WriteLine("Geslacht:       " + klanten[newstart].Geslacht);
                Console.WriteLine("Plaats:         " + klanten[newstart].Plaats);
                Console.WriteLine("E-mail:         " + klanten[newstart].Email);
                Console.WriteLine("");
                Binary_search_Improved_Up(klanten, achternaam, newstart);
            }
        }
        public static void Binary_search_Improved_Down(Klant[] klanten, string achternaam, int start)
        {
            int newstart = start - 1;
            if (klanten[newstart].Achternaam == achternaam)
            {
                Console.WriteLine("Klant " + newstart);
                Console.WriteLine("Klant_ID:       " + klanten[newstart].Klant_ID);
                Console.WriteLine("Voornaam:       " + klanten[newstart].Voornaam);
                Console.WriteLine("Tussenvoegsel:  " + klanten[newstart].Tussenvoegsel);
                Console.WriteLine("Achternaam:     " + klanten[newstart].Achternaam);
                Console.WriteLine("Leeftijd:       " + klanten[newstart].Leeftijd);
                Console.WriteLine("Geslacht:       " + klanten[newstart].Geslacht);
                Console.WriteLine("Plaats:         " + klanten[newstart].Plaats);
                Console.WriteLine("E-mail:         " + klanten[newstart].Email);
                Console.WriteLine("");
                Binary_search_Improved_Down(klanten, achternaam, newstart);
            }
        }
        /// <summary>
        /// methode om een klant uit klanten array op leeftijd te vinden
        /// </summary>
        /// <param name="klanten">klanten array</param>
        /// <param name="leeftijd">int leeftijd</param>
        public static void Zoek_klant_op_leeftijd(Klant[] klanten, int leeftijd)
        {
            for (int i = 0; i < klanten.Length; i++)
                if (klanten[i].Leeftijd == leeftijd)
                {
                    Console.WriteLine("Klant " + i);
                    Console.WriteLine("Klant_ID:       " + klanten[i].Klant_ID);
                    Console.WriteLine("Voornaam:       " + klanten[i].Voornaam);
                    Console.WriteLine("Tussenvoegsel:  " + klanten[i].Tussenvoegsel);
                    Console.WriteLine("Achternaam:     " + klanten[i].Achternaam);
                    Console.WriteLine("Leeftijd:       " + klanten[i].Leeftijd);
                    Console.WriteLine("Geslacht:       " + klanten[i].Geslacht);
                    Console.WriteLine("Plaats:         " + klanten[i].Plaats);
                    Console.WriteLine("E-mail:         " + klanten[i].Email);
                    Console.WriteLine("");
                }
        }

        /// <summary>
        /// methode om de bestellingen array te vergroten met 1
        /// </summary>
        /// <param name="Array_Oud">bestellingen array</param>
        /// <returns>bestellingen array</returns>
        static Bestelling[] Voeg_index_Toe(Bestelling[] Array_Oud)
        {
            Bestelling[] Array_Nieuw = new Bestelling[Array_Oud.Length + 1];
            Array.Copy(Array_Oud, Array_Nieuw, Array_Oud.Length);
            return Array_Nieuw;
        }

        /// <summary>
        /// maak klantenaaray langer met plus 1
        /// </summary>
        /// <param name="Array_Oud">klantenarray</param>
        /// <returns>klantenarray</returns>
        static Klant[] Voeg_Klantindex_Toe(Klant[] Array_Oud)
        {
            Klant[] Array_Nieuw = new Klant[Array_Oud.Length + 1];
            Array.Copy(Array_Oud, Array_Nieuw, Array_Oud.Length);
            return Array_Nieuw;
        }

        /// <summary>
        /// methode om de bestellingen array te verkleinen met 1
        /// </summary>
        /// <param name="Array_Oud">bestellingen array</param>
        /// <returns>bestellingen array</returns>
        static Bestelling[] Maak_Bestelling_Array_Korter(Bestelling[] Array_Oud)
        {
            Bestelling[] Array_Nieuw = new Bestelling[Array_Oud.Length - 1];
            Array.Copy(Array_Oud, Array_Nieuw, Array_Oud.Length - 1);
            return Array_Nieuw;            
        }

        /// <summary>
        /// maak klant array korter met min 1
        /// </summary>
        /// <param name="Array_Oud">klantarray</param>
        /// <returns>klantarray</returns>
        static Klant[] Maak_Klant_Array_Korter(Klant[] Array_Oud)
        {
            Klant[] Array_Nieuw = new Klant[Array_Oud.Length - 1];
            Array.Copy(Array_Oud, Array_Nieuw, Array_Oud.Length - 1);
            return Array_Nieuw;
        }

        /// <summary>
        /// methode om een random naam te genereren
        /// </summary>
        /// <param name="size">int grootte van de naam</param>
        /// <returns>string naam</returns>
        static string Random_naam(int size)
        {
            Random random = new Random((int)DateTime.Now.Ticks);
            StringBuilder builder = new StringBuilder();
            char ch;
            for (int i = 0; i < size; i++)
                
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }

            return builder.ToString();
        }

        /// <summary>
        /// methode om te bestellingen array te printen
        /// </summary>
        /// <param name="queue">bestellingen array</param>
        static void Print_queue(Bestelling[] queue)
        {
            for(int i = 0; i < queue.Length; i++)
            {
                Console.WriteLine("Bestelling " + i);
                Console.WriteLine("Bestelling ID:  " + queue[i].Bestelling_ID);
                Console.WriteLine("Klant ID:       " + queue[i].Klant_ID);
                Console.WriteLine("Verwerking:     " + queue[i].Verwerking);
                Console.WriteLine("Start tijd:     " + queue[i].Start_tijd);
                Console.WriteLine("Duur:           " + queue[i].Duur);
                Console.WriteLine("Compleet:       " + queue[i].Compleet);
                Console.WriteLine("Dadelijk:       " + queue[i].Dadelijk);
                Console.WriteLine("");
            }
        }

        /// <summary>
        /// methode om de klanten array te printen
        /// </summary>
        /// <param name="Klanten">klanten array</param>
        static void Print_Klanten(Klant[] Klanten)
        {
            for (int i = 0; i < Klanten.Length; i++)
            {
                Console.WriteLine("Klant " + i);
                Console.WriteLine("Klant_ID:       " + Klanten[i].Klant_ID);
                Console.WriteLine("Voornaam:       " + Klanten[i].Voornaam);
                Console.WriteLine("Tussenvoegsel:  " + Klanten[i].Tussenvoegsel);
                Console.WriteLine("Achternaam:     " + Klanten[i].Achternaam);
                Console.WriteLine("Leeftijd:       " + Klanten[i].Leeftijd);
                Console.WriteLine("Geslacht:       " + Klanten[i].Geslacht);
                Console.WriteLine("Plaats:         " + Klanten[i].Plaats);
                Console.WriteLine("E-mail:         " + Klanten[i].Email);
                Console.WriteLine("");
            }
        }


        /// <summary>
        /// methode om een binary tree te maken van de klanten array
        /// </summary>
        /// <param name="klanten">klanten array</param>
        static BinaryTree binary_Tree(Klant[] klanten)
        {
            BinaryTree tree = new BinaryTree(klanten);
            return tree;
        }
    }
}
 