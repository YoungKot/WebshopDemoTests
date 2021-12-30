using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebshopDemoTests.Pages
{
    public class MainPage
    {
        private const string url = "https://lv.sportsdirect.com/";

        private readonly IWebDriver _driver;

        private readonly WebDriverWait _wait;

        public MainPage(IWebDriver driver, WebDriverWait wait)
        {
            _driver = driver;
            _wait = wait;
        }

        private IWebElement SearchBox => _driver.FindElement(By.XPath("//input[@id='txtSearch']"));

        private IWebElement Category => _driver.FindElement(By.LinkText("Womens"));

        public void OpenWebpage()
        {
            _driver.Url = url;
        }

        public ItemPage SearchText(string name)
        {
            _wait.Until(pred => SearchBox.Enabled);
            SearchBox.SendKeys(name);
            SearchBox.SendKeys(Keys.Enter);
            return new ItemPage(_driver, _wait);
        }
   
        public LadiesPage GetToLadiesPage()
        {
            _wait.Until(pred => Category.Displayed);
            Category.Click();
            return new LadiesPage(_driver, _wait);
        }

    }
}
