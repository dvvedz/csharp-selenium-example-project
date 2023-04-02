using OpenQA.Selenium;

static class DriverExtensions
{
    /// <summary>
    /// GetId returns the element with the specified id.
    /// </summary>
    /// <param name="id">The id of the element you want to find.</param>
    /// <returns>
    /// The element with the id that is passed in.
    /// </returns>
    public static IWebElement ById(this string id)
    {
        IWebElement ele;
        try
        {
            ele = SetupTest.driver.FindElement(By.Id(id));
        }
        catch (Exception)
        {
            throw new NoSuchElementException($"could not find element with id {id}");
        }
        return ele;
    }

    /// <summary>
    /// GetClassName returns an IWebElement object that is found by the class name.
    /// </summary>
    /// <param name="className">The class name to search for.</param>
    /// <returns>
    /// The element with the class name.
    /// </returns>
    public static IWebElement ByClassName(this string className) { return SetupTest.driver.FindElement(By.ClassName(className)); }

    /// <summary>
    /// GetCssSelector returns an IWebElement object that is found by the cssSelector parameter.
    /// </summary>
    /// <param name="cssSelector">The CSS selector to find the element by.</param>
    /// <returns>
    /// The element that matches the cssSelector
    /// </returns>
    public static IWebElement ByCssSelector(this string cssSelector) { return SetupTest.driver.FindElement(By.CssSelector(cssSelector)); }

    /// <summary>
    /// It returns a link element by its text.
    /// </summary>
    /// <param name="linkText">The text of the link you want to find.</param>
    /// <returns>
    /// The element that has the link text.
    /// </returns>
    public static IWebElement ByLinkText(this string linkText) { return SetupTest.driver.FindElement(By.LinkText(linkText)); }

    public static IWebElement ByName(this string name) { return SetupTest.driver.FindElement(By.Name(name)); }

    public static IWebElement ByTagName(this string tagName) { return SetupTest.driver.FindElement(By.TagName(tagName)); }

    /// <summary>
    /// It takes a string, and returns an IWebElement
    /// </summary>
    /// <param name="XPath">The XPath of the element you want to find.</param>
    /// <returns>
    /// The element that matches the XPath.
    /// </returns>
    public static IWebElement ByXPath(this string XPath) { return SetupTest.driver.FindElement(By.XPath(XPath)); }

}