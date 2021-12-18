using BoDi;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;
using WebshopDemoTests.Drivers;

namespace WebshopDemoTests.Hooks
{
    public class HooksInitialization
    {
        //One time set up and quite
        [BeforeTestRun]
        public static void BeforeTestRun(ObjectContainer testThreadContainer)
        {
            //Initialize a shared BrowserDriver in the global container
            testThreadContainer.BaseContainer.Resolve<SeleniumDriver>();
        }
    }
}
