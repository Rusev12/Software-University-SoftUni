using System;
using System.Text;

namespace ValidateUrl
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var url = Console.ReadLine();

            Uri uriResult;

            var isValidUrl = Uri.TryCreate(url, UriKind.Absolute, out uriResult);


            if (isValidUrl)
            {

                if (uriResult.Scheme == Uri.UriSchemeHttp && uriResult.Port != 80)
                {
                    Console.WriteLine("Invalid!");

                }
                else if (uriResult.Scheme == Uri.UriSchemeHttps && uriResult.Port != 443)
                {
                    Console.WriteLine("Invalid!");
                }
                else
                {
                    Console.WriteLine(PrintUrlArgs(uriResult)); 
        
                }
                
            }
            else
            {
                Console.WriteLine("Invalid!");
            }

        }

        private static string PrintUrlArgs(Uri uriResult)
        {
            var sb = new StringBuilder();
            var queryString = uriResult.Query == "" ? "" : $"Query: {uriResult.Query}";
            var fragment = uriResult.Fragment == "" ? "" : $"Fragment: {uriResult.Fragment}";
            sb.AppendLine($"Protocol: {uriResult.Scheme}");
            sb.AppendLine($"Host: {uriResult.Host}");
            sb.AppendLine($"Port: {uriResult.Port}");
            sb.AppendLine($"Path: {uriResult.LocalPath}");
            if(queryString != "")
            {
                sb.AppendLine(queryString);
            }
            if(fragment != "")
            {
                sb.AppendLine(fragment);
            }
            return sb.ToString().Trim();
        }
    }
}
