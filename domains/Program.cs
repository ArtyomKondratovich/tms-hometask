using System.Text;
using domains;
using domains.OutputProviders;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;


var path = Path.Combine(Environment.CurrentDirectory, @"..\..\..\config.json");
var config = new ConfigurationBuilder().AddJsonFile(path).Build().GetSection("settings");

IOutputProvider outputProvider = config["outputProvider"] switch
{
    "file" => new FileOutputProvider(config["fileName"]),
    "console" => new ConsoleOutputProvider(),
    _ => throw new InvalidOperationException()
};

var client = new HttpClient();

var domain = new StringBuilder("https://en.wikipedia.org/wiki/.");

for (var i = 'a'; i < 'z'; i++)
{
    domain.Append(i);

    for (var j = 'a'; j < 'z'; j++)
    {
        domain.Append(j);

        try
        {
            var responce = await client.GetAsync(domain.ToString());

            if (responce.IsSuccessStatusCode)
            {
                outputProvider.Write(await responce.Content.ReadAsStringAsync(), domain.ToString()[^2..] + ".html");
            }
        }
        catch (Exception)
        {
            continue;
        }

        domain.Remove(domain.Length - 1, 1);
    }

    domain.Remove(domain.Length - 1, 1);
}
