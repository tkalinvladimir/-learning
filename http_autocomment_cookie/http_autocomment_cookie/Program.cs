using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace http_autocomment_cookie
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            string uri = "http://mycsharp.ru/lesson_post.aspx";
            HttpWebRequest request = WebRequest.Create(uri) as HttpWebRequest;
            request.Proxy = WebRequest.GetSystemWebProxy();
            request.Proxy.Credentials = CredentialCache.DefaultCredentials;
           // request.Headers.Add("Cookie: _ym_uid=1488179809882022862; _ym_isad=2; _ym_visorc_21378790=w; _rbu=14881798107722174826; _ga=GA1.2.1392866558.1488179809; _gat=1; mycsharp=BFCB1F7AA194AF54198FDDE86E20245C596EF000E9669A77ADC03D6B2F0F72D365EA21E0AFEFF936E480D0F602ADD704F6F29675648BDCE669BB66EEFE1E14C99A094245B0F28E056055A2229B5502278C5911EB0780CC0456AA69518299986F7ED2EAA298FC6ECEA5BFF43D17ED0F6C678190EE; ASP.NET_SessionId=zuxexn0ojkaopj5wv2uuw3qo; _rbs=14882374644089991956");
            // данные для отправки, здесь я изменил значение тектового поля на "http_post"
            string postData = "VIEWSTATE=%2FwEPDwULLTEzNDY2NDcwOTEPZBYCZg9kFgICAw9kFgYCAQ8PFgIeB1Zpc2libGVoZGQCAw8PFgIfAGhkZAIHD2QWAgIBDw8WAh4EVGV4dAUG0JDQkdCSZGQYAgUeX19Db250cm9sc1JlcXVpcmVQb3N0QmFja0tleV9fFgMFI2N0bDAwJExvZ2luVmlldzEkTG9naW5TdGF0dXMyJGN0bDAxBSNjdGwwMCRMb2dpblZpZXcxJExvZ2luU3RhdHVzMiRjdGwwMwUWY3RsMDAkQnV0dG9uQWRkTWVzc2FnZQUQY3RsMDAkTG9naW5WaWV3MQ8PZAIBZLTbMHPaqQFi5Bc6pKxRThv3AjaR&__VIEWSTATEGENERATOR=B8D7EBDC&__EVENTVALIDATION=%2FwEdAAaIoOPQb56k9iKbUuDTDIDPg8CfUEZ4x6JEFru5nuWdjCW%2BqOYM8KaSMijlDwu7G%2FLcsSnZ18juQMuHSVUa%2FyIvHzTcyUMF0BNvM9WAdwxerE6E1mG5ttYwRKM8%2FHd5iYo7tLTxkAX%2FOLHb3bY%2B1ByUDYzCZw%3D%3D&ctl00%24ContentPlaceHolder1%24Text=abcdef&ctl00%24ContentPlaceHolder1%24ButtonTextToUpper=%D0%9E%D1%82%D0%BF%D1%80%D0%B0%D0%B2%D0%B8%D1%82%D1%8C&ctl00%24email=%D1%82%D0%B2%D0%BE%D0%B9+e-mail";
            byte[] data = Encoding.UTF8.GetBytes(postData);
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = data.Length;
 
            // ??????????????????
            using (var stream = request.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }

            HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
            Console.WriteLine(reader.ReadToEnd().Contains("abcdef"));   //вернет тру или фолс
            //Console.WriteLine(reader.ReadToEnd());
            Console.ReadLine();
*/
            string uri = "http://mycsharp.ru/post/51/2016_07_28_protokol_http_metod_post_i_kuki_v_si-sharp.html";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            request.Proxy = WebRequest.GetSystemWebProxy();
            request.Proxy.Credentials = CredentialCache.DefaultCredentials;
            request.Headers.Add("Cookie: _ym_uid=1488179809882022862; _ym_isad=2; _ym_visorc_21378790=w; _rbu=14881798107722174826; _ga=GA1.2.1392866558.1488179809; mycsharp=BFCB1F7AA194AF54198FDDE86E20245C596EF000E9669A77ADC03D6B2F0F72D365EA21E0AFEFF936E480D0F602ADD704F6F29675648BDCE669BB66EEFE1E14C99A094245B0F28E056055A2229B5502278C5911EB0780CC0456AA69518299986F7ED2EAA298FC6ECEA5BFF43D17ED0F6C678190EE; ASP.NET_SessionId=zuxexn0ojkaopj5wv2uuw3qo; _rbs=14882397201461206553");

            // данные для отправки, здесь я изменил значение тектового поля на "http_post"
            // string postData = "__VIEWSTATE=%2FwEPDwULLTEzNDY2NDcwOTEPZBYCZg9kFgICAw9kFgQCAw8PFgIeB1Zpc2libGVoZGQCBQ8PFgIfAGhkZBgCBR5fX0NvbnRyb2xzUmVxdWlyZVBvc3RCYWNrS2V5X18WAwUjY3RsMDAkTG9naW5WaWV3MSRMb2dpblN0YXR1czIkY3RsMRDEFI2N0bDAwJExvZ2luVmlldzEkTG9naW5TdGF0dXMyJGN0bDAzBRZjdGwwMCRCdXR0b25BZGRNZXNzYWdlBRBjdGwwMCRMb2dpblZpZXcxDw9kAgFklPjrncDGuwrKW9f9BwjvWEd1XX4 % 3D & __VIEWSTATEGENERATOR = B8D7EBDC & __EVENTVALIDATION =% 2FwEdAAaH57zUq1EcgzGHRmNTrPx7g8CfUEZ4x6JEFru5nuWdjCW % 2BqOYM8KaSMijlDwu7G % 2FLcsSnZ18juQMuHSVUa % 2FyIvHzTcyUMF0BNvM9WAdwxerE6E1mG5ttYwRKM8 % 2FHd5iYqdyvbUyTUDQtBYcvYy5Rw1v9nQ2g % 3D % 3D & ctl00 % 24ContentPlaceHolder1 % 24Text = http_post & ctl00 % 24ContentPlaceHolder1 % 24ButtonTextToUpper =% D0 % 9E % D1 % 82 % D0% BF % D1 % 80 % D0 % B0 % D0 % B2 % D0 % B8 % D1 % 82 % D1 % 8C & ctl00 % 24email =% D1 % 82 % D0 % B2 % D0 % BE % D0 % B9 + e - mail";
            string postData = "__EVENTTARGET=&__EVENTARGUMENT=&__VIEWSTATE=%2FwEPDwUJNzg3OTE4NTEzZBgCBR5fX0NvbnRyb2xzUmVxdWlyZVBvc3RCYWNrS2V5X18WBQUjY3RsMDAkTG9naW5WaWV3MSRMb2dpblN0YXR1czIkY3RsMDEFI2N0bDAwJExvZ2luVmlldzEkTG9naW5TdGF0dXMyJGN0bDAzBStjdGwwMCRDb250ZW50UGxhY2VIb2xkZXIxJEJ1dHRvbkFkZE1lc3NhZ2UyBSljdGwwMCRDb250ZW50UGxhY2VIb2xkZXIxJEltYWdlQnV0dG9uQ29kZQUWY3RsMDAkQnV0dG9uQWRkTWVzc2FnZQUQY3RsMDAkTG9naW5WaWV3MQ8PZAIBZABer4jJFtJ99RSYFNJ7%2BQ07NDId&__VIEWSTATEGENERATOR=AD7AD114&__EVENTVALIDATION=%2FwEdAAo1V7j00rnZDHxm%2Bqmmz78ng8CfUEZ4x6JEFru5nuWdjOF5u10kY4z8bQzmOH3HYPfY9Wbgx5wbmQnu0TIq2KVEMBPtPHD3IbRvk%2ByxeYb249n5knBKcPSHpv%2B8TYPc88rGIkRLQMRfpt90sxb216PuaUc%2BflwzNZomJ2Bj9oHnDx803MlDBdATbzPVgHcMXqxOhNZhubbWMESjPPx3eYmK%2F%2Fz1UIw8b%2Bf09RCgQdyx%2BBbg9zE%3D&ctl00%24ContentPlaceHolder1%24email2=%D1%82%D0%B2%D0%BE%D0%B9+e-mail&ctl00%24ContentPlaceHolder1%24TextBoxMessage=I did it! (Valodya)&ctl00%24ContentPlaceHolder1%24ButtonAddMessage=%D0%94%D0%BE%D0%B1%D0%B0%D0%B2%D0%B8%D1%82%D1%8C&ctl00%24email=%D1%82%D0%B2%D0%BE%D0%B9+e-mail";
            // конвертируем строку в массив байтов
            byte[] data = Encoding.UTF8.GetBytes(postData);
            // указываем метод запроса POST
            request.Method = "POST";
            // для POST запроса необходимо указать тип передаваемых данных и размер
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = data.Length;
            // записываем в поток запроса данные
            using (var stream = request.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
            string answer = reader.ReadToEnd();
            File.AppendAllText("E:\\testPOST.txt", answer);
            
            reader.Close();
            Console.ReadLine();
        }
    }
}
