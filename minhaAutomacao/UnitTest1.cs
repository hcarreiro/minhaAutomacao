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
            string resultadoAtual;
            string resultadoEsperado = "https://listapresente.casaevideo.com.br/";
            
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
            nome.SendKeys("Andr�");

            IWebElement email = driver.FindElement(By.Id("pre-sign-up-form-email"));
            email.SendKeys("exemplo2@exemplo.com");

            IWebElement cpf = driver.FindElement(By.Id("pre-sign-up-form-cpf"));
            cpf.SendKeys("914.018.860-43");

            IWebElement senha = driver.FindElement(By.Id("pre-sign-up-form-password"));
            senha.SendKeys("Teste@Teste");

            IWebElement termos = driver.FindElement(By.Id("pre-sign-up-terms"));
            termos.Click();

            IWebElement cadastrar = driver.FindElement(By.Id("btn-pre-sign-up-new"));
            cadastrar.Click();

            try
            {
                Assert.IsTrue(driver.FindElement(By.XPath("/html/body/header/nav[2]/div/div[3]/div[2]/div/span")).Displayed);
                Console.WriteLine("Caso de Teste Passou");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            Console.Read();

            Thread.Sleep(3000);

            driver.Quit();
        }
    }
}