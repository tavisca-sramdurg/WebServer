using System;

namespace WebServer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Initiating WebServer!");
            Server server = new Server();
            server.Run();
            Console.ReadKey();
        }
    }
}
