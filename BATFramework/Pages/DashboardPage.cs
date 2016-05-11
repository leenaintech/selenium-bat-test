using BATFramework;
using OpenQA.Selenium;
using System;

namespace WordPressTests
{
    public class DashboardPage
    {
        public static bool IsAt()
        {
            var h2s = Driver.Instance.FindElements(By.TagName("h2"));
            if (h2s.Count > 0)
                return h2s[0].Text == "Dashboard";
            return false;
        }
    }
}