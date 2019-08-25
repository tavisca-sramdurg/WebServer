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
    }
}
