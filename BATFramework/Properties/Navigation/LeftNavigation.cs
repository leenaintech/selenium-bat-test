using BATFramework;
using OpenQA.Selenium;
using System;

namespace WordPressTests
{
    public class LeftNavigation
    {
        public class Posts
        {
            public class AllPosts
            {
                public static void Select()
                {
                    MenuSelector.Select("menu-posts", "All Posts");
                }
            }

            public class AddNew
            {
                public static void Select()
                {
                    MenuSelector.Select("menu-posts", "Add New");
                  
                }
            }
        }

        public class Pages
        {
            public class AllPages
            {
                public static void Select()
                {
                    MenuSelector.Select("menu-pages", "All Pages");
                }
            }

            public class AddNew
            {
                public static void Select()
                {
                    MenuSelector.Select("menu-pages", "Add New");
                }
            }
        }
        
    }

    internal class MenuSelector
    {
        internal static void Select(string topLevelMenuId, string subMenuLinkText)
        {
            Driver.Instance.FindElement(By.Id(topLevelMenuId)).Click();

            Driver.Instance.FindElement(By.LinkText(subMenuLinkText)).Click();
        }
    }
}