using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BATFramework;

namespace WordPressTests
{
    [TestClass]
    public class LoginTest: WordPressTest
    {

        [TestMethod]
        public void Admin_User_Can_Login()
        {
            Assert.IsTrue(DashboardPage.IsAt(), "Failed to Login");
        }

        [TestMethod]
        public void Multiple_User_Ids(string userName, string password)
        {
            LoginPage.LoginAs(userName).WithPassword(password).Login();
        }
    }
}
