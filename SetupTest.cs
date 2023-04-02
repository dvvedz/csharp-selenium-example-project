
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using NUnit.Framework;

// Watch tests run in container http://localhost:7900/?autoconnect=1&resize=scale&password=secret
// Location to selenium grid http://localhost:4444/ui

class SetupTest {
    public static IWebDriver driver;
    public static IJavaScriptExecutor js;
    public static DriverExtensionsWaits mywait;

    [SetUp]
    public void Initialize()
    {
        ChromeOptions options = new ChromeOptions();
        driver = new RemoteWebDriver(new Uri("http://localhost:4444"), options);

        js = (IJavaScriptExecutor) driver;

        mywait = new DriverExtensionsWaits();
    }

    [TearDown]
    public void CleanUp()
    {
        // if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
        //{
        //    Console.WriteLine($"TESTERXXXXX {TestContext.CurrentContext.Test.Name}");
        //}
        if (driver != null)
        {
            driver.Close();
            // driver.Dispose();
            driver.Quit();
            driver = null;
        }
    }
}