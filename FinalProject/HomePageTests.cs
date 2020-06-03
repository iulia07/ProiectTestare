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
{   [TestClass]
    public class HomePageTests
    {
        private IWebDriver driver;
        private LoginPage loginPage;
        private AboutUsPage aboutUsPage;
        private ContactPage contactPage;

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

    //test pentru vizualizare filmulet
    [TestMethod]
    public void OpenAboutUsPage()
        {
            var homePage = loginPage.LoginApplication("automationt9@gmail.com", "automation");
            
            aboutUsPage = homePage.loggedInMenuItemControl.NavigateToAboutUsPage();
            Assert.IsTrue(aboutUsPage.IsVideoAvailable());
            aboutUsPage.StartVideo();
            Assert.IsTrue(aboutUsPage.IsAboutPageOpened());
        }

    //test pentru trimitere mesaj din pagina de contact
    [TestMethod]
    public void ShouldSendMessageFromContactPage()
        {
            var homePage = loginPage.LoginApplication("automationt9@gmail.com", "automation");
            contactPage = homePage.loggedInMenuItemControl.NavigateToContactPage();
            contactPage.SetMessage(new AddContactElements());
            var expectedResult = new AlertsType().MessageSentSuccessfully;
            var actualResult=contactPage.GetAlert();
            Assert.AreEqual(expectedResult, actualResult);


        }

    [TestCleanup]
    public void TestCleanup()
        {
            driver.Quit();
        }

    }
}
