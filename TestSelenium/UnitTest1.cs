using System;
using NUnit.Allure.Core;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace TestSelenium
{

    [TestFixture]
    [AllureNUnit]
    public class Tests
    {
        private WebDriver driver;
        private WebDriverWait wait;
        private string login, passwod;
        private bool isAuth = false;
        
        const string Url = "https://old.kzn.opencity.pro/";
        
        [OneTimeSetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            (login, passwod) = Utils.ClientRegistration(driver, wait);
        }

       [OneTimeTearDown]
        public void TearDown()
        {
            driver.Quit();
        }

        [Test]
        public void CheckAuthTesting()
        {
            Authorization(Url);
            Assert.AreEqual("https://old.kzn.opencity.pro/cabinet/", driver.Url, "Не перешли в личный кабинет");
            isAuth = true;
        }
        
        [Test]
        public void CheckMyProfileTesting()
        {
            if (!isAuth) Authorization(Url);
            driver.FindElement(By.CssSelector("a[class='btn_edit_profile itemMenu']")).Click();
            Assert.AreEqual("https://old.kzn.opencity.pro/cabinet/myprofile", driver.Url, "Не открылась страница редактирования профиля");
        }

        private void Authorization(string url)
        {
            driver.Navigate().GoToUrl(url);
            driver.Manage().Window.Maximize();
            var auth = driver.FindElement(By.XPath("//a[@data-ui='auth']"));
            auth.Click();
            IWebElement inputEmail = wait.Until(e => e.FindElement(By.Name("username")));
            inputEmail.SendKeys(login);
            driver.FindElement(By.Name("password")).SendKeys(passwod);
            driver.FindElement(By.CssSelector("button.inputSubmit")).Click();
        }


    }
}