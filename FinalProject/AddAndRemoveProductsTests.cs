using FinalProject.Controls;
using FinalProject.PageObjects;
using FinalProject.PageObjects.BusinessObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    [TestClass]
    public class AddAndRemoveProductsTests
    {
        private IWebDriver driver;
        private CartPage cartPage;
        private Product product;
        private ProductPage productPage;
        private LoginPage loginPage;
        private AlertsType alertsType;
        private OrderPage orderPage;
        private AddOrderElements addOrderElements;
        private PurchaseAlert purchaseAlert;
       

        private Product NewMonitor = new Product(ProductCategory.Monitors, "ASUS Full HD");
        private Product NewPhone = new Product(ProductCategory.Phones, "Samsung galaxy s6");
        private Product NewNotebook = new Product(ProductCategory.Laptops, "Sony vaio i5");
        
        public int TotalAmount { get; set; } = 0;


        [TestInitialize]
        public void TestInitialize()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://demoblaze.com/");
            var menuItem = new LoggedOutMenuItemControl(driver);
            loginPage = menuItem.NavigateToLoginPage();
            loginPage = new LoginPage(driver);
            
         
        }
        //generare lista de produse pentru adaugare in cos
        private List<Product> GenerateProductList(params Product[] products)
        {
            List<Product> productList = new List<Product>();
            foreach (var product in products)
            {
                productList.Add(product);
            }
            return productList;
        }

        //test pentru adaugare produs/e in cos
        [TestMethod]
        public void Should_Add_Products_To_Cart_Successfully()
        {     
            var homePage = loginPage.LoginApplication("automationt9@gmail.com", "automation");
            
                var productList = GenerateProductList(NewNotebook, NewPhone);
            

                foreach (var product in productList)
                {
                    productPage = homePage.loggedInMenuItemControl.SelectProductAndNavigateToProductPage(product);
                    TotalAmount +=productPage.AddProduct();
                    var expectedResult = new AlertsType().ProductAddedSuccessfully;
                
                    var actualResult = productPage.GetAlert();
                    Assert.AreEqual(expectedResult, actualResult);

                    cartPage = homePage.loggedInMenuItemControl.NavigateToCart();
                    Assert.IsTrue(cartPage.IsProductAddedToCart(product.ProductName));
                    //verificare daca suma totala corespunde
                    Assert.AreEqual(TotalAmount, cartPage.GetTotalPrice);

                    homePage.loggedInMenuItemControl.NavigateToHomePage();
               }
        
        }

        //test pentru stergere produs
        [TestMethod]
        public void Should_Delete_Product()
        {
            int TotalAmount = 0;
            var homePage = loginPage.LoginApplication("automationt9@gmail.com", "automation");
            productPage = homePage.loggedInMenuItemControl.SelectProductAndNavigateToProductPage(NewMonitor);
            TotalAmount = productPage.AddProduct();
            var expectedResult = new AlertsType().ProductAddedSuccessfully;
            var actualResult = productPage.GetAlert();
            Assert.AreEqual(expectedResult, actualResult);
           

            cartPage = homePage.loggedInMenuItemControl.NavigateToCart();
            Assert.IsTrue(cartPage.IsProductAddedToCart(NewNotebook.ProductName));

            cartPage.DeleteProduct();
            Assert.IsTrue(cartPage.IsProductRemovedFromCart(NewNotebook.ProductName));
            Assert.IsFalse(cartPage.IsTotalorderVisible());

        }

        //test pentru adaugare produs in cos si initiere comanda
        [TestMethod]
        public void Should_Add_Product_And_Get_Order_Page()
        {
            var homePage = loginPage.LoginApplication("automationt9@gmail.com", "automation");
            productPage = homePage.loggedInMenuItemControl.SelectProductAndNavigateToProductPage(NewPhone);
            TotalAmount = productPage.AddProduct();
            var expectedResult = new AlertsType().ProductAddedSuccessfully;
            var actualResult = productPage.GetAlert();
            Assert.AreEqual(expectedResult, actualResult);

            cartPage = homePage.loggedInMenuItemControl.NavigateToCart();
            Assert.IsTrue(cartPage.IsProductAddedToCart(NewPhone.ProductName));
            
            orderPage = cartPage.PlaceOrder();
            Assert.IsTrue(orderPage.IsWindowOpened());

          
        }

        //test pentru adaugare produs in cos si plasare comanda
        [TestMethod]
        public void Should_Add_Produc_And_Submit_OrderPage()
        {
            var homePage = loginPage.LoginApplication("automationt9@gmail.com", "automation");        
            productPage = homePage.loggedInMenuItemControl.SelectProductAndNavigateToProductPage(NewPhone);
            TotalAmount = productPage.AddProduct();
            var expectedResult = new AlertsType().ProductAddedSuccessfully;
            var actualResult = productPage.GetAlert();
            Assert.AreEqual(expectedResult, actualResult);

            cartPage = homePage.loggedInMenuItemControl.NavigateToCart();
            Assert.IsTrue(cartPage.IsProductAddedToCart(NewPhone.ProductName));

            orderPage = cartPage.PlaceOrder();
            purchaseAlert = orderPage.SetOrder(new AddOrderElements());
            Assert.IsTrue(purchaseAlert.IsPurchaseAlertDisplayed());

        }
        
        //test pentru incercare de plasare a comenzii fara completare campuri
        [TestMethod]
        public void DidNotFillRequiredFieldOfOrderPage()
        {
            var homePage = loginPage.LoginApplication("automationt9@gmail.com", "automation");
            productPage = homePage.loggedInMenuItemControl.SelectProductAndNavigateToProductPage(NewPhone);
            TotalAmount = productPage.AddProduct();
            var expectedResult = "Product added.";
            var actualResult = productPage.GetAlert();
            Assert.AreEqual(expectedResult, actualResult);
            
            cartPage = homePage.loggedInMenuItemControl.NavigateToCart();
            Assert.AreEqual(expectedResult, actualResult);

            orderPage = cartPage.PlaceOrder();
            orderPage.submitOrderPage();
            var expectedResult2 = new AlertsType().EnterRequiredFields;
            var actualResult2 = orderPage.GetAlert();
            Assert.AreEqual(expectedResult2, actualResult2);

        }


        [TestCleanup]
        public void TestCleanup()
        {
            driver.Quit();
        }

        
    }
 }

