using NUnit.Framework;
using OpenQA.Selenium;

[TestFixture]
internal class AnsokOmPrivatLan : SetupTest
{
    
    [SetUp]
    public void BeforeEach()
    {
        string url = "https://www.icabanken.se/lana/privatlan/ansok-om-lan/";
        driver.Navigate().GoToUrl(url);
        // Accept cookies popup
        mywait.WaitElementVisible(By.XPath("//button[contains(.,'Godkänn')]")).Click();
        // wait for spinner to not be visible
        Assert.IsTrue(mywait.WaitElementInvisible(By.XPath("//div[contains(@class,'loading_block')]")));
    }

    [Test]
    public void FragorOmLanetStepOne_HarMedsokande() {
        AnsokOmPrivatLanPage ansokOmPrivatLan = new AnsokOmPrivatLanPage();

        ansokOmPrivatLan.ClickMedsokandeJa();
        ansokOmPrivatLan.FillMedsokandeForm("Oskar", "Test", "19900101-0000");
        ansokOmPrivatLan.ClickLosaAndraLånNejBtn();
    }
}

