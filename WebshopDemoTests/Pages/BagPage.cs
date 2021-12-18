using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebshopDemoTests.Pages
{
    public class BagPage
    {
        private readonly IWebDriver _driver;

        private readonly WebDriverWait _wait;
        public BagPage(IWebDriver driver, WebDriverWait wait)
        {
            _driver = driver;
            _wait = wait;
            PageFactory.InitElements(_driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//span[@id='SubtotalLabel']")]
        public IWebElement ItemCount;
        public void VerifyItemAmount()
        {
            _wait.Until(pred => ItemCount.Displayed);
            Assert.AreEqual("1 item", ItemCount.Text);
        }
    }
}
