using System;
using System.Net.Sockets;
using System.Text;

namespace WebServer
{
    public class Dispatcher
    {
        private WebAppList _webAppList;
        private WebApp _webApp;
        public Dispatcher()
        {
            _webAppList = new WebAppList();
        }

        public bool DispatchRequest(Socket clientSocket)
        {
            try
            {
                NetworkStream networkStream = new NetworkStream(clientSocket);
                byte[] dataInBytes = new byte[1024];
                int byteDataCount = networkStream.Read(dataInBytes, 0, dataInBytes.Length);
                string request = Encoding.ASCII.GetString(dataInBytes, 0, byteDataCount);

                string[] resquestTokens = RequestParser.ParseRequest(request); //firstLine of header
                string[] parsedUrl = resquestTokens[1].Split('/');  //splitting the url

                if (parsedUrl[1].Equals("api"))
                {
                    RestApi.SendResponse(request, resquestTokens, clientSocket);
                    return true;
                }
                else if (_webAppList.IfWebsiteExists(parsedUrl[1]))
                {
                    string uri = "/" + parsedUrl[1];
                    string rootDirectoryPath = _webAppList.GetPathToRootDirectory(parsedUrl[1]);
                    _webApp = new WebApp(uri, rootDirectoryPath, clientSocket);
                    _webApp.ProcessRequest(resquestTokens[1]);  //Sending url to Webapp
                    return true;
                }
                else
                {
                    throw new ServerException();             
                }
            }
            catch(ServerException e)
            {
                e.BadRequestException(clientSocket);
                return false;
            }
        }   
    }
}