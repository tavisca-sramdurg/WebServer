using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;

namespace WebServer
{
    public class Error
    {
        public static void PageNotFound(Socket clientSocket)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("HTTP/1.0 404 Not Found");
            stringBuilder.AppendLine("Content-Type: text/html" + ";charset=UTF-8");
            stringBuilder.AppendLine();

            List<byte> response = new List<byte>();
            response.AddRange(Encoding.ASCII.GetBytes(stringBuilder.ToString()));

            string errorMessage = "<HTML><BODY><h1>404 Not Found</h1><p>Web Page not found!!!!!!!!!!!</p></BODY></HTML>";

            response.AddRange(Encoding.ASCII.GetBytes(errorMessage));
            byte[] responseInByte = response.ToArray();
            clientSocket.Send(responseInByte);
        }

        public static void InvalidApiCall(Socket clientSocket)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("HTTP/1.0 404 Not Found");
            stringBuilder.AppendLine("Content-Type: text/html" + ";charset=UTF-8");
            stringBuilder.AppendLine();

            List<byte> response = new List<byte>();
            response.AddRange(Encoding.ASCII.GetBytes(stringBuilder.ToString()));

            string errorMessage = "<HTML><BODY><h1>404 Not Found</h1><p>The Api you're trying to call does not exist!</p></BODY></HTML>";

            response.AddRange(Encoding.ASCII.GetBytes(errorMessage));
            byte[] responseInByte = response.ToArray();
            clientSocket.Send(responseInByte);
        }
    }
}