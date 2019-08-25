using System;
using Xunit;
using WebServer;

namespace WebServerTest
{
    public class StaticFileHandlerTest
    {
        [Fact]
        public void TestResolveVirtualPath()
        {
            StaticFileHandler file = new StaticFileHandler();
            //act
            string filePath = file.ResolveVirtualPath("amazon.com/index.html", "C:/Users/sramdurg/Desktop/GitRepos/WebServer/www/amazon", "amazon.com");
            //assert
            Assert.Equal("C:/Users/sramdurg/Desktop/GitRepos/WebServer/www/amazon/index.html", filePath);
        }
    }
}
