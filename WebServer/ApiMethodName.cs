using System.Net.Sockets;

namespace WebServer
{
    public class ApiMethodName
    {
        public string getName(string requestType, string apiMethod, Socket clientSocket)
        {
            foreach (var type in typeof(ApiMethodList).GetMethods())
            {
                var attributes = (ApiMethodAttribute[])type.GetCustomAttributes(typeof(ApiMethodAttribute), false);
                foreach(var attribute in attributes)
                {
                    if (attribute.RequestType == requestType && attribute.ApiMethod == apiMethod)
                        return type.Name;
                }
            }

            //return Error.InvalidApiMethod(clientSocket);      //Make this method
            return "Invalid Api method";
        }
    }
}