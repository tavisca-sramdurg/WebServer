using System;
using System.Net.Sockets;
using System.Text;

namespace WebServer
{
    public class Dispatcher
    {
        private WebAppList webAppList;
        public Dispatcher()
        {
            webAppList = new WebAppList();
        }

        public bool DispatchRequest(Socket clientSocket)
        {
            NetworkStream networkStream = new NetworkStream(clientSocket);
            byte[] dataInBytes = new byte[1024];
            int byteDataCount = networkStream.Read(dataInBytes, 0, dataInBytes.Length);
            string request = Encoding.ASCII.GetString(dataInBytes, 0, byteDataCount);

            string[] tokens = RequestParser.ParseRequest(request);
            string[] parsedUrl = tokens[1].Split('/');

            if (parsedUrl[1].Equals("api"))
            {
                RestApi.SendResponse(request, tokens, clientSocket);
                return true;
            }
            //else if ()
            //{

            //}
            else
            {
                Error.PageNotFound(clientSocket);
                return false;
            }
        }
    }
}