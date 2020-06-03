using System;
using FinalProject.Controls;
using FinalProject.PageObjects;
using FinalProject.PageObjects.BusinessObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using static FinalProject.Controls.MenuItemControl;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace FinalProject
{
    [TestClass]
    public class LoginTests
    {
        private IWebDriver driver;
        private LoginPage loginPage;
        private AlertsType alertsTypes;
        
      

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

        //test pentru login
        [TestMethod]
        public void Login_CorrectUsername_CorrectPassword()
        {
            
            var homePage = loginPage.LoginApplication("automationt9@gmail.com", "automation");
            var expectedResult = "Welcome automationt9@gmail.com";
            var actualResult = homePage.loggedInMenuItemControl.UserName;
            Assert.AreEqual(expectedResult, actualResult);


            
        }
        //test pentru login cu parola incorecta
        [TestMethod]
        public void Login_CorrectUsername_IncorrectPassword()
        {
            var homePage = loginPage.LoginApplication("automationt9@gmail.com", "automationnn");
            var expectedResult = new AlertsType().WrongPasswordAlert;
            //var expectedResult = "Wrong password.";
            var actualResult = loginPage.GetAlert();
            Assert.AreEqual(expectedResult, actualResult);

        }
       

        [TestCleanup]
        public void TestCleanup()
        {
            driver.Quit();
        }
    }
}
