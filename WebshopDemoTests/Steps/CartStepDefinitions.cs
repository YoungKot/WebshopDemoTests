using FluentAssertions;
using TechTalk.SpecFlow;
using WebshopDemoTests.Drivers;
using WebshopDemoTests.Pages;

namespace WebshopDemoTests.Steps
{
    [Binding]
    public sealed class CartStepDefinitions
    {
        private readonly MainPage _mainPage;

        private ItemPage? _itemPage;

        private BagPage? _bagPage;

        public CartStepDefinitions(SeleniumDriver driver)
        {
            _mainPage = new MainPage(driver.Current, driver.Wait);
        }

        [Given(@"User is on the main page")]
        public void GivenUserIsOnTheMainPage()
        {
            _mainPage.OpenWebpage();
        }

        [When(@"User types (.*) in the searchbar")]
        public void WhenUserTypesInTheSearchbar(string name)
        {
            _itemPage = _mainPage.SearchText(name);

            _itemPage.SelectProduct();
        }

        [Then(@"item is shown (.*)")]
        public void ThenItemIsShown(string name)
        {
            _itemPage!.SelectSize();

            name.Should().Be(_itemPage.GetProductName());
        }

        [When(@"User clicks on the button 'Add to bag'")]
        public void WhenUserClicksOnTheButton()
        {
            _itemPage!.AddToBag();
        }

        [Then(@"item is added")]
        public void ThenItemIsAdded()
        {
            _itemPage!.VerifyButtonViewBagEnabled();

            _bagPage = _itemPage!.ViewBag();

            _itemPage!.VerifyBrandCheckBoxEnabled().Should().BeTrue();

            _bagPage.VerifyItemAmountDisplayed();

            _bagPage.GetItemCount().Should().Be("1 item");
        }
    }
}
