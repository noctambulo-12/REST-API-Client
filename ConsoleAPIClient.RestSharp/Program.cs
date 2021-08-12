using Chiwchi.Console;
using RestSharp;

namespace ConsoleAPIClient.RestSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleSpinner spinner = new ConsoleSpinner();
            spinner.Start();

            var client = new RestClient($"https://randomuser.me/api");
            var request = new RestRequest(Method.GET);
            var response = client.Execute(request);

            spinner.Stop();

            Cli.Info(response.Content);
        }
    }
}
