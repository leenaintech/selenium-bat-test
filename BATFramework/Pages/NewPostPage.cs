using BATFramework;
using OpenQA.Selenium;
using System;
using System.Threading;

namespace WordPressTests
{
    public class NewPostPage
    {
        public static void GoTo()
        {
            LeftNavigation.Posts.AddNew.Select();
            
        }

       public static CreatePostCommand CreatePost(string title)
        {
            return new CreatePostCommand(title);
        }

        public class CreatePostCommand
        {
            private string body;
            private string title;

            public CreatePostCommand(string title)
            {
                this.title = title;
            }

            public CreatePostCommand WithBody(string v)
            {
                this.body = v;
                return this;
            }

            public void Publish()
            {
                Driver.Instance.FindElement(By.Id("title")).SendKeys(title);

                Driver.Instance.SwitchTo().Frame("content_ifr");
                Driver.Instance.SwitchTo().ActiveElement().SendKeys(body);
                Driver.Instance.SwitchTo().DefaultContent();

                Driver.Wait(TimeSpan.FromSeconds(1));

                Thread.Sleep(1000);

                Driver.Instance.FindElement(By.Id("publish")).Click();
            }
        }

        public static void GoToNewPost()
        {
            Driver.Instance.FindElement(By.Id("message")).FindElements(By.TagName("a"))[0].Click();

        }
    }
}