using NUnit.Framework;
using OpenQA.Selenium;

internal class AnsokOmPrivatLanPage : SetupTest

{
    private By titleH1 = By.XPath("//h3[contains(text(), 'Frågor om lånet')]");
    private By fragorOmLanetBody = By.XPath("//div[contains(@class, 'step_stepBody')]");
    private By medsokandeJaBtn = By.XPath("(//input[@name='coApplicant']/ancestor::label)[1]");
    private By medsokandeNejBtn = By.XPath("(//input[@name='coApplicant'])[2]//ancestor::label");
    private By medsokandeFornamnInput = By.Name("coApplicantInformation.coApplicantFirstName");
    private By medsokandeEfternamnInput = By.Name("coApplicantInformation.coApplicantLastName");
    private By medsokandePersonnummerInput = By.Name("coApplicantInformation.coApplicantPersonalNumber");

    private By losaAndraLanJaBtn = By.XPath("(//input[@name='settleOtherLoans'])[2]/..");


    public AnsokOmPrivatLanPage()
    {
        string currentPage = "Ansök om lån | ICA Banken";
        try {
            Assert.AreEqual(currentPage, driver.Title);
        } catch (Exception ex) {
            throw new WebDriverException($"This is not '{currentPage}' page. current page is: {driver.Title}\n\t\tand url is: {driver.Url}", ex);
        }
    }

    public AnsokOmPrivatLanPage ClickMedsokandeJa()
    {
        driver.FindElement(medsokandeJaBtn).Click();
        return this;
    }

    public AnsokOmPrivatLanPage ClickMedsokandeNej()
    {
        driver.FindElement(medsokandeNejBtn).Click();
        return this;
    }

    public AnsokOmPrivatLanPage FillMedsokandeForm(string fornamn, string efternamn, string personnummer)
    {
        driver.FindElement(medsokandeFornamnInput).SendKeys(fornamn);
        driver.FindElement(medsokandeEfternamnInput).SendKeys(efternamn);
        driver.FindElement(medsokandePersonnummerInput).SendKeys(personnummer);
        return this;
    }

    public AnsokOmPrivatLanPage ClickLosaAndraLånJaBtn()
    {
        driver.FindElement(losaAndraLanJaBtn).Click();
        return this;
    }

    public AnsokOmPrivatLanPage ClickLosaAndraLånNejBtn()
    {
        driver.FindElement(losaAndraLanJaBtn).Click();
        return this;
    }

}

