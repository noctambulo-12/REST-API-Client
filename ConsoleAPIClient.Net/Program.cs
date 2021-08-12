using Chiwchi.Console;
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace ConsoleAPIClient
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleSpinner spinner = new ConsoleSpinner();
            spinner.Start();

            var request = (HttpWebRequest)WebRequest.Create($"https://randomuser.me/api");
            request.Method = "GET";
            request.ContentType = "application/json";
            request.Accept = "application/json";

            using WebResponse response = request.GetResponse();
            using Stream stream = response.GetResponseStream();

            if (stream == null) return;
            using StreamReader reader = new StreamReader(stream);
            string responseBody = reader.ReadToEnd();

            spinner.Stop();

            Cli.Info(responseBody);

        }

    }
}
