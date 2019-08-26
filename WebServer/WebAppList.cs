using System;
using System.Collections.Generic;

namespace WebServer
{
    public class WebAppList
    {
        private static Dictionary<string, string> _webAppList= new Dictionary<string, string>();
        public WebAppList()
        {
            _webAppList.Add("amazon.com", "C:/Users/sramdurg/Desktop/GitRepos/WebServer/www/amazon");
            _webAppList.Add("flipkart.com", "C:/Users/sramdurg/Desktop/GitRepos/WebServer/www/flipkart");
            _webAppList.Add("snapdeal.com", "C:/Users/sramdurg/Desktop/GitRepos/WebServer/www/snapdeal");
        }
        public bool IfWebsiteExists(string webAppName)
        {
            return _webAppList.ContainsKey(webAppName);
        }

        public string GetPathToRootDirectory(string webAppName)
        {
            if (!_webAppList.ContainsKey(webAppName))
            {
                return null;
            }
            return _webAppList[webAppName];    
        }
    }
}