using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using WebshopDemoTests.Helpers;

namespace WebshopDemoTests.Pages
{
    public class MainPage
    {
        private const string url = "https://lv.sportsdirect.com/";

        private readonly IWebDriver _driver;

        private readonly WebDriverWait _wait;

        private readonly WaitHelper _waitHelper;

        public MainPage(IWebDriver driver, WebDriverWait wait)
        {
            _driver = driver;
            _wait = wait;
            _waitHelper = new WaitHelper(_wait);
        }

        private IWebElement SearchBox => _driver.FindElement(By.XPath("//input[@type='search']"));

        private IWebElement Category => _driver.FindElement(By.LinkText("Womens"));

        public void OpenWebpage()
        {
            _driver.Url = url;
        }

        public ItemPage SearchText(string name)
        {
            _waitHelper.VerifyItemEnabled(SearchBox);

            SearchBox.SendKeys(name);

            SearchBox.SendKeys(Keys.Enter);

            return new ItemPage(_driver, _wait);
        }
   
        public LadiesPage GetToLadiesPage()
        {
            _waitHelper.VerifyItemEnabled(Category);

            Category.Click();

            return new LadiesPage(_driver, _wait);
        }
    }
}
