using System;
using System.Net.Sockets;

namespace WebServer
{
    public class Server
    {
        private HTTP_Listener _listener;
        public Server()
        {
            _listener = new HTTP_Listener();
        }

        public void Run()
        {
            Socket webServerSocket = _listener.StartListening();
            _listener.ForwardRequestToDispatcher(webServerSocket);
        }
    }
}