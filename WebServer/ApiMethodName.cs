using System.Net.Sockets;

namespace WebServer
{
    public class ApiMethodName
    {
        public string getName(string requestType, string apiMethod, Socket clientSocket)
        {
            try
            {
                foreach (var type in typeof(ApiMethodList).GetMethods())
                {
                    var attributes = (ApiMethodAttribute[])type.GetCustomAttributes(typeof(ApiMethodAttribute), false);
                    foreach (var attribute in attributes)
                    {
                        if (attribute.RequestType == requestType && attribute.ApiMethod == apiMethod)
                            return type.Name;
                    }
                }
                throw new ServerException();
            }
            catch (ServerException e)
            {
                e.InvalidApiCallException(clientSocket);
                return "Invalid Api method";
            }
        }
    }
}