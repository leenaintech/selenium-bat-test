using BATFramework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.ObjectModel;

namespace WordPressTests
{
    public class ListPostsPage
    {
        private static int lastCount;

        public static int PreviousPostCount {
            get
            {
                return lastCount;
            }
        }

        public static object CurrentPostCount { get
            {
                return GetPostCount();
            }
        }

        public static void GoTo(PostType posts)
        {
            switch (posts)
            {
                case PostType.Page:
                    LeftNavigation.Pages.AllPages.Select();
                    break;
                case PostType.Posts:
                    LeftNavigation.Posts.AllPosts.Select();
                    break;
            }
        }    

        public enum PostType
        {
            Page,
            Posts
        };

        public static void StoreCount()
        {
            lastCount = GetPostCount();
        }

        private static int GetPostCount()
        {
            var countText = Driver.Instance.FindElement(By.ClassName("displaying-num")).Text;
            return int.Parse(countText.Split(' ')[0]);
        }

        public static void TrashPost(string title)
        {
            var rows = Driver.Instance.FindElements(By.TagName("tr"));

            foreach(var row in rows)
            {
                ReadOnlyCollection<IWebElement> links = null;
                links = row.FindElements(By.LinkText(title));

                if(links.Count > 0)
                {
                    Actions action = new Actions(Driver.Instance);
                    action.MoveToElement(links[0]);
                    action.Perform();
                    row.FindElement(By.ClassName("submitdelete")).Click();
                    return;
                }

            }

            
            
        }

        public static void SearchForPost(string title)
        {
            Driver.Instance.FindElement(By.Id("post-search-input")).SendKeys(title);
            Driver.Instance.FindElement(By.Id("search-submit")).Submit();
        }

        public static bool DoesPostExistWithTitle(string title)
        {
            var element = Driver.Instance.FindElements(By.LinkText(title));
            return (element != null);
        }
    }
}