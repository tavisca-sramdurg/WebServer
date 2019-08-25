using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;

namespace WebServer
{
    public class RestApi
    {
        public static void SendResponse(string request, string[] tokens, Socket clientSocket)
        {
            string root = tokens[1].Replace("api/", "");

            string[] parsedRequest = request.Split('{');
            string body = parsedRequest[1];

            ApiMethodList apiMethodList = new ApiMethodList();            //Resolve Dependency Inversion
            ApiMethodName apiMethodName = new ApiMethodName();      //Resolve Dependency Inversion

            string methodName = apiMethodName.getName("POST", root, clientSocket);

            var result = new Object();

            result = apiMethodList.GetType().GetMethod(methodName).Invoke(apiMethodList, new object[] { body });

            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("HTTP/1.0 200 OK");
            stringBuilder.AppendLine("Content-Type: application/json" + ";charset=UTF-8");
            stringBuilder.AppendLine();

            List<byte> response = new List<byte>();
            response.AddRange(Encoding.ASCII.GetBytes(stringBuilder.ToString()));
            response.AddRange(Encoding.ASCII.GetBytes(result.ToString()));
            byte[] responseInBytes = response.ToArray();
            clientSocket.Send(responseInBytes);
        }
    }
}
