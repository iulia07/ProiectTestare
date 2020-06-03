using FinalProject.Controls;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static FinalProject.Controls.MenuItemControl;

namespace FinalProject.PageObjects
{
    public class HomePage
    {
        private static IWebDriver driver;
        public HomePage (IWebDriver browser)
        {
            driver = browser;
            PageFactory.InitElements(this, new RetryingElementLocator(driver, TimeSpan.FromSeconds(20)));
        }


        public LoggedInMenuItemControl loggedInMenuItemControl => new LoggedInMenuItemControl(driver);

       

        

    }
}
