using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.PageObjects
{
    public class PurchaseAlert
    {
        private IWebDriver driver;
        public PurchaseAlert(IWebDriver browser)
        {
            driver = browser;
        }

        public By PurchaseAlertLocator => By.CssSelector(".sweet-alert");

        public By PurchaseIdLocator => By.CssSelector("p[class^='lead']");

        private By ok = By.CssSelector("[class='confirm btn-lg btn-primary']");
        private IWebElement BtnOk => driver.FindElement(ok);

        //verificare daca alerta de confirmare a comenzii este afisata
        public bool IsPurchaseAlertDisplayed()
        {
            var test = driver.FindElement(By.CssSelector(".sweet-alert")).Enabled;
            return test;
        }

     

      

    }
}
