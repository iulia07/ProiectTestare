using FinalProject.PageObjects.BusinessObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace FinalProject.PageObjects
{
    public class ProductPage
    {
        private IWebDriver driver;
        public ProductPage(IWebDriver browser)
        {
            driver = browser;
        }

        private By AddToCart = By.CssSelector("[onclick ^= 'addToCart']");
        private IWebElement BtnAddToCart => driver.FindElement(AddToCart);

        private By productPrice = By.CssSelector("h3.price-container");
        private IWebElement LblProductPrice => driver.FindElement(productPrice);

        //adaugare produs in cos
        public int AddProduct()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(ExpectedConditions.ElementToBeClickable(BtnAddToCart));

            var productPrice = GetProductPrice();
            BtnAddToCart.Click();
           
            return productPrice;

        }
        
       //preluare pret produs si convertire in tip integer
        public int GetProductPrice()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("h3.price-container")));

            string priceText = LblProductPrice.Text.Substring(1,3);
            return int.Parse(priceText);
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
