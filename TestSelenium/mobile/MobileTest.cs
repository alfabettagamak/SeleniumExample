using System;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;

namespace TestSelenium.mobile
{
    public class MobileTest
    {
        // Java
        // Node.js
        // npm
        // > npm install -g appium  # get appium
        // > npm install wd         # get appium client
        // > appium &               # start appium
        // android studio 
        // локальные переменные  JAVA_HOME, ANDROID_SDK_ROOT, ANDROID_HOME

        private string path = @"D:\testing\example.apk";

        [Test]
        public void exampleMobileTesting()
        {
            var options = new AppiumOptions();
            options.App = path;
            options.PlatformName = "Android";
            options.DeviceName = "Pixel 4 API 27";
            //options.BrowserName = "chrome";

            AppiumDriver driver = new AndroidDriver(options);
            var listElements = driver.FindElements(By.XPath("//*"));
            AppiumElement name = null;
            foreach (var element in listElements)
            {
                if (element.Text == "Android UI Demo")
                {
                    name = element;
                }
                Console.WriteLine(element.Text);
                Console.WriteLine(element.Location);
                Console.WriteLine(element);
            }
            Thread.Sleep(5000);
            Console.WriteLine("name " +  name);
            driver.Quit();
            Assert.IsNotNull(name);
        }
    }
}