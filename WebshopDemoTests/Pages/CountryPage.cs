using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebshopDemoTests.Pages
{
    public class CountryPage
    {
        private readonly IWebDriver _driver;

        private readonly WebDriverWait _wait;

        private readonly Actions actions;

        public CountryPage(IWebDriver driver, WebDriverWait wait)
        {
            _driver = driver;
            _wait = wait;
            actions = new Actions(_driver);
            PageFactory.InitElements(_driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//span[@class='languageRoot']")]
        public IWebElement Country;

        public void VerifyCountryName()
        {
            _wait.Until(pred => Country.Displayed);
            Assert.AreEqual("Latvia", Country.Text);
        }

        public void ScrollDown()
        {   
            actions.MoveToElement(Country);
            actions.Perform();
        }
    }
}
