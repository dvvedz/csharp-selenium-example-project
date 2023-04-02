
using NUnit.Framework;
using OpenQA.Selenium;
using System.Net;

[TestFixture]
internal class Program : SetupTest 
{

    [SetUp]
    public void BeforeEach()
    {
        string url = "https://www.icabanken.se/lana/privatlan/";
        driver.Navigate().GoToUrl(url);

        var cookieBtn = "//button[contains(.,'Godkänn')]".ByXPath();

        mywait.WaitElementVisible(By.XPath("//button[contains(.,'Godkänn')]"));
        cookieBtn.Click();
    }

    [TestCase("20000", "8")]
    [TestCase("50000", "15")]
    public void IcaSlider(string loanAmount, string loanYears)
    {
        var eleSliderMoney = "(//input[contains(@class, 'slider_currentValueEdit')])[1]".ByXPath();
        js.ExecuteScript("arguments[0].style.display='block';", eleSliderMoney);
        eleSliderMoney.SendKeys(loanAmount);
        js.ExecuteScript("arguments[0].style.display='none';", eleSliderMoney);

        var eleSliderYear = "(//input[contains(@class, 'slider_input')])[2]".ByXPath();
        var eleSliderMaxValue = "((//div[contains(@class, 'slider_negativeMargin')])[2]/child::span)[2]".ByXPath();

        Assert.AreEqual(loanYears, eleSliderYear.GetAttribute("max"));
        Assert.AreEqual( $"{loanYears} år", eleSliderMaxValue.Text);
    }

    [TestCase("1", "20000")]
    [TestCase("99999999", "500000")]
    public void IcaSliderMinMaxLoan(string loanAmount, string expected)
    {
        var eleSliderMoney = "(//input[contains(@class, 'slider_currentValueEdit')])[1]".ByXPath();
        js.ExecuteScript("arguments[0].style.display='block';", eleSliderMoney);
        eleSliderMoney.SendKeys(loanAmount);
        js.ExecuteScript("arguments[0].style.display='none';", eleSliderMoney);

        // verify that input is 20,000 || 500,000 after changeing it to 1 || 9999999
        Assert.AreEqual(expected, eleSliderMoney.GetAttribute("value"));
    }


    [Test]
    public void WaitTestOnIca()
    {
        var icaChatId = "twc-launchbutton";
        var icaChatPopUpId = "twc-chat-window";

        // Click chat button 
        var chatEle = mywait.WaitElementVisible(By.Id(icaChatId),2000);
        chatEle.Click();

        // Verify that popup window has appeard 
        var chatPopUpEle = icaChatPopUpId.ById();

        // js.ExecuteScript("arguments[0].style.display='none';", chatPopUpEle); // False test
        if (chatPopUpEle.Displayed != true) { Assert.Fail("chat popup is not vissible"); }
    }

    [Test]
    public async Task StubTest()
    {
        var stubber = new NetworkStub();

        // Setup a response for a URL
        stubber.SetupResponse("https://www.icabanken.se/lana/privatlan/", HttpStatusCode.OK, "Hello Stub");

        // Use the stubbed HttpClient instance to make a request
        var httpClient = stubber.GetStubbedHttpClient();
        var response = await httpClient.GetAsync("https://www.icabanken.se/lana/privatlan/");

        // assert that the response is what we expected
        Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        Assert.AreEqual("Hello Stub", await response.Content.ReadAsStringAsync());

        stubber.VerifyNoOutstandingRequest();
    }
}