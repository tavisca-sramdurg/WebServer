using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Text;

namespace WebServer
{
    [Serializable]
    public class ServerException : ApplicationException
    {
        public void InvalidApiCallException(Socket clientSocket)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("HTTP/1.0 404 Not Found");
            stringBuilder.AppendLine("Content-Type: text/html" + ";charset=UTF-8");
            stringBuilder.AppendLine();

            List<byte> response = new List<byte>();
            response.AddRange(Encoding.ASCII.GetBytes(stringBuilder.ToString()));

            string errorMessage = "<HTML><BODY><h1>404 Not Found</h1><p>Web Page not found!</p></BODY></HTML>";
            response.AddRange(Encoding.ASCII.GetBytes(errorMessage));
            byte[] responseInByte = response.ToArray();
            clientSocket.Send(responseInByte);
        }

        public void PageNotFoundException(Socket clientSocket)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("HTTP/1.0 404 Not Found");
            stringBuilder.AppendLine("Content-Type: text/html" + ";charset=UTF-8");
            stringBuilder.AppendLine();

            List<byte> response = new List<byte>();
            response.AddRange(Encoding.ASCII.GetBytes(stringBuilder.ToString()));

            string errorMessage = "<HTML><BODY><h1>404 Not Found</h1><p>Web Page not found!</p></BODY></HTML>";
            response.AddRange(Encoding.ASCII.GetBytes(errorMessage));
            byte[] responseInByte = response.ToArray();
            clientSocket.Send(responseInByte);
        }

        public void BadRequestException(Socket clientSocket)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("HTTP/1.0 400 Bad Request");
            stringBuilder.AppendLine("Content-Type: text/html" + ";charset=UTF-8");
            stringBuilder.AppendLine();

            List<byte> response = new List<byte>();
            response.AddRange(Encoding.ASCII.GetBytes(stringBuilder.ToString()));

            string errorMessage = "<HTML><BODY><h1>400 Bad Request</h1><p>Invalid Request!</p></BODY></HTML>";
            response.AddRange(Encoding.ASCII.GetBytes(errorMessage));
            byte[] responseInByte = response.ToArray();
            clientSocket.Send(responseInByte);
        }
    }
}