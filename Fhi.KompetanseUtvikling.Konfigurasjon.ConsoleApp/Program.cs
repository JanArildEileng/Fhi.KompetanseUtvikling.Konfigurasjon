using Microsoft.Extensions.Configuration;
using System.Text.Json;
using Testdata.Generator;

IConfigurationBuilder configurationBuilder = new ConfigurationBuilder()
    .AddJsonFile("Config.json")
    .AddCommandLine(args);

IConfigurationRoot configuration = configurationBuilder.Build();

IConfiguration configurationHello = configuration.GetSection("Hello");
Console.WriteLine($"{configurationHello["Greeting"]} from {configurationHello["From"]}");

const int antallSykehus = 2;
IMyGenerator myGenerator = new MyGenerator();
SykehusGeneratedData sykehusGeneratedData = myGenerator.GenerateSykehusData(10101, "Secret", antallSykehus);

string jsonString = JsonSerializer.Serialize<SykehusGeneratedData> (sykehusGeneratedData,new JsonSerializerOptions() { WriteIndented=true});

Console.WriteLine(jsonString);

Console.WriteLine($"Goodbye from {configuration["Hello:From"]}");
