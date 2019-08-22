using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace NewsguardClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var domainName = "newyorktimes.com";

            var c = new HttpClient();
            var response = await c.GetStringAsync($"https://api.newsguardtech.com/check/{domainName}");
            var pocoResponse = JsonConvert.DeserializeObject<NewsguardResponse>(response);

            if (pocoResponse.criteria == null)
            {
                WriteConsoleMessageWithColor(ConsoleColor.Red, "No criteria found");

                if( pocoResponse.identifier == null)
                {
                    WriteConsoleMessageWithColor(ConsoleColor.Yellow, "Unknown (non news) site specified?");
                }
                return;
            }

            Console.WriteLine($"Report for {pocoResponse.identifier} - {pocoResponse.score}%");

            foreach (var item in pocoResponse.criteria)
            {
                var color = GetColor(item.body);
                WriteConsoleMessageWithColor(color, $"{item.title}");
            }
        }

        private static ConsoleColor GetColor(string body)
        {
            body = body.ToLower();

            if ( body == "yes")
            {
                return ConsoleColor.Green;
            }
            else if (body == "no")
            {
                return ConsoleColor.Red;
            }

            throw new ArgumentException("unknown input");
        }

        static void WriteConsoleMessageWithColor(ConsoleColor color, string message)
        {
            ConsoleColor backup = Console.ForegroundColor;

            Console.ForegroundColor = color;

            Console.WriteLine(message);

            Console.ForegroundColor = backup;
        }
    }
}
