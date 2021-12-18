using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebshopDemoTests.Pages
{
    public class ItemPage
    {
        private readonly IWebDriver _driver;

        private readonly WebDriverWait _wait;
        public ItemPage(IWebDriver driver, WebDriverWait wait)
        {
            _driver = driver;
            _wait = wait;
            PageFactory.InitElements(_driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//span[@id='lblProductName']")]
        public IWebElement ProductName;

        [FindsBy(How = How.XPath, Using = "//span[contains(text(),'Add to bag')]")]
        public IWebElement BtnAddToBag;

        [FindsBy(How = How.XPath, Using = "//span[contains(text(),'View Bag')]")]
        public IWebElement BtnViewBag;

        [FindsBy(How = How.XPath, Using = "//span[@class='FilterName'][normalize-space()='adidas']")]
        public IWebElement BrandCheckBox;

        [FindsBy(How = How.XPath, Using = "//span[@id='lblCategoryHeader']")]
        public IWebElement PageName;

        [FindsBy(How = How.XPath, Using = "//li[3]//div[1]//div[1]//div[2]//div[1]//div[1]//a[1]//span[1]//span[1]")]
        public IWebElement Item;
        
        [FindsBy(How = How.XPath, Using = "//body/div[@id='BodyWrap']/div[1]/div[1]/div[1]/div[1]/div[3]/section[1]/div[2]/div[1]/div[1]/div[1]/div[2]/div[1]/div[2]/div[3]/div[3]/div[1]/div[1]/div[2]/ul[1]/li[1]/a[1]")]
        public IWebElement Size;

        public void VerifyItemName(string name)
        {
            _wait.Until(pred => ProductName.Displayed);
            Assert.AreEqual(name, ProductName.Text);
        }

        public void AddToBag()
        {
            _wait.Until(pred => BtnAddToBag.Displayed);
            BtnAddToBag.Click();
        }

        public BagPage ViewBag()
        {
            _wait.Until(pred => BtnViewBag.Displayed);
            BtnViewBag.Click();
            return new BagPage(_driver, _wait);
        }

        public void FilterItems()
        {
            _wait.Until(pred => BrandCheckBox.Displayed);
            BrandCheckBox.Click();
            _wait.Until(pred => BrandCheckBox.Enabled);
        }

        public void VerifyCheckBoxIsChecked()
        {
            Assert.IsTrue(BrandCheckBox.Enabled);
        }

        public void VerifyPageName()
        {
            _wait.Until(pred => PageName.Displayed);
            Assert.AreEqual("TIGHTS AND LEGGINGS", PageName.Text);
        }

        public void SelectProduct()
        {
            _wait.Until(pred => Item.Displayed);
            Item.Click();
        }

        public void SelectSize()
        {
            _wait.Until(pred => Size.Displayed);
            Size.Click();
        }
    }
}
