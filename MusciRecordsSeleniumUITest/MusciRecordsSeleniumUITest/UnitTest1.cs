using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Collections.ObjectModel;

namespace MusciRecordsSeleniumUITest
{
    [TestClass]
    public class UnitTest1
    {

        private static readonly string DriverDir = "C:\\Webdrivers";
        private static IWebDriver driver;

        // Initialisere webdriveren
        [ClassInitialize]

        public static void Setup(TestContext testContext)
        {
            driver = new ChromeDriver(DriverDir);
            
            // Static navigation to our site
            driver.Navigate().GoToUrl("https://musicrecordsui.azurewebsites.net/");
        }

        // Rydder ordenligt op efter driveren er initaliseret 
        [ClassCleanup]
        public static void Cleanup()
        {
            driver.Dispose();
        }

        [TestMethod]
        public void TestForTitle()
        {
            // Tester om titlen på vores dokument er MuscrecrodsUI

            Assert.AreEqual("MusicRecordsUI", driver.Title);
          
        }

        [TestMethod]
        public void TestCountForElements()
        {
            
            // Venter i 10 sekunder på at klade webdriveren
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            // Kalder listen og tester om den indholder Title1 i en af elementerne i listen
            IWebElement recordsList = wait.Until(d => d.FindElement(By.Id("recordlist")));
            Assert.IsTrue(recordsList.Text.Contains("Title1"));

            // tester for om listen har 5 elementer
            ReadOnlyCollection<IWebElement> listOfRecords = driver.FindElements(By.ClassName("record-element"));
            Assert.AreEqual(5, listOfRecords.Count());


        }
    }
}