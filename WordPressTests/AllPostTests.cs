using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordPressTests
{
    [TestClass]
   public class AllPostTests:WordPressTest
    {
        [TestMethod]
        public void Added_Posts_Show_Up()
        {
            // Go to posts, get the post count. 
            ListPostsPage.GoTo(ListPostsPage.PostType.Posts);
            ListPostsPage.StoreCount();
            
            // Add a new post
            NewPostPage.GoTo();
            NewPostPage.CreatePost("Added post show up is title").WithBody("this is the body text").Publish();

            // Go to posts, get the new post count
            ListPostsPage.GoTo(ListPostsPage.PostType.Posts);
            Assert.AreEqual(ListPostsPage.PreviousPostCount + 1, ListPostsPage.CurrentPostCount, "The count is not equal");
            ListPostsPage.StoreCount();

            Assert.IsTrue(ListPostsPage.DoesPostExistWithTitle("Added post show up is title"));

            //Thrash post and Clean up
            ListPostsPage.TrashPost("Added post show up is title");
            // Assert.AreEqual(ListPostsPage.CurrentPostCount, ListPostsPage.PreviousPostCount, "Could not delete");
        }

        [TestMethod]
        public void Can_Search_Posts()
        {
            // Create a new post
            NewPostPage.GoTo();
            NewPostPage.CreatePost("This is a post for Search").WithBody("this is the body text").Publish();

            // Go to List of posts
            ListPostsPage.GoTo(ListPostsPage.PostType.Posts);

            // Search for post
            ListPostsPage.SearchForPost("This is a post for Search");

            // Check that posts show up in the results. 
            Assert.IsTrue(ListPostsPage.DoesPostExistWithTitle("This is a post for Search"));

            // CleanUp posts
            ListPostsPage.TrashPost("This is a post for Search");
        }
    }
}
