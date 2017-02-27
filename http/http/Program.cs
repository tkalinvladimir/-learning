using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net;
using System.IO;
using System.Text.RegularExpressions;

namespace http
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            string uri = "http://mycsharp.ru/post/49/2015_03_02_setevoe_programmirovanie_v_si-sharp.html";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            request.Proxy = WebRequest.GetSystemWebProxy();
            request.Proxy.Credentials = CredentialCache.DefaultCredentials;
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
            Console.WriteLine(reader.ReadToEnd());
            Console.ReadLine();
            Console.Clear();
            foreach (string h in response.Headers)
            {
                Console.WriteLine("{0}: {1}", h, response.Headers[h]);
            }
            Console.ReadLine();
            Console.Clear();
           */

            
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create("http://mycsharp.ru");
            req.Proxy = WebRequest.GetSystemWebProxy();
            req.Proxy.Credentials = CredentialCache.DefaultCredentials;
            req.UserAgent = "lesson34";
            HttpWebResponse response = req.GetResponse() as HttpWebResponse; 
            StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
            string answer = reader.ReadToEnd();

            MatchCollection matches = Regex.Matches(answer, "<h2>.*?</h2>", RegexOptions.Singleline);
            foreach (Match m in matches)
            {
                string header = Regex.Replace(m.Value, "<.*?>", "");
                Console.WriteLine(header.Trim());
            }
            Console.ReadKey();
            

        }
    }
}
