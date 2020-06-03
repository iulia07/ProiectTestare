using FinalProject.PageObjects.BusinessObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.PageObjects
{
    public class ContactPage
    {
        IWebDriver driver;
        public ContactPage(IWebDriver browser)
        {
            driver = browser;
        }

        private By contactEmail = By.Id("recipient-email");
        private IWebElement TxtContactEmail => driver.FindElement(contactEmail);

        private By contactName = By.Id("recipient-name");
        private IWebElement TxtContactName => driver.FindElement(contactName);

        private By message = By.Id("message-text");
        private IWebElement TxtMessage => driver.FindElement(message);

        private By send = By.CssSelector("[onclick='send()']");
        private IWebElement BtnSend => driver.FindElement(send);

        //scriere mesaj si trimitere
        public void SetMessage(AddContactElements addContactElements)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("recipient-email")));
            TxtContactEmail.SendKeys(addContactElements.Email);
            TxtContactName.SendKeys(addContactElements.Name);
            TxtMessage.SendKeys(addContactElements.Message);
            BtnSend.Click();
        }

        //preluare mesajul alertei dupa apasarea butonului de trimitere
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
