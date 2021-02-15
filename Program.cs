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
    }
}