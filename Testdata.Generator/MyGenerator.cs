using Testdata.Generator.SykehusGeneratorer;

namespace Testdata.Generator;

public interface IMyGenerator
{
    SykehusGeneratedData GenerateSykehusData(int secretKey, string secretValue,int antallSykehus);
}

public class MyGenerator : IMyGenerator
{
    private readonly SykehusGenerator sykehusGenerator;

    public MyGenerator (SykehusGenerator sykehusGenerator)
    {
        this.sykehusGenerator = sykehusGenerator;
    }

    public SykehusGeneratedData GenerateSykehusData(int secretKey, string secretValue,int antallSykehus)
    {
        SykehusGeneratedData data = new SykehusGeneratedData(secretKey, secretValue);

        for (int i=0; i < antallSykehus; i++)
        {
            data.AddSykehus(sykehusGenerator.Generate());
        }
        return data;
    }
}