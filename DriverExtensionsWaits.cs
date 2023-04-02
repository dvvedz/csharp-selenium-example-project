using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using static SetupTest;

public class DriverExtensionsWaits
{

    public const int customTimeout = 10000;

    public IWebElement WaitElementVisible(By by, int timeout = customTimeout)
    {
        IWebElement waitUntil;
        try
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromMilliseconds(timeout));
            return waitUntil = wait.Until(ExpectedConditions.ElementIsVisible(by));
        }
        catch (Exception ex)
        {
            throw new WebDriverTimeoutException($"WaitElementVisible() timed out after {timeout}ms", ex);
        }
    }

    public IWebElement WaitElementExist(By by, int timeout = customTimeout)
    {
        IWebElement waitUntil;

        try
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromMilliseconds(timeout));
            waitUntil = wait.Until(ExpectedConditions.ElementExists(by));
        }
        catch (Exception ex)
        {
            throw new WebDriverTimeoutException($"WaitElementExist() timed out after {timeout}ms", ex);
        }

        return waitUntil;
    }

    /// <summary>
    /// Wait for an element to be invisible
    /// </summary>
    /// <param name="By">The locator of the element you want to wait for.</param>
    /// <param name="timeout">The amount of time to wait for the element to be invisible.</param>
    public bool WaitElementInvisible(By by, int timeout = customTimeout)
    {
        bool waitUntil;

        try
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromMilliseconds(timeout));
            waitUntil = wait.Until(ExpectedConditions.InvisibilityOfElementLocated(by));
        }
        catch (Exception ex)
        {
            throw new WebDriverTimeoutException($"WaitElementExists() timed out after {timeout}ms", ex);
        }

        return waitUntil;
    }
    public bool WaitUrlChange(string newUrl, int timeout = customTimeout)
    {
        bool waitUntil;
        try { 
            var wait = new WebDriverWait(driver, TimeSpan.FromMilliseconds(timeout));
            waitUntil = wait.Until(ExpectedConditions.UrlToBe(newUrl));
        } catch (Exception ex){ 
            throw new WebDriverTimeoutException($"WaitUrlChange({newUrl}) timed out after {timeout}ms", ex);
        }
        return waitUntil;
    }

    public bool WaitPageLoad(string url, int timeout = customTimeout)
    {
        bool waitUntil;

        try
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromMilliseconds(timeout));
            waitUntil = wait.Until(driver => ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").Equals("complete"));
        }
        catch (Exception ex)
        {
            throw new WebDriverTimeoutException($"WaitPageLoad({url}) timed out after {timeout}ms", ex);
        }
        return waitUntil;
    }
}

