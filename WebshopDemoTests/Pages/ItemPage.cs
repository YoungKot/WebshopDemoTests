using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using WebshopDemoTests.Helpers;

namespace WebshopDemoTests.Pages
{
    public class ItemPage
    {
        private readonly IWebDriver _driver;

        private readonly WebDriverWait _wait;

        private readonly WaitHelper _waitHelper;

        public ItemPage(IWebDriver driver, WebDriverWait wait)
        {
            _driver = driver;
            _wait = wait;
            _waitHelper = new WaitHelper(_wait);
            PageFactory.InitElements(_driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//span[@id='lblProductName']")]
        private readonly IWebElement? ProductName;

        [FindsBy(How = How.XPath, Using = "//span[@class='addToBagInner']")]
        private readonly IWebElement? BtnAddToBag;

        [FindsBy(How = How.XPath, Using = "//span[contains(text(),'View Bag')]")]
        private readonly IWebElement? BtnViewBag;

        [FindsBy(How = How.XPath, Using = "//span[@data-filtername='adidas']")]
        private readonly IWebElement? BrandCheckBox;

        [FindsBy(How = How.XPath, Using = "//span[@id='lblCategoryHeader']")]
        private readonly IWebElement? PageName;

        [FindsBy(How = How.XPath, Using = "//div[@id='productlistcontainer']/ul/li[1]")]
        private readonly IWebElement? Item;
        
        [FindsBy(How = How.XPath, Using = "//ul[@class='row sizeButtons']/li[1]")]
        private readonly IWebElement? Size;

        public void AddToBag()
        {
            _waitHelper.VerifyItemEnabled(BtnAddToBag!);

            BtnAddToBag!.Click();
        }

        public bool VerifyBrandCheckBoxEnabled()
        {
            return BrandCheckBox!.Enabled;
        }

        public void VerifyButtonViewBagEnabled()
        {
            _waitHelper.VerifyItemEnabled(BtnViewBag!);
        }

        public BagPage ViewBag()
        {
            BtnViewBag!.Click();

            return new BagPage(_driver, _wait);
        }

        public void FilterItems()
        {
            _waitHelper.VerifyItemDisplayed(BrandCheckBox!);

            BrandCheckBox!.Click();

            _waitHelper.VerifyItemEnabled(BrandCheckBox!);
        }

        public void VerifyPageNameDisplayed()
        {
            _waitHelper.VerifyItemDisplayed(PageName!);
        }

        public string GetPageName()
        {
            return PageName!.Text;
        }

        public void SelectProduct()
        {
            _waitHelper.VerifyItemDisplayed(Item!);

            Item!.Click();
        }

        public void SelectSize()
        {
            _waitHelper.VerifyItemEnabled(Size!);

            Size!.Click();       
        }

        public string GetProductName()
        {
            _waitHelper.VerifyItemDisplayed(ProductName!);

            return ProductName!.Text;
        }
    }
}
