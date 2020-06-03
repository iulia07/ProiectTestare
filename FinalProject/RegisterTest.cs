using FinalProject.Controls;
using FinalProject.PageObjects;
using FinalProject.PageObjects.BusinessObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    [TestClass]
    public class RegisterTest
    {
        private IWebDriver driver;
        private RegisterPage registerPage;
        private AlertsType alertsType;

        [TestInitialize]
        public void TestInitialize()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://demoblaze.com/");
            var menuItem = new LoggedOutMenuItemControl(driver);
            registerPage = menuItem.NavigateToRegisterPage();
            registerPage = new RegisterPage(driver);

        }
        //test pentru inregistrare
        [TestMethod]
        public void Register()
        {
            var homePage = registerPage.RegisterApplication("automattion122345677788999", "automation8888");
            var expectedResult = new AlertsType().SignUpSuccessfullAlert;
            //var expectedResult = "Sign up successful.";
            var actualResult = registerPage.GetAlertText();
            Assert.AreEqual(expectedResult, actualResult);
        }
      
        //test pentru inregistrare cu username existent
        [TestMethod]
        public void RegisterWithUserAlreadyInDatabase()
        {
            var homePage = registerPage.RegisterApplication("automation8888", "automation8888");
            var expectedResult = new AlertsType().UserAlreadyExistsAlert;
            //var expectedResult = "This user already exist.";
            var actualResult = registerPage.GetAlertText();
            Assert.AreEqual(expectedResult, actualResult);

        }

        [TestCleanup]
        public void TestCleanup()
        {
            driver.Quit();
        }

    }
}
