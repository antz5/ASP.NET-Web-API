using System;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace X_Http_Method_Override.MessageHandlers
{
    public class X_Http_Method_Override_Handler : DelegatingHandler
    {
        readonly string[] _methods = { "DELETE", "HEAD", "PUT" };
        private string _header = "X-HTTP-Method-Override";

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if(request.Method == HttpMethod.Post && request.Headers.Contains(_header))
            {
                //check if the header value is in our method list
                var method = request.Headers.GetValues(_header).FirstOrDefault();
                if(_methods.Contains(method, StringComparer.InvariantCultureIgnoreCase))
                {
                    request.Method = new HttpMethod(method);
                }
            }
            return await base.SendAsync(request, cancellationToken);
        }
    }
}