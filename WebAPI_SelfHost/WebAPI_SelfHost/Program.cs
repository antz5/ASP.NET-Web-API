using System;
using System.Web.Http.SelfHost;

namespace WebAPI_SelfHost
{
    class Program
    {
        static void Main(string[] args)
        {
            var config = new HttpSelfHostConfiguration("http://localhost:8999");

            var server = new HttpSelfHostServer(config, new MessageHandler());
            var task = server.OpenAsync();
            task.Wait();
            Console.WriteLine("Server is up and running");
            Console.ReadLine();
        }
    }
}
