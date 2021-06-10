using System;
using System.IO;

namespace SimbirSoftTest
{
    class Program
    {
        static void Main(string[] args)
        {
            /*SiteInfo inf = new SiteInfo("https://www.simbirsoft.com/");
            Printer printer = new Printer();
            printer.PrintToConsole(inf);*/
            GetSitesFromFile();
        }

        //type of input can be anyrhing, so i'll leave it simple
        public static void GetSitesFromFile(string inFileName = "sitesList.txt")
        {
            //if input file doesnt exist
            //work for simbirsoft.com
            Console.WriteLine("Enter output file name: ");
            string outFileName = Console.ReadLine();
            if (!File.Exists(inFileName)) {
                Console.WriteLine("File with such path doesn't exist, implimenting standart");
                SiteInfo inf = new SiteInfo("https://www.simbirsoft.com/");
                Printer printer = new Printer();
                printer.PrintToConsole(inf);
                return;
            }

            // Read the file and display it line by line.  
            string line;
            StreamReader file = new StreamReader(Directory.GetCurrentDirectory() + "\\" + inFileName);
            while ((line = file.ReadLine()) != null)
            {
                Console.WriteLine(line);
                try
                {
                    SiteInfo inf = new SiteInfo(line);
                    Printer printer = new Printer();
                    printer.PrintToConsole(inf);
                    printer.PrintToFile(inf, outFileName);
                    Console.WriteLine();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Couldn't read site " + line + "\n" + ex.Message);
                }
            }
            file.Close();
        }
    }
}
