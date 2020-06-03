using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace FinalProject.PageObjects
{
    public class RegisterPage
    {
        private IWebDriver driver;

        public RegisterPage (IWebDriver browser)
        {
            driver = browser;
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
        }

      
        private By userRegister = By.Id("sign-username");
        private IWebElement TxtNewUserName => driver.FindElement(userRegister);

        private By passwordRegister = By.Id("sign-password");
        private IWebElement TxtNewPassword => driver.FindElement(passwordRegister);

        private By signUp = By.CssSelector("[onclick='register()']");
        private IWebElement BtnSignUp => driver.FindElement(signUp);

        //completare campuri din pagina de inregistare 
        public HomePage RegisterApplication(string userRegister, string passwordRegister)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("sign-username")));
            TxtNewUserName.SendKeys(userRegister);
            TxtNewPassword.SendKeys(passwordRegister);
            BtnSignUp.Click();
            return new HomePage(driver);

        }
       
        //preluare mesaj alerta
        public string GetAlertText()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(ExpectedConditions.AlertIsPresent());
            IAlert alert = driver.SwitchTo().Alert();
            var alertMessage = alert.Text;
            alert.Accept();
            return alertMessage;
        }
    }


}
