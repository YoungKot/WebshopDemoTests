using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using WebshopDemoTests.Helpers;

namespace WebshopDemoTests.Pages
{
    public class CountryPage
    {
        private readonly IWebDriver _driver;

        private readonly WebDriverWait _wait;

        private readonly Actions actions;

        private readonly WaitHelper _waitHelper;

        public CountryPage(IWebDriver driver, WebDriverWait wait)
        {
            _driver = driver;
            _wait = wait;
            actions = new Actions(_driver);
            _waitHelper = new WaitHelper(_wait);
            PageFactory.InitElements(_driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//span[@class='languageRoot']")]
        private IWebElement? Country;

        public void VerifyCountryDisplayed()
        {
            _waitHelper.VerifyItemDisplayed(Country!);
        }

        public void ScrollDown()
        {
            actions.MoveToElement(Country!).Perform();
        }

        public string GetCountry()
        {
            return Country!.Text;
        }
    }
}
