using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BATFramework
{
    public class LoginPage
    {
        public static void Goto()
        {
            Driver.Instance.Navigate().GoToUrl("http://localhost:41344/wp-login.php");
        }

        public static LoginCommand LoginAs(string v)
        {
            return new LoginCommand(v);
        }

        public class LoginCommand
        {
            private string password;
            private readonly string userName;

            public LoginCommand(string userName)
            {
                this.userName = userName;
            }

            public void Login()
            {
                var loginInput = Driver.Instance.FindElement(By.Id("user_login"));
                loginInput.SendKeys(userName);

                var loginPassword = Driver.Instance.FindElement(By.Id("user_pass"));
                loginPassword.SendKeys(password);

                var loginButton  = Driver.Instance.FindElement(By.Id("wp-submit"));
                loginButton.Submit();
            }

            public LoginCommand WithPassword(string v)
            {
                this.password = v;
                return this;
            }
        }
    }
}
