using FinalProject.PageObjects.BusinessObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Internal;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;


namespace FinalProject.PageObjects
{
    public class LoginPage
    {
        private IWebDriver driver;

        public LoginPage(IWebDriver browser)
        {
            driver = browser;
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            //wait.Until(ExpectedConditions.ElementIsVisible(login));
        }

        private By username = By.Id("loginusername");
        private IWebElement TxtUserName => driver.FindElement(username);

        private By password = By.Id("loginpassword");
        private IWebElement TxtPassword => driver.FindElement(password);

        private By login = By.CssSelector("[onclick='logIn()']");
        private IWebElement BtnLogin => driver.FindElement(login);
      

        //scriere valori pentru login si confirmare
        public HomePage LoginApplication(string username, string password)
        {

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("loginusername")));
            TxtUserName.SendKeys(username);
            TxtPassword.SendKeys(password);
            BtnLogin.Click();
            return new HomePage(driver);

        }
     
        //preluare mesaj alerta
        public string GetAlert()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(ExpectedConditions.AlertIsPresent());
            IAlert alert = driver.SwitchTo().Alert();
            var message = alert.Text;
            alert.Accept();
            return message;
        }




    }
}
