using System;

namespace WebServer
{
    public class RequestParser
    {
        public static string[] ParseRequest(string request)
        {
            string[] linesInRequest = request.Split('\n');
            string[] tokens = linesInRequest[0].Split(' ');
            return tokens;
        }
    }
}