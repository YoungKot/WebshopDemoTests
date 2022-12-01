using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using WebshopDemoTests.Helpers;

namespace WebshopDemoTests.Pages
{
    public class BagPage
    {
        private readonly IWebDriver _driver;

        private readonly WebDriverWait _wait;

        private readonly WaitHelper _waitHelper;
        public BagPage(IWebDriver driver, WebDriverWait wait)
        {
            _driver = driver;
            _wait = wait;
            _waitHelper = new WaitHelper(_wait);
            PageFactory.InitElements(_driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//span[@id='SubtotalLabel']")]
        internal IWebElement? ItemCount;
        public void VerifyItemAmountDisplayed()
        {
            _waitHelper.VerifyItemDisplayed(ItemCount!);
        }

        public string GetItemCount()
        {
            return ItemCount!.Text;
        }
    }
}
