using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestParser
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var path = Console.ReadLine();
            var validPathAndMethod = new Dictionary<string, HashSet<string>>();
            while (true)
            {
                if (path == "END")
                {
                    break;
                }

                var pathArgs = path.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
                var pathName = pathArgs[0];
                var methodFromPath = pathArgs[1];

                if (!validPathAndMethod.ContainsKey(pathName))
                {
                    validPathAndMethod[pathName] = new HashSet<string>();
                }
                validPathAndMethod[pathName].Add(methodFromPath);

                path = Console.ReadLine();
            }

            var request = Console.ReadLine();
            var requestArgs = request.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);

            var method = requestArgs[0].Trim();
            var reqPath = requestArgs[1].Split().ToList().First();

            if (validPathAndMethod.ContainsKey(reqPath) && validPathAndMethod[reqPath].Contains(method.ToLower()))
            {
               
                    Console.WriteLine(PrintHttpOkResponse());
   
            }
            else
            {
                Console.WriteLine(PrintNotFoundResponse());
            }
        }

        private static string PrintNotFoundResponse()
        {
            var sb = new StringBuilder();
            sb.AppendLine("HTTP/1.1 404 NotFound");
            sb.AppendLine("Content-Length: 9");
            sb.AppendLine("Content-Type: text/plain");
            sb.AppendLine("");
            sb.AppendLine("NotFound");

            return sb.ToString().Trim();
        }

        private static string PrintHttpOkResponse()
        {
            var sb = new StringBuilder();
            sb.AppendLine("HTTP/1.1 200 OK");
            sb.AppendLine("Content-Length: 2");
            sb.AppendLine("Content-Type: text/plain");
            sb.AppendLine("");
            sb.AppendLine("OK");

            return sb.ToString().Trim();
        }
    }
}
