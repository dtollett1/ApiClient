using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;
using System.Collections.Generic;

namespace ApiClient
{
    class Program
    {
        class Joke
        {
            public int id { get; set; }
            public string type { get; set; }
            public bool setup { get; set; }
            public string punchline { get; set; }

        }
        static async Task Main(string[] args)
        {
            var client = new HttpClient();

            var responseAsStream = await client.GetStreamAsync("https://github.com/15Dkatz/official_joke_api");

            var jokes = await JsonSerializer.DeserializeAsync<List<Joke>>(responseAsStream);

            foreach (var joke in jokes)
            {

                Console.WriteLine($"The joke {joke.type} has a setup of {joke.setup} and a punchline of: {joke.punchline}");

            }
        }
    }
}
