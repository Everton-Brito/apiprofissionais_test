using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SistemaProfissionais.Tests
{
    public class UsuarioCadastroTest
    {
        [Fact]
        public void CadastrarUsuarioComSucesso()
        {
            var driver = new ChromeDriver();
            driver.Manage().Window.Maximize();

            driver.Navigate().GoToUrl("http://localhost:4200/usuarios");

            var nome = driver.FindElement(By.XPath("/html/body/div/div/div/app-root/div/div/app-usuarios/div/form/div[1]/input"));
            nome.Clear();
            nome.SendKeys("Conta Teste");

            var email = driver.FindElement(By.XPath("/html/body/div/div/div/app-root/div/div/app-usuarios/div/form/div[2]/input"));
            email.Clear();
            email.SendKeys("Conta@Teste.com");

            var senha = driver.FindElement(By.XPath("/html/body/div/div/div/app-root/div/div/app-usuarios/div/form/div[3]/input"));
            senha.Clear();
            senha.SendKeys("@admin123");

            var senhaConfirmacao = driver.FindElement(By.XPath("/html/body/div/div/div/app-root/div/div/app-usuarios/div/form/div[4]/input"));
            senhaConfirmacao.Clear();
            senhaConfirmacao.SendKeys("@admin123");

            var botao = driver.FindElement(By.XPath("/html/body/div/div/div/app-root/div/div/app-usuarios/div/form/div[5]/input"));
            botao.Click();

            
        }
    }
}