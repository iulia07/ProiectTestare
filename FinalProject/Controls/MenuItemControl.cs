using FinalProject.PageObjects;
using FinalProject.PageObjects.BusinessObjects;
using Microsoft.Win32;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace FinalProject.Controls
{
    public class MenuItemControl
    {
        public IWebDriver driver;


        public MenuItemControl(IWebDriver browser)
        {
            driver = browser;
            PageFactory.InitElements(this, new RetryingElementLocator(driver, TimeSpan.FromSeconds(20)));
        }

        private By home = By.CssSelector("[class='nav-link']");
        private IWebElement BtnHome => driver.FindElement(home);

    }
    //meniul pentru utilizator care nu este logat
     public class LoggedOutMenuItemControl : MenuItemControl
        {
        public LoggedOutMenuItemControl(IWebDriver browser) : base(browser)
        {

        }

            private By logIn = By.Id("login2");
            private IWebElement BtnLogIn => driver.FindElement(logIn);

            
            private By signUp = By.Id("signin2");
            private IWebElement BtnSignUp => driver.FindElement(signUp);
          
            //navigare in pagina de login
            public LoginPage NavigateToLoginPage()
            {
                //var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                //wait.Until(ExpectedConditions.ElementIsVisible(logIn));
                BtnLogIn.Click();
                return new LoginPage(driver);
            }

            //navigare in pagina de inregistrare
            public RegisterPage NavigateToRegisterPage()
            {
                BtnSignUp.Click();
                return new RegisterPage(driver);
            }

        }

    //definire clasa pentru meniu in cazul utilizatorului logat 

    public class LoggedInMenuItemControl : MenuItemControl
    {
        public LoggedInMenuItemControl(IWebDriver browser) : base(browser)
        {

        }

        private By userName => By.XPath("//*[@id='nameofuser']");
        private IWebElement LblUserName => driver.FindElement(userName);

        public string UserName => $"Welcome automationt9@gmail.com";

        private By home = By.CssSelector("[class='nav-link']");
        private IWebElement BtnHome => driver.FindElement(home);


        private By logOut = By.Id("logout2");
        private IWebElement BtnLogOut => driver.FindElement(logOut);


        private By cart = By.Id("cartur");
        private IWebElement BtnCart => driver.FindElement(cart);


        private By contact = By.LinkText("Contact");
        private IWebElement BtnContact => driver.FindElement(contact);


        private By aboutUs = By.LinkText("About us");
        private IWebElement BtnAboutUs => driver.FindElement(aboutUs);

        //navigare in pagina de contact
        public ContactPage NavigateToContactPage()
        {
            //var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            //wait.Until(ExpectedConditions.ElementToBeClickable(By.LinkText("Contact")));
            Thread.Sleep(1000);
            BtnContact.Click();
            return new ContactPage(driver);
        }

        //navigare in pagina despre noi
        public AboutUsPage NavigateToAboutUsPage()
        {
            //var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            //wait.Until(ExpectedConditions.ElementToBeClickable(By.LinkText("About us")));
            Thread.Sleep(1000);
            BtnAboutUs.Click();
            return new AboutUsPage(driver);
        }

        //navigare in pagina cu cosul de cumparaturi
        public CartPage NavigateToCart()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("cartur")));
            BtnCart.Click();
            return new CartPage(driver);
        }

        //selectare produs si navigare catre pagina produsului
        public ProductPage SelectProductAndNavigateToProductPage(Product product)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("[onclick=\"byCat('phone')\"]")));
            Thread.Sleep(1000);
            SelectCategory(product.ProductCategory);
            Thread.Sleep(1000);
            //driver.FindElement(ProductLocator(product.ProductName)).Click();
            //Click(ProductLocator(product.ProductName));
            ClickOnElementAfterWaiting(ProductLocator(product.ProductName));
            Thread.Sleep(1000);
            return new ProductPage(driver);
        }

        //selectare categorie din meniul vertical
        public void SelectCategory(ProductCategory productCategory)
        {

            switch (productCategory)
            {
                case ProductCategory.Phones:
                     
                     BtnPhones.Click();
                     
                      break;
                    
                case ProductCategory.Laptops:
                    BtnLaptops.Click();
                   
                    break;
                case ProductCategory.Monitors:

                    BtnMonitors.Click();
                   
                    break;

                default:
                    throw new Exception("No such product category");

            }
        }

        public By ProductLocator(string productName) => By.XPath($"//a[text()='{productName}']");
       
        public void ClickOnElementAfterWaiting(By locator) => new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementIsVisible(locator)).Click();
     

        private By phonesCategory = By.CssSelector("[onclick=\"byCat('phone')\"]");
        private IWebElement BtnPhones => driver.FindElement(phonesCategory);


        private By laptopsCategory = By.CssSelector("[onclick=\"byCat('notebook')\"]");
        private IWebElement BtnLaptops => driver.FindElement(laptopsCategory);


        private By monitorsCategory = By.CssSelector("[onclick=\"byCat('monitor')\"]");
        private IWebElement BtnMonitors => driver.FindElement(monitorsCategory);

        //navigare catre pagina acasa
        public void NavigateToHomePage()
        {
            BtnHome.Click();
        }


    }


}      

