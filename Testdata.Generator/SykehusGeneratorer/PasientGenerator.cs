using Microsoft.Extensions.Options;
using Sykehus.Domene;
using Testdata.Generator.Configuration;

namespace Testdata.Generator.SykehusGeneratorer
{
    public class PasientGenerator
    {
        string[] Pronmomens;
        int maxAlder;
        int maxAntallSykdommer;
        SykdomGenerator sykdomGenerator;

        public IOptions<PasientGeneratorConfig> PasientGeneratorConfig { get; }

        public PasientGenerator(IOptions<PasientGeneratorConfig> pasientGeneratorConfig, SykdomGenerator sykdomGenerator)
        {
            this.sykdomGenerator = sykdomGenerator;
            PasientGeneratorConfig = pasientGeneratorConfig;

            Pronmomens = pasientGeneratorConfig.Value.Pronmomens;
            maxAlder = pasientGeneratorConfig.Value.maxAlder;
            maxAntallSykdommer= pasientGeneratorConfig.Value.maxAntallSykdommer;
        }


        internal Pasient Generate()
        {
            var pasient = new Pasient();
            pasient.Alder = RandomGenerator.GetRandom(maxAlder);
            pasient.Pronomen = Pronmomens[RandomGenerator.GetRandom(Pronmomens.Length)];
            for (int i = 0; i < RandomGenerator.GetRandom(maxAntallSykdommer,1); i++)
            {
                pasient.Sykdommer.Add(sykdomGenerator.Generate());
            }

            return pasient;
        }
    }
}
