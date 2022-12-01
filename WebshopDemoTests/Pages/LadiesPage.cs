using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using WebshopDemoTests.Helpers;

namespace WebshopDemoTests.Pages
{
    public class LadiesPage
    {
        private readonly IWebDriver _driver;

        private readonly WebDriverWait _wait;

        private readonly WaitHelper _waitHelper;

        public LadiesPage(IWebDriver driver, WebDriverWait wait)
        {
            _driver = driver;
            _wait = wait;
            _waitHelper = new WaitHelper(_wait);
        }

        internal IWebElement? ItemType => _driver.FindElement(By.LinkText("Leggings"));

        public ItemPage SelectItemType()
        {
            _waitHelper.VerifyItemDisplayed(ItemType!);
            ItemType!.Click();
            return new ItemPage(_driver, _wait);
        }

        public bool IsOnLadiesPage()
        {
            return _driver.Url.Contains("ladies");
        }
    }
}
