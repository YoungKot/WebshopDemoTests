using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace WebshopDemoTests.Helpers
{
    public class WaitHelper
    {
        private readonly WebDriverWait _wait;
        public WaitHelper(WebDriverWait wait)
        {
            _wait = wait;
        }

        public void VerifyItemDisplayed(IWebElement item)
        {
            _wait.Until(pred => item.Displayed);
        }

        public void VerifyItemEnabled(IWebElement item)
        {
            _wait.Until(pred => item.Enabled);
        }
    }
}
