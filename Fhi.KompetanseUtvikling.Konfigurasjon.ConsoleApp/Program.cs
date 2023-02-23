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

SecretConfiguration secretConfiguration =configuration.GetSection("Secret").Get<SecretConfiguration>();

AntallSykehusConfig antallSykehusConfig = new AntallSykehusConfig()
{
    AntallSykehus = 1
};
configuration.Bind(antallSykehusConfig);

IMyGenerator myGenerator = new MyGenerator(configuration.GetSection("TestDataGenerator"));

SykehusGeneratedData sykehusGeneratedData = myGenerator.GenerateSykehusData(secretConfiguration.SecretKey, secretConfiguration.SecretValue, antallSykehusConfig.AntallSykehus);

string jsonString = JsonSerializer.Serialize<SykehusGeneratedData> (sykehusGeneratedData,new JsonSerializerOptions() { WriteIndented=true});

Console.WriteLine(jsonString);

Console.WriteLine($"Goodbye from {configuration["Hello:From"]}");

Console.WriteLine($"Dato: {helloConfiguration.Dato}");

