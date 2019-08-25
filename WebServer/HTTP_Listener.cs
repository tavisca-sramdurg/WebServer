using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace WebServer
{
    public class HTTP_Listener
    {
        private Socket _webServerSocket;
        private IPEndPoint _ipEndPoint;
        private Dispatcher _dispatcher;

        public HTTP_Listener()
        {
            _dispatcher = new Dispatcher();
        }

        public Socket StartListening()
        {
            _webServerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            _ipEndPoint = new IPEndPoint(IPAddress.Any, 55031);
            _webServerSocket.Bind(_ipEndPoint);
            _webServerSocket.Listen(10);
            Console.WriteLine("Server has started.");
            return _webServerSocket;
        }

        public void ForwardRequestToDispatcher(Socket webServerSocket)
        {
            new Thread(_ =>
            {
                while (true)
                {
                    Socket clientSocket = webServerSocket.Accept();
                    Console.WriteLine("Connection established.");
                    _dispatcher.DispatchRequest(clientSocket);
                    clientSocket.Shutdown(SocketShutdown.Both);
                    clientSocket.Close();
                }
            }).Start();
        }
    }
}