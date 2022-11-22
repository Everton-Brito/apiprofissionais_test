using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SistemaProfissionais.Tests
{
    public class Profissional
    {
        [Fact]
        public void LoginUsuarioComSucesso()
        {
            var driver = new ChromeDriver();
            driver.Manage().Window.Maximize();

            driver.Navigate().GoToUrl("http://localhost:4200/login");         

            var email = driver.FindElement(By.XPath("/html/body/div/div/div/app-root/div/div/app-login/div/form/div[1]/input"));
            email.Clear();
            email.SendKeys("Conta@Teste.com");

            var senha = driver.FindElement(By.XPath("/html/body/div/div/div/app-root/div/div/app-login/div/form/div[2]/input"));
            senha.Clear();
            senha.SendKeys("@admin123");  

            var botao = driver.FindElement(By.XPath("/html/body/div/div/div/app-root/div/div/app-login/div/form/div[3]/input"));
            botao.Click();


            //Cadastro Profissional
            driver.Navigate().GoToUrl("http://localhost:4200/cadastro-profissional");           


            var nome = driver.FindElement(By.XPath("/html/body/div/div/div/app-root/div/div/app-cadastro-profissional/div/form/div[1]/div/input"));
            nome.Clear();
            nome.SendKeys("Profissional Teste");

            var email2 = driver.FindElement(By.XPath("/html/body/div/div/div/app-root/div/div/app-cadastro-profissional/div/form/div[2]/div/input"));
            email2.Clear();
            email2.SendKeys("Conta2@Teste.com");

            var cpf = driver.FindElement(By.XPath("/html/body/div/div/div/app-root/div/div/app-cadastro-profissional/div/form/div[3]/div[1]/input"));
            cpf.Clear();
            cpf.SendKeys("12332145685");

            var telefone = driver.FindElement(By.XPath("/html/body/div/div/div/app-root/div/div/app-cadastro-profissional/div/form/div[3]/div[2]/input"));
            telefone.Clear();
            telefone.SendKeys("31985588447");

            var botao2 = driver.FindElement(By.XPath("/html/body/div/div/div/app-root/div/div/app-cadastro-profissional/div/form/div[4]/div/input"));
            botao2.Click();

        }

        
    }
}