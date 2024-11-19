using System.Net.Http.Json;
using Wsi.AqualonPrime.Cons.Dtos;

namespace Wsi.AqualonPrime.Cons
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            HackTheFutureClient client = new();
            await client.Login(Constants.Name, Constants.Token);
            string startUrl = "https://app-htf-2024.azurewebsites.net/api/a/easy/puzzle";
            _ = await client.GetAsync(startUrl);
            await Run(client);
        }

        public static async Task Run(HackTheFutureClient client)
        {
            string getUrl = "https://app-htf-2024.azurewebsites.net/api/a/easy/puzzle";
            CommandsDto commands = await client.GetFromJsonAsync<CommandsDto>(getUrl) ?? throw new InvalidDataException();

            int distance = CalculateDepthAndDistance(commands.Commands.Split(","));

            string postUrl = "https://app-htf-2024.azurewebsites.net/api/a/easy/puzzle";
            HttpResponseMessage httpResponseMessage = await client.PostAsJsonAsync(postUrl, distance);
            Console.WriteLine(httpResponseMessage.StatusCode);
        }

        private static int CalculateDepthAndDistance(string[] commands)
        {
            int depthPerMeter = 0;
            int totalDepth = 0;
            int totalDistance = 0;

            foreach (string command in commands)
            {
                string[] parts = command.Split(' ');
                string action = parts[0];
                int value = int.Parse(parts[1]);

                switch (action)
                {
                    case "Down":
                        depthPerMeter += value;
                        break;
                    case "Up":
                        depthPerMeter -= value;
                        break;
                    case "Forward":
                        totalDistance += value;
                        totalDepth += depthPerMeter * value;
                        break;
                    default:
                        Console.WriteLine($"Onbekend commando: {action}");
                        break;
                }
            }

            return totalDepth * totalDistance;
        }
    }
}
