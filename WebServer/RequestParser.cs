using System;

namespace WebServer
{
    public class RequestParser
    {
        public static string[] ParseRequest(string request)
        {
            string[] linesInRequest = request.Split('\n');
            string[] requestTokens = linesInRequest[0].Split(' ');     
            return requestTokens;   //return the first line
        }
    }
}


