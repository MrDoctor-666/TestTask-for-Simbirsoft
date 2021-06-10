using System;
using System.IO;
using System.Net;
using HtmlAgilityPack;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Text;

namespace SimbirSoftTest
{
    public class SiteInfo
    {
        string siteUrl;
        string fileFullName;
        public WordCounter words { get; private set; }

        public SiteInfo(string url)
        {
            //check if correct
            if (!IfCorrectUrl(url)) throw new Exception("Site url is incorrect " + url); 

            siteUrl = url;
            words = null;
        }

        private bool IfCorrectUrl(string url)
        {
            //starts with http:// or https://
            Regex regex = new Regex(@"^(http|http(s)?://)+([\w-]+\.)", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            return regex.IsMatch(url);
        }

        public void SaveSiteTo(string fileName = "site")
        {
            fileFullName = Directory.GetCurrentDirectory() + @"\" + fileName + ".html";
            //save site to fileName path
            using (WebClient client = new WebClient())
            {
                Console.WriteLine(siteUrl);
                string html = client.DownloadString(siteUrl);
                File.WriteAllText(fileFullName, html);
                Console.WriteLine("File saved to " + fileFullName);
            }

        }
        public void GetWords()
        {
            //loadfile
            if (fileFullName == null) SaveSiteTo();
            var doc = new HtmlDocument();
            doc.Load(fileFullName);

            //get words info
            words = new WordCounter();
            words.Count(doc.DocumentNode.InnerText);
        }
    }
}
