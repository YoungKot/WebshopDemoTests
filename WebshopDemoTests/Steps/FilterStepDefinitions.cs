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
        private readonly LadiesPage _ladiesPage;
        private readonly ItemPage _itemPage;

        public FilterStepDefinitions(SeleniumDriver driver)
        {
            _mainPage = new MainPage(driver.Current, driver.Wait);
            _ladiesPage = new LadiesPage(driver.Current, driver.Wait);
            _itemPage = new ItemPage(driver.Current, driver.Wait);
        }

        [Given(@"The user is on the main page")]
        public void GivenTheUserIsOnTheMainPage()
        {
            _mainPage.OpenWebpage();
        }

        [When(@"the user clicks on 'Womens'")]
        public void WhenTheUserClicksOn()
        {
            _mainPage.GetToLadiesPage();
        }

        [Then(@"the page for ladies is shown")]
        public void ThenThePageForLadiesIsShown()
        {
            _ladiesPage.IsOnLadiesPage();
        }

        [When(@"the user selects leggings")]
        public void WhenTheUsserSelectsLeggings()
        {
            _ladiesPage.SelectItemType();
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

    }
}
