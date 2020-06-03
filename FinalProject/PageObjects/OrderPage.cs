using FinalProject.PageObjects.BusinessObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace FinalProject.PageObjects
{
    public class OrderPage
    {
        private IWebDriver driver;
       
        public OrderPage(IWebDriver browser)
        {
            driver = browser;
            
        }
        
        private By name = By.Id("name");
        private IWebElement TxtName => driver.FindElement(name);
        
        private By country = By.Id("country");
        private IWebElement TxtCountry => driver.FindElement(country);

        private By city = By.Id("city");
        private IWebElement TxtCity => driver.FindElement(city);

        private By creditCard = By.Id("card");
        private IWebElement TxtCreditCard => driver.FindElement(creditCard);

        private By month = By.Id("month");
        private IWebElement TxtMonth => driver.FindElement(month);

        private By year = By.Id("year");
        private IWebElement TxtYear => driver.FindElement(year);
        
        private By totalAmount = By.Id("totalm");
        private IWebElement LblTotalAmount => driver.FindElement(totalAmount);

        private By purchaseOrder = By.CssSelector("[onclick='purchaseOrder()']");
        private IWebElement BtnPurchaseOrder => driver.FindElement(purchaseOrder);

        private By cancelOrder = By.CssSelector("[data-dismiss='modal']");
        private IWebElement BtnCancelOrder => driver.FindElement(cancelOrder);
     
        //completare campuri din formularul de comanda si trimitere
        public PurchaseAlert SetOrder(AddOrderElements addOrderElements)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("[onclick='purchaseOrder()']")));
            wait.Until(ExpectedConditions.ElementIsVisible(totalAmount));        
            TxtName.SendKeys(addOrderElements.Name);
            TxtCity.SendKeys(addOrderElements.City);
            TxtCountry.SendKeys(addOrderElements.Country);
            TxtCreditCard.SendKeys(addOrderElements.CreditCard);
            TxtMonth.SendKeys(addOrderElements.Month);
            TxtYear.SendKeys(addOrderElements.Year);
            BtnPurchaseOrder.Click();
            return new PurchaseAlert(driver);
          

        }

        //verificare daca formularul de comanda este deschis
        public bool IsWindowOpened()
        {
            var test = driver.FindElement(By.Id("orderModal")).Enabled;   
            return test;
        }

        //prealuare mesaj alerta
        public string GetAlert()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(ExpectedConditions.AlertIsPresent());
            IAlert alert = driver.SwitchTo().Alert();
            var message = alert.Text;
            alert.Accept();
            return message;
        }

        public void submitOrderPage()
        {
            //WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            //wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("[onclick='purchaseOrder()']")));
            Thread.Sleep(2000);
            BtnPurchaseOrder.Click();
            
        }




       



        
        
        

       

        
    }   
}
