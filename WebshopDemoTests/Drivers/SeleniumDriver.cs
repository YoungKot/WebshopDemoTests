using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebshopDemoTests.Drivers
{
    public class SeleniumDriver : IDisposable
    {
        private readonly Lazy<IWebDriver> _currentWebDriverLazy;
        private bool _isDisposed;
        private readonly WebDriverWait _wait;
        public const int DefaultWaitInSeconds = 30;

        public SeleniumDriver()
        {
            _currentWebDriverLazy = new Lazy<IWebDriver>(CreateWebDriver);
            _wait = new WebDriverWait(_currentWebDriverLazy.Value, TimeSpan.FromSeconds(DefaultWaitInSeconds));
        }

        public IWebDriver Current => _currentWebDriverLazy.Value;
        public WebDriverWait Wait => _wait;

        public IWebDriver CreateWebDriver()
        {
            var chromeDriverService = ChromeDriverService.CreateDefaultService();

            var chromeOptions = new ChromeOptions();

            var driver = new ChromeDriver(chromeDriverService, chromeOptions);

            driver.Manage().Window.Maximize();

            return driver;

        }


        public void Dispose()
        {
            if (_isDisposed)
            {
                return;
            }

            if (_currentWebDriverLazy.IsValueCreated)
            {
                Current.Quit();
            }

            _isDisposed = true;
        }
    }
}
