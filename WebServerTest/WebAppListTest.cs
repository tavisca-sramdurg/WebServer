using System;
using Xunit;
using WebServer;

namespace WebServerTest
{
    public class WebAppListTest
    {
        [Fact]
        public void Test_webApp_lookup_when_website_exists()
        {
            //arrange
            WebAppList webApplist = new WebAppList();
            //act
            bool ifWebAppExists = webApplist.IfWebsiteExists("amazon.com");
            //assert
            Assert.Equal(true, ifWebAppExists);
        }

        [Fact]
        public void Test_webApp_lookup_when_website_does_not_exists()
        {
            //arrange
            WebAppList webApplist = new WebAppList();
            //act
            bool ifWebAppExists = webApplist.IfWebsiteExists("youtube.com");
            //assert
            Assert.Equal(false, ifWebAppExists);
        }

        [Fact]
        public void Test_getting_path_to_root_directory_when_website_exists()
        {
            //arrange
            WebAppList webApplist = new WebAppList();
            //act
            string path = webApplist.GetPathToRootDirectory("amazon.com");

            string expectedPathToRootDirectory = "C:/Users/sramdurg/Desktop/GitRepos/WebServer/www/amazon";
            //assert
            Assert.Equal(expectedPathToRootDirectory, path);
        }

        [Fact]
        public void Test_getting_path_to_root_directory_when_website_does_not_exists()
        {
            //arrange
            WebAppList webApplist = new WebAppList();
            //act
            var path = webApplist.GetPathToRootDirectory("ebay.com");
            //assert
            Assert.Equal(null, path);
        }
    }
}
