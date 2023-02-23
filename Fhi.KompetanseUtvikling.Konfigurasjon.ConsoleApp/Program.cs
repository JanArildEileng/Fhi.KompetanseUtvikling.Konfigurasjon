using Microsoft.Extensions.Configuration;
using System.Text.Json;
using Testdata.Generator;

IConfigurationBuilder configurationBuilder = new ConfigurationBuilder().AddJsonFile("Config.json");
IConfigurationRoot configuration = configurationBuilder.Build();

Console.WriteLine($"{configuration["Hello"]}");

const int antallSykehus = 2;
IMyGenerator myGenerator = new MyGenerator();
SykehusGeneratedData sykehusGeneratedData = myGenerator.GenerateSykehusData(10101, "Secret", antallSykehus);

string jsonString = JsonSerializer.Serialize<SykehusGeneratedData> (sykehusGeneratedData,new JsonSerializerOptions() { WriteIndented=true});

Console.WriteLine(jsonString);
