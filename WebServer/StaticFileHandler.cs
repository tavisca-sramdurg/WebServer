using System;
using System.IO;

namespace WebServer
{
    public class StaticFileHandler : IFileSystem
    {
        public string ResolveVirtualPath(string virtualPath, string localFilePath, string uri)
        {
            return virtualPath.Replace(uri, localFilePath);
        }

        public string GetFileData(string filePathOnServer)
        {
            string fileData;
            try
            {
                fileData = File.ReadAllText(filePathOnServer);
            }
            catch (Exception)
            {
                return null;
            }
            return fileData;
        }
    }
}