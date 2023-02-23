
using System.Text.Json;
using Testdata.Generator;

Console.WriteLine("Hello, SykehusGeneratedData!");

const int antallSykehus = 2;
IMyGenerator myGenerator = new MyGenerator();
SykehusGeneratedData sykehusGeneratedData = myGenerator.GenerateSykehusData(10101, "Secret", antallSykehus);

string jsonString = JsonSerializer.Serialize<SykehusGeneratedData> (sykehusGeneratedData,new JsonSerializerOptions() { WriteIndented=true});

Console.WriteLine(jsonString);


