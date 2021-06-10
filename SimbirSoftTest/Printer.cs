using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace SimbirSoftTest
{


    public class Printer
    {
        public void PrintToFile(SiteInfo site, string fileName)
        {
            //if we've already counted for this site 
            //lets not do it second time
            if (site.words == null) site.GetWords();
            WordCounter wordsToPrint = site.words;
            try
            {
                using (StreamWriter sw = new StreamWriter(fileName, true))
                {
                    sw.WriteLine(site.siteUrl);
                    foreach (UniqWord word in wordsToPrint.words) sw.WriteLine(word.StringToPrint);
                    sw.WriteLine("---------------");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }
        }

        public void PrintToConsole(SiteInfo site)
        {
            //if we've already counted for this site 
            //lets not do it second time
            if (site.words == null) site.GetWords();
            WordCounter wordsToPrint = site.words;
            foreach (UniqWord word in wordsToPrint.words) Console.WriteLine(word.StringToPrint);
            Console.WriteLine("--------------------");
        }
    }
}
