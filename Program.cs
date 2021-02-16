using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Felhantering
{
    class Program
    {
        /**
         * Felhantering & undantag
         * 
         * Materialet hämtat från csharpskolan.se
         * 
         **/

        static void Main(string[] args)
        {
            //Skriv ut menyalternativ
            Console.WriteLine("Felhantering och undantag");
            Console.WriteLine("*************************");
            Console.WriteLine("1. Exempel 1 - Utan felhantering med metoden Parse.");
            Console.WriteLine("2. Exempel 2 - Planera för fel med metoden TryParse.");
            Console.WriteLine("3. Exempel 3 - Felhantering med undantag.");
            Console.WriteLine("4. Övning 1 - Fånga fel i exempel 1.");
            Console.WriteLine("5. Övning 6 - Metod som hanterar inmatning");
            Console.WriteLine("6. Övning 7 - Mata in start, stopp och steg.");

            Console.WriteLine();

            //Läs in menyval
            Console.Write("Ange siffra för vad du vill göra: ");
            string val = Console.ReadLine();

            //Ett par tomma rader
            Console.WriteLine();
            Console.WriteLine();

            //Använd en switch-sats för att anropa den metod som hör ihop med menyvalet.
            switch (val)
            {
                case "1":
                    Exempel1();
                    break;
                case "2":
                    Exempel2();
                    break;
                case "3":
                    Exempel3();
                    break;
                case "4":
                    Ovning1();
                    break;
                case "5":
                    Ovning6();
                    break;
                case "6":
                    Ovning7();
                    break;
            }

            Console.ReadKey();
        }

        static void Exempel1()
        {
            /*
             * Exempel 1. 
             * Beräkning av timlön.
             * Utan felhantering
             */

            Console.Write("Ange din inkomst: ");
            int inkomst = int.Parse(Console.ReadLine());
            Console.Write("Ange antal timmar: ");
            int timmar = int.Parse(Console.ReadLine());

            Console.WriteLine("Din timlön blev: " + (inkomst / timmar) + " kr/h.");
        }

        static void Exempel2()
        {
            /*
             * Exempel 2. 
             * Beräkning av timlön.
             * Planera för fel med metoden TryParse.
             */


            bool inmatat = false;
            int inkomst = 0;
            int timmar = 0;

            while (!inmatat)
            {
                Console.Write("Ange din inkomst: ");
                inmatat = int.TryParse(Console.ReadLine(), out inkomst);
                if (!inmatat)
                    Console.WriteLine("Mata in ett heltal tack!");
            }

            //Nollställ variabeln
            inmatat = false;
            while (!inmatat)
            {
                Console.Write("Ange antal timmar: ");
                inmatat = int.TryParse(Console.ReadLine(), out timmar);
                if (!inmatat)
                    Console.WriteLine("Mata in ett heltal tack!");
            }

            Console.WriteLine("Din timlön blev: " + (inkomst / timmar) + " kr/h.");

        }
        static void Exempel3()
        {
            /*
             * Exempel 3. 
             * De viktigaste ingredienserna i undantagshantering
             */

            try
            {
                Console.Write("Ange ett heltal: ");
                int heltal = int.Parse(Console.ReadLine());
            }
            catch(FormatException e)
            {
                Console.WriteLine("Format " + e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
            finally
            {
                Console.WriteLine("Programmet har stött på ett fel.");
            }


            Console.WriteLine("Programmet avslutades korrekt.");
        }

        static void Ovning1()
        {
            // Övning 1

            try // Försök för hela blocket nedan, om fel då fånga felet
            {
                Console.Write("Ange din inkomst: ");
                int inkomst = int.Parse(Console.ReadLine());
                Console.Write("Ange antal timmar: ");
                int timmar = int.Parse(Console.ReadLine());
                Console.WriteLine("Din timlön blev: " + (inkomst / timmar) + " kr/h.");
            }
            catch (FormatException e) // Fånga fel där inmatning är av fel format, inte integer för int.Parse
            {
                Console.WriteLine("Fel Format\nError Meddelande: " + e.Message); // Skriv ut ett förklarande meddelandet och error meddelandet
            }
            catch (Exception e)
            {
                // Skriv errorns meddelandet och krascha programmet
                Console.WriteLine(e.Message);
                throw;
            }
        }

        static void Ovning7()
        {
            int start, stopp, steg; // Initial värde

            // Mata in start siffra med fel hantering
            Console.Write("Start: ");
            while (!int.TryParse(Console.ReadLine(), out start))
                Console.Write("\nAnge ett heltal\nStart: ");

            // Mata in stopp siffra med fel hantering
            Console.Write("Stopp: ");
            while (!int.TryParse(Console.ReadLine(), out stopp))
                Console.Write("\nAnge ett heltal\nStopp: ");

            do // Do för att minst köra in en gång
            {
                // Mata in steg siffra med fel hantering
                Console.Write("Steg: ");
                while (!int.TryParse(Console.ReadLine(), out steg))
                    Console.Write("\nAnge ett heltal\nSteg: ");

                // Om talet är noll så kommer det aldrig nå stopp, därför hanteras detta här först samt för att undvika noll division i nästa steg
                if (steg != 0)
                {
                    // Om stopp minus start kommer ha samma tecken som steg (positiv eller negativ) så kommer programmet att nå stopp
                    // Därför vid division av dessa två värde kommer det alltid att vara positiv om inte då är det fel
                    if ((stopp - start) / steg > 0)
                        break; // Om inget fel med steg talet, då ut från do-while loop och fortsätt vidare
                }
                Console.Write("\nAnge ett steg tal som med går att nå stopp talet\n");
            } while (true);

            // Skriv om talen steget så att det når rätt stopp om steg är negativ eller positiv. For loop ser om skillnaden mellan variabeln i och stopp når varandra.
            for (int i = start; Math.Abs(steg) / steg * (i - stopp) <= 0; i += steg)
                Console.Write($"{i} ");
        }

        static void IntInmatningParser(out int talAttInmata, string meddelande = "Ange tal:") // Meddelandet är den string som skriv ut för att veta vad man ska mata in
        {
            // ANVÄNDS I ÖVNING 6

            // Skriv ut inmatnings meddelande
            Console.Write(meddelande);

            // Kör while loop tills användaren skriver rätt input
            while (!int.TryParse(Console.ReadLine(), out talAttInmata))
                Console.Write("\nMata in ett heltal tack!\n" + meddelande); // När det är fel så skrivs det ett fel meddelande och inmatnings meddlandet återigen.
        }

        static void Ovning6()
        {
            // Deklarera inkomst och timmar variablarna och skicka dem till metoden
            IntInmatningParser(out int inkomst, "Ange inkomst: ");
            IntInmatningParser(out int timmar, "Ange timmar: ");

            // Skriv ut resultatet
            Console.WriteLine("Din timlön blev: " + (inkomst / timmar) + " kr/h.");
        }

        
    }
}