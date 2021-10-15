using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;
using System.Reflection;
using System.Threading;

namespace minhaAutomacao
{
    [TestClass]
    public class ST001_CadastroDoCliente
    {
        public static string chromeWebDriver = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

        // URL da p�gina a ser testada
        public static string linkSiteProjeto = "http://www.casaevideo.com.br/";

        [TestMethod]
        public void CT001_EfetuarLoginComSucesso()
        {
            IWebDriver driver = new ChromeDriver(chromeWebDriver);

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

            driver.Manage().Window.Maximize();

            driver.Navigate().GoToUrl(linkSiteProjeto);

            IWebElement entreOuCadastre = driver.FindElement(By.ClassName("subtitle-login"));
            entreOuCadastre.Click();

            IWebElement acessarMinhaLista = driver.FindElement(By.XPath("/html/body/div[3]/header/div[2]/div/div/div[6]/div[1]/div/ul/li[3]/a/u"));
            acessarMinhaLista.Click();

            IWebElement inserirEmail = driver.FindElement(By.Id("header-sign-up-link"));
            inserirEmail.Click();

            IWebElement nome = driver.FindElement(By.Id("pre-sign-up-form-first-name"));
            nome.SendKeys("� o pai");

            IWebElement email = driver.FindElement(By.Id("pre-sign-up-form-email"));
            email.SendKeys("exemplo@exemplo.com");

            IWebElement cpf = driver.FindElement(By.Id("pre-sign-up-form-cpf"));
            cpf.SendKeys("12345678900");

            IWebElement senha = driver.FindElement(By.Id("pre-sign-up-form-password"));
            senha.SendKeys("Teste@Teste");

            IWebElement termos = driver.FindElement(By.Id("pre-sign-up-terms"));
            termos.Click();

            Thread.Sleep(3000);

            driver.Quit();
        }
    }
}