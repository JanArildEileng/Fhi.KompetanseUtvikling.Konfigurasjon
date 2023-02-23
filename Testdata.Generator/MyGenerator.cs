using Testdata.Generator.SykehusGeneratorer;

namespace Testdata.Generator
{
    public interface IMyGenerator
    {
        SykehusGeneratedData GenerateSykehusData(int secretKey, string secretValue,int antallSykehus);
    }

    public class MyGenerator : IMyGenerator
    {
        public SykehusGeneratedData GenerateSykehusData(int secretKey, string secretValue,int antallSykehus)
        {
            SykehusGenerator sykehusGenerator = new SykehusGenerator();

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