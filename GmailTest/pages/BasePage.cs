using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using System;
using System.Threading;
using GmailTest.pages;
namespace GmailTest.pages
{
    internal class BasePage
    {
        protected IWebDriver _webdriver;
        private readonly By loginTextField = By.XPath("//input[@id='identifierId']");
        private readonly By nextButton = By.XPath("//span[contains(text(),'Далее')]");
        private readonly By paswrdField = By.XPath("//input[@name='password']");
      
        public BasePage(IWebDriver webdriver)
        {
            _webdriver = webdriver;
        }
        public BasePage FillInUsername(string username)
        {
            _webdriver.FindElement(loginTextField).SendKeys(username);
            _webdriver.FindElement(nextButton).Click();
            return new BasePage(_webdriver);
        }
        public BasePage FillInPassword (string password)
        {
            _webdriver.FindElement(paswrdField).SendKeys(password);
            _webdriver.FindElement(nextButton).Click();
            return new BasePage(_webdriver);
        }
    }
}