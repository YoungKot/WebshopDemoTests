using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using WebshopDemoTests.Drivers;
using WebshopDemoTests.Pages;

namespace WebshopDemoTests.Steps
{
    [Binding]
    public sealed class FilterStepDefinitions
    {
        private readonly MainPage _mainPage;
        private LadiesPage _ladiesPage;
        private ItemPage _itemPage;
        private BagPage _bagePage;

        public FilterStepDefinitions(SeleniumDriver driver)
        {
            _mainPage = new MainPage(driver.Current, driver.Wait);
        }

        [Given(@"The user is on the main page")]
        public void GivenTheUserIsOnTheMainPage()
        {
            _mainPage.OpenWebpage();
        }

        [When(@"the user clicks on 'Womens'")]
        public void WhenTheUserClicksOn()
        {
            _ladiesPage = _mainPage.GetToLadiesPage();
        }

        [Then(@"the page for ladies is shown")]
        public void ThenThePageForLadiesIsShown()
        {
            _ladiesPage.IsOnLadiesPage();
        }

        [When(@"the user selects leggings")]
        public void WhenTheUsserSelectsLeggings()
        {
            _itemPage = _ladiesPage.SelectItemType();
        }

        [Then(@"the legging page is shown")]
        public void ThenTheLeggingPageIsShown()
        {
            _itemPage.VerifyPageName();
        }

        [When(@"the user selects adidas brand")]
        public void WhenTheUserSelectsBarndAdidas()
        {
            _itemPage.FilterItems();
        }

        [Then(@"only adidas items are visible")]
        public void ThenOnlyAdidasItemsAreVisible()
        {
            _itemPage.VerifyCheckBoxIsChecked();
        }

        [When(@"the user selects an item")]
        public void WhenTheUserSelectsAnItem()
        {
            _itemPage.SelectProduct();
        }

        [Then(@"the item is shown (.*)")]
        public void ThenTheItemIsShown(string name)
        {
            _itemPage.VerifyItemName(name);
        }

        [When(@"the user adds an item to a cart")]
        public void WhenTheUserAddsAnItemToACart()
        {
            _itemPage.SelectSize();
            _itemPage.AddToBag();
        }

        [Then(@"the item is added")]
        public void ThenTheItemIsAdded()
        {
            _bagePage = _itemPage.ViewBag();
            _bagePage.VerifyItemAmount();
        }


    }
}
