using BATFramework;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WordPressTests
{
    public class WordPressTest
    {
        [TestInitialize]
        public void Init()
        {
            Driver.Initialize();
            LoginPage.Goto();
            LoginPage.LoginAs("leenab").WithPassword("tommy12!WP1509").Login();
        }


        [TestCleanup]
        public void Cleanup()
        {
            Driver.Close();
        }
    }
}