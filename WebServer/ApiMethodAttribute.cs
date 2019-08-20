using System;
using System.Collections.Generic;
using System.Text;

namespace WebServer
{
    [AttributeUsage(AttributeTargets.Method)]
    public class ApiMethodAttribute : Attribute
    {
        public string RequestType { get; set; }        //try and make set private
        public string ApiMethod { get; set; }

        public ApiMethodAttribute(string requestType, string apiMethod)
        {
            RequestType = requestType;
            ApiMethod = apiMethod;
        }
    }
}
