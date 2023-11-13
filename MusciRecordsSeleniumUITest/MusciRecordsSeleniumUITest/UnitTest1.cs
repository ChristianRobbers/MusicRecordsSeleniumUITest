using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

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
        }

        // Rydder ordenligt op efter driveren er initaliseret 
        [ClassCleanup]
        public static void Cleanup()
        {
            driver.Dispose();
        }

        [TestMethod]
        public void TestMethod1()
        {
            driver.Navigate().GoToUrl("https://musicrecordsui.azurewebsites.net/");
            Assert.AreEqual("MusicRecordsUI", driver.Title);

          
        }
    }
}