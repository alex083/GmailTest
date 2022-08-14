using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using System.Threading;
using System;
using GmailTest.pages;
[assembly: Parallelizable(ParallelScope.Fixtures)]

namespace GmailTest
{
    [TestFixture("Chrome", "104.0", "Windows 10", "Chrome104")]
    public class Tests
    {
        private IWebDriver _webdriver;
        private string hubUrl;
        private string _browser;
        private string _version;
        private string _os;
        private string _name;
        public Tests(string browser, string version, string os, string name)
        {
            _browser = browser;
            _version = version;
            _os = os;
            _name = name;
        }
        [SetUp]
        public void Setup()
        {
            dynamic capability = GetBrowserOptions(_browser);
            hubUrl = "http://localhost:4444/wd/hub";
            _webdriver = new RemoteWebDriver(new Uri(hubUrl), capability);
            _webdriver.Manage().Window.Maximize();
        }
        
        [Test]
        [Parallelizable]
        public void SendMessage()
        {
            _webdriver.Navigate().GoToUrl("https://accounts.google.com/");
            Thread.Sleep(1000);
            var basePage = new BasePage(_webdriver);
            basePage.FillInUsername("test6625654@gmail.com");
            Thread.Sleep(1000);
            basePage.FillInPassword("S@msung2015");
            Thread.Sleep(1000);
            _webdriver.Navigate().GoToUrl("https://mail.google.com/");
            var homePage = new HomePage(_webdriver);
            homePage.ClickWriteButton();
            Thread.Sleep(500);
            homePage.FillInEmailFields("alex083266@gmail.com", "Test Mail", "Hello World!");
            Thread.Sleep(250);
            homePage.SendTheEmail(); ;

        }
        [TearDown]
        public void TearDown()
        {
            _webdriver.Quit();
        }
        private dynamic GetBrowserOptions(string browserName)
        {
            switch (browserName)
            {
                case "Chrome":
                    return new ChromeOptions();
                case "MicrosoftEdge":
                    return new EdgeOptions();
                case "FireFox":
                    return new FirefoxOptions();
                default:
                    return new ChromeOptions();
            }
        }
    }
}