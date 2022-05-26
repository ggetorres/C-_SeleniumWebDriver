using System;
using System.Configuration;
using System.IO;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using ExpectedConditions = OpenQA.Selenium.Support.UI.ExpectedConditions;

namespace TesteAutomatizadoSelenium
{
    [TestClass]
    public class BuscaGoogleTest
    {

        IWebDriver _driver;
        WebDriverWait _espera;

        [TestInitialize]
        public void Initialize()
        {

            _driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            _espera = new WebDriverWait(_driver, TimeSpan.FromSeconds(1));

            _driver.Manage().Window.Maximize();
            _driver.Navigate().GoToUrl(ConfigurationManager.AppSettings["URLBuscaGoogleTest"]);
        }

        [TestMethod]
        public void BuscarSeleniuWebDriver_PrimeiroResultadoEnderecoSiteSelenium()
        {


            Screenshot TakeScreenshot = ((ITakesScreenshot)_driver).GetScreenshot();
            TakeScreenshot.SaveAsFile("Screenshot.png", ScreenshotImageFormat.Png);

            IWebElement CadastroNome1 = _driver.FindElement(By.XPath("//input[@name='username']"));
            CadastroNome1.SendKeys("angelica.t@gmail.com");

            IWebElement CadastroNome2 = _driver.FindElement(By.XPath("//input[@name='password']"));
            CadastroNome2.SendKeys("Torres");

    
            IWebElement ClickCadastre = _driver.FindElement(By.XPath("//button[@class ='radius btn-login btn-info']"));
            ClickCadastre.Click();


        }



        [TestCleanup]
        public void CleanUp()
        {
            _driver.Close();
            _driver.Quit();
        }
    }
}
