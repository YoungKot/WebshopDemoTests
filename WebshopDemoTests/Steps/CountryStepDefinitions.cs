using NUnit.Framework;
using TechTalk.SpecFlow;
using WebshopDemoTests.Drivers;
using WebshopDemoTests.Pages;

namespace WebshopDemoTests.Steps
{
    [Binding]
    public sealed class CountryStepDefinitions
    {

        private readonly MainPage _mainPage;
        private CountryPage _countryPage;

        public CountryStepDefinitions(SeleniumDriver driver)
        {
            _mainPage = new MainPage(driver.Current, driver.Wait);
            _countryPage = new CountryPage(driver.Current, driver.Wait);
        }

        [Given(@"the user is on the main page")]
        public void GivenTheUserIsOnTheMainPage()
        {
            _mainPage.OpenWebpage();
        }

        [When(@"the user checks the current country name")]
        public void WhenTheUserChecksTheCurrentCountryName()
        {
            _countryPage.ScrollDown();
        }

        [Then(@"current country is Latvia")]
        public void ThenCurrentCountryIsLatvia()
        {
            Assert.AreEqual("Latvia", _countryPage.GetCountry());
        }

    }
}
