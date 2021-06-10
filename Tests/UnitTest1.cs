using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimbirSoftTest;

namespace Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void FindUniq()
        {
            WordCounter test = new WordCounter();
            test.Count("Hello world world");
            Assert.AreEqual(2, test.words.Count);
        }

        [TestMethod]
        public void CountUniq()
        {
            WordCounter test = new WordCounter();
            test.Count("Hello world! world");
            UniqWord wordTest = test.words[0];
            Assert.AreEqual(wordTest.StringToPrint, "world - 2");
        }
        [TestMethod]
        public void IncorrectSiteName()
        {
            string incorrecctSite = "https:/.com/";
            try
            {
                SiteInfo inf = new SiteInfo(incorrecctSite);
            }
            catch (System.Exception ex)
            {
                Assert.AreEqual(ex.Message, "Site url is incorrect " + incorrecctSite);
            }
        }

        [TestMethod]
        public void IncorrectSiteName2()
        {
            string incorrecctSite = "hps://www.simbirsoft.com/";
            try
            {
                SiteInfo inf = new SiteInfo(incorrecctSite);
            }
            catch (System.Exception ex)
            {
                Assert.AreEqual(ex.Message, "Site url is incorrect " + incorrecctSite);
            }
        }

        [TestMethod]
        public void CorrectWork()
        {
            //idk if this kind of test is meaningful
            SiteInfo inf = new SiteInfo("https://www.simbirsoft.com/");
            inf.SaveSiteTo("siteTest");
            inf.GetWords();
            UniqWord wordsTest = inf.words.words[0];
            Assert.AreEqual(wordsTest.word, "и");
        }
    }
}
