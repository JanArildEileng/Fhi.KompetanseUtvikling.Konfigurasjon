using Microsoft.Extensions.Options;
using Testdata.Generator.Configuration;
using Testdata.Generator.SykehusGeneratorer;


namespace Testdata.Generator
{
    public interface IMyGenerator
    {
        SykehusGeneratedData GenerateSykehusData(int secretKey, string secretValue,int antallSykehus);
    }

    public class MyGenerator : IMyGenerator
    {
        private readonly IOptions<SykehusGeneratorConfig> sykehusGeneratorConfig;
        private readonly SykehusGenerator sykehusGenerator;

        public MyGenerator(IOptions<SykehusGeneratorConfig> sykehusGeneratorConfig, SykehusGenerator sykehusGenerator)
        {
            this.sykehusGeneratorConfig = sykehusGeneratorConfig;
            this.sykehusGenerator = sykehusGenerator;
        }


        public SykehusGeneratedData GenerateSykehusData(int secretKey, string secretValue,int antallSykehus)
        {
            

            SykehusGeneratedData data = new SykehusGeneratedData(secretKey, secretValue);

            for (int i=0; i < antallSykehus; i++)
            {
                Sykehus.Domene.Sykehus sykehus = sykehusGenerator.Generate();
                data.AddSykehus(sykehus);
            }
            return data;
        }
    }
}