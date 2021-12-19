using OpenQA.Selenium;
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

        private IWebElement Item => _driver.FindElement(By.XPath("/html[1]/body[1]/div[6]/div[1]/div[1]/div[1]/div[1]/div[3]/section[1]/div[2]/div[3]/div[1]/div[2]/div[2]/ul[1]/li[1]/div[1]/div[1]/div[2]/div[1]/div[1]/a[1]/span[2]/span[1]"));

        private IWebElement Category => _driver.FindElement(By.XPath("//a[@id='lnkTopLevelMenu_2347182']"));

        public void OpenWebpage()
        {
            _driver.Url = url;
        }

        public void SearchText(string name)
        {
            _wait.Until(pred => SearchBox.Displayed);
            SearchBox.SendKeys(name);
            SearchBox.SendKeys(Keys.Enter);
        }

        public ItemPage SelectItem()
        {
            _wait.Until(pred => Item.Displayed);
             Item.Click();
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
