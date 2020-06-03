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
    public class CartPage
    {
        private WebDriverWait wait;
        private IWebDriver driver;
        public CartPage(IWebDriver browser)
        {
            driver = browser;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(placeOrderLocator));
        }

        private By deleteProduct = By.CssSelector("[onclick^='deleteItem']");
        private IWebElement BtnDeleteProduct => driver.FindElement(deleteProduct);
              

        private By lblTotalPrice = By.Id("totalp");
        private IWebElement TotalPrice => driver.FindElement(lblTotalPrice);

        public By ProductNameInCartLocator(string productName) => By.XPath($"//td[text()='{productName}']");

        private IWebElement LocateElement(By locator) => driver.FindElement(locator);
        private bool IsElementDisplayedImmediately(By locator) => LocateElement(locator).Displayed;

        public bool IsTotalorderVisible() => IsElementDisplayedImmediately(By.Id("totalp"));



        private By placeOrderLocator = By.CssSelector("[class='btn btn-success']");
        private IWebElement BtnPlaceOrder => driver.FindElement(placeOrderLocator);


        //preluare pret si convertire in tip integer
        public int GetTotalPrice => int.Parse(TotalPrice.Text);

        
        //sterge produs
        public void DeleteProduct()
        {
            BtnDeleteProduct.Click();     
        }
   

        private bool IsElementDisplayedAfterWaiting(By locator)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(ExpectedConditions.ElementIsVisible(locator));

            return LocateElement(locator).Displayed;
        }

      
        //verificare daca produsul se afla in cos
        public bool IsProductAddedToCart(string productName)
        {
            var test = IsElementDisplayedAfterWaiting(ProductNameInCartLocator(productName));
            return test;

        }


        //verificare daca produsul este sters din cos
        internal bool IsProductRemovedFromCart(string productName)
        {
            var test = IsElementDisappearedAfterWaiting(ProductNameInCartLocator(productName));
            return test;
        }

        //verificare daca a disparut
        public bool IsElementDisappearedAfterWaiting(By locator)
        {
            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
                wait.Until(ExpectedConditions.InvisibilityOfElementLocated(locator));
                return true;
            }
            catch (Exception)
            {
                throw new Exception("Element is still visible");
            }
        }

        //initiere comanda
        public OrderPage PlaceOrder()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementToBeClickable(BtnPlaceOrder));
            BtnPlaceOrder.Click();
            return new OrderPage(driver);

        }

    }
}
