using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace URLDecode
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var encodeUrl = Console.ReadLine();

            var decodeUrl = WebUtility.UrlDecode(encodeUrl);

            Console.WriteLine(decodeUrl);
        }
    }
}
