using BATFramework;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordPressTests
{
    [TestClass]
    public class CreateNewPostTest: WordPressTest
    {
        [TestMethod]
        public void Can_Create_Basic_Post()
        {
            NewPostPage.GoTo();
            NewPostPage.CreatePost("This is the test post title")
                .WithBody("hi, this is the body").Publish();

            NewPostPage.GoToNewPost();

            Assert.AreEqual(PostPage.Title, "This is the test post title", "No Match");

        }
    }
}
