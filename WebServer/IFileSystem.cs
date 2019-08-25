using System;
using System.Collections.Generic;
using System.Text;

namespace WebServer
{
    public interface IFileSystem
    {
        string ResolveVirtualPath(string virtualPath, string localFilePath, string uri);
        string GetFileData(string filePath);
    }
}
