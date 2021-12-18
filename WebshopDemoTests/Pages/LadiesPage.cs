using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebshopDemoTests.Pages
{
    public class LadiesPage
    {
        private readonly IWebDriver _driver;

        private readonly WebDriverWait _wait;

        public LadiesPage(IWebDriver driver, WebDriverWait wait)
        {
            _driver = driver;
            _wait = wait;
        }

        private IWebElement ItemType => _driver.FindElement(By.XPath("//div[@id='collapse2_dsk']//a[normalize-space()='leggings']"));
        private IWebElement PageName => _driver.FindElement(By.XPath("//h1[normalize-space()='Ladies']"));

        public ItemPage SelectItemType()
        {
            _wait.Until(pred => ItemType.Displayed);
            ItemType.Click();
            return new ItemPage(_driver, _wait);
        }

        public void IsOnLadiesPage()
        {
            _wait.Until(pred => PageName.Displayed);
            Assert.AreEqual("Ladies", PageName.Text);
        }
    }
}
