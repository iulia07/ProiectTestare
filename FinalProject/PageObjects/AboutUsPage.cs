using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;



namespace FinalProject.PageObjects
{
    public class AboutUsPage
    {
        IWebDriver driver;
        public AboutUsPage (IWebDriver browser)
        {
            driver = browser;
        }       

        //locatori pentru elementele din pagina
        public By VideoLocator => By.Id("example-video");

        private By startVideo = By.CssSelector("[class='vjs-big-play-button']");
        private IWebElement BtnStartVideo => driver.FindElement(startVideo);

        private By closeVideo = By.ClassName("close");
        private IWebElement BtnCloseVideo => driver.FindElement(closeVideo);

        //verificare daca video-ul este deschis
        public bool IsVideoAvailable()
        {
            var test = driver.FindElement(VideoLocator).Enabled;
            return test;
        }

        //pornire video
        public void StartVideo()
        {   var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(By.LinkText("About us")));
            
            BtnStartVideo.Click();
        }

        //verificare daca pagina este deschisa
        public bool IsAboutPageOpened()
        {
            var test = driver.FindElement(By.Id("videoModal")).Enabled;
            return test;
        }

    }
}
