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
    internal class HomePage
    {
        protected IWebDriver _webdriver;
        private readonly By writeButton = By.XPath("//div[@class='T-I T-I-KE L3']");
        private readonly By recieverField = By.XPath("//input[@id=':da']");
        private readonly By articleField = By.XPath("//input[@id=':5q']");
        private readonly By messageField = By.XPath("//div[@id=':4k']");
        private readonly By sendButton = By.XPath("//div[@id=':60']");
        public HomePage(IWebDriver webdriver)
        {
            _webdriver = webdriver;
        }
        public HomePage ClickWriteButton()
        {
            _webdriver.FindElement(writeButton).Click();
            return this;
        }
        public HomePage FillInEmailFields(string reciever, string article, string message)
        {
            _webdriver.FindElement(recieverField).SendKeys(reciever);
            Thread.Sleep(500);
            _webdriver.FindElement(articleField).SendKeys(article);
            Thread.Sleep(500);
            _webdriver.FindElement(messageField).SendKeys(message);
            Thread.Sleep(500);
            return new HomePage(_webdriver);
        }
        public HomePage SendTheEmail()
        {
            _webdriver.FindElement(sendButton).Click();
            return this;
        }
    }
}
