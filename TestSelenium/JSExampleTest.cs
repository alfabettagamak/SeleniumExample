using System;
using System.Threading;
using Allure.Commons;
using NUnit.Allure.Attributes;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using TestSelenium.patterns;

namespace TestSelenium
{
    public class JSExampleTest
    {
        private WebDriver driver;
        private WebDriverWait wait;
        private StartPage _startPage;
        
        [OneTimeSetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
        }

        [SetUp]
        public void BeforeTest()
        {
            if (driver.FindElements(By.XPath("//a[@class='btnExit']")).Count > 0)
            {
                driver.FindElement(By.XPath("//a[@class='btnExit']")).Click();
            }
            _startPage = new StartPage(driver).Open();
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            driver.Quit();
        }
        
     
        [Test]
        public void LoginTesting()
        {
            var loginPage = _startPage.GetLoginPage();
            loginPage.Login("alisa.skrynko@gmail.com", "c069db");

            IJavaScriptExecutor js = driver;
            //js.ExecuteScript("document.body.innerHTML = '<h1>HELLO FROM C#</h1>'");
            //string str = "OLOLO";
            //js.ExecuteScript("document.body.innerHTML='<h1>' +arguments[0]+ arguments[1]+ '</h1>'",str, 47);

            var element = driver.FindElement(By.XPath("//div[@class='selectOption']"));
            js.ExecuteScript("arguments[0].textContent = 'OLOLOLOLO'", element);
            Thread.Sleep(10000);
           
        }
    }
}