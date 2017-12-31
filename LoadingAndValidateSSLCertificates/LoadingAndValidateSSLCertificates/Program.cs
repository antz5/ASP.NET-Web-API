using System.IdentityModel.Selectors;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using Thinktecture.IdentityModel;

namespace LoadingAndValidateSSLCertificates
{
    class Program
    {
        static void Main(string[] args)
        {
            //Load the certificate using ThinkTecture nuget package
            var certificate = X509.LocalMachine.My.SubjectDistinguishedName.Find("CN=localhost").First();

            //validate the certificate
            var chain = new X509Chain();
            var policy = new X509ChainPolicy
            {
                RevocationFlag = X509RevocationFlag.EntireChain,
                RevocationMode = X509RevocationMode.Online
            };
            chain.ChainPolicy = policy;
            if(!chain.Build(certificate))
            {
                foreach (var element in chain.ChainElements)
                {
                    foreach (var status in element.ChainElementStatus)
                    {
                        System.Console.WriteLine(status.StatusInformation);
                    }
                }
            }
            var validator = X509CertificateValidator.ChainTrust;
            validator.Validate(certificate);
        }
    }
}
