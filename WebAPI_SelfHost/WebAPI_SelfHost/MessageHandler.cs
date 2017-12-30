using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace WebAPI_SelfHost
{
    class MessageHandler : HttpMessageHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            Console.WriteLine("Recieved an http message");
            var task = new Task<HttpResponseMessage>(()=>
            {
                var msg = new HttpResponseMessage();
                msg.Content = new StringContent("Self-Hosting");
                Console.WriteLine("Http response returned");
                return msg;
            });
            task.Start();
            return task;
        }        
    }
}
