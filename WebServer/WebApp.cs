using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;

namespace WebServer
{
    internal class WebApp
    {
        private string _uri;
        private string _localFilePath;
        private Socket _clientSocket;
        public StringBuilder stringBuilder;
        private StaticFileHandler _staticFileHandler;

        public WebApp(string uri, string rootDirectoryPath, Socket clientSocket)
        {
            this._uri = uri;
            this._localFilePath = rootDirectoryPath;
            this._clientSocket = clientSocket;
            _staticFileHandler = new StaticFileHandler();
        }

        public void ProcessRequest(string virtualPath)
        {
            string filePathOnServer = _staticFileHandler.ResolveVirtualPath(virtualPath, _localFilePath, _uri);
            string data = _staticFileHandler.GetFileData(filePathOnServer);
            try
            {
                if (string.IsNullOrEmpty(data))
                {
                    throw new ServerException();
                }
                else
                {
                    stringBuilder = new StringBuilder();
                    stringBuilder.AppendLine("HTTP/1.1 200 OK");
                    stringBuilder.AppendLine("Content-Type: text/html" + ";charset=UTF-8");
                    stringBuilder.AppendLine();

                    List<byte> response = new List<byte>();
                    response.AddRange(Encoding.ASCII.GetBytes(stringBuilder.ToString()));
                    response.AddRange(Encoding.ASCII.GetBytes(data));
                    byte[] responseByte = response.ToArray();
                    _clientSocket.Send(responseByte);
                }
            }
            catch (ServerException e)
            {
                e.PageNotFoundException(_clientSocket);
            }
            
        }
    }
}