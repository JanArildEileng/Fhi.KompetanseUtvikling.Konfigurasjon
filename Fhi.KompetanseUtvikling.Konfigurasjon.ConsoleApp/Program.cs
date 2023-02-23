using Fhi.KompetanseUtvikling.Konfigurasjon.ConsoleApp.Configuration;
using Microsoft.Extensions.Configuration;
using System.Text.Json;
using Testdata.Generator;

IConfigurationBuilder configurationBuilder = new ConfigurationBuilder()
    .AddJsonFile("Config.json")
    .AddCommandLine(args);

IConfigurationRoot configuration = configurationBuilder.Build();

HelloConfiguration helloConfiguration = new HelloConfiguration()
{
    Dato = DateTime.Now.ToString()
};

configuration.GetSection("Hello").Bind(helloConfiguration);



Console.WriteLine($"{helloConfiguration.Greeting} from {helloConfiguration.From}");

const int antallSykehus = 2;
IMyGenerator myGenerator = new MyGenerator();
SykehusGeneratedData sykehusGeneratedData = myGenerator.GenerateSykehusData(10101, "Secret", antallSykehus);

string jsonString = JsonSerializer.Serialize<SykehusGeneratedData> (sykehusGeneratedData,new JsonSerializerOptions() { WriteIndented=true});

Console.WriteLine(jsonString);

Console.WriteLine($"Goodbye from {configuration["Hello:From"]}");

Console.WriteLine($"Dato: {helloConfiguration.Dato}");

