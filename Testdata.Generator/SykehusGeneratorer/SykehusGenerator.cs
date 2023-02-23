using Microsoft.Extensions.Options;
using Testdata.Generator.Configuration;

namespace Testdata.Generator.SykehusGeneratorer
{
    public class SykehusGenerator
    {
        int antallPasienter;
        PasientGenerator pasientGenerator;

        public SykehusGenerator(IOptions<SykehusGeneratorConfig> sykehusGeneratorConfig, PasientGenerator pasientGenerator)
        {
            antallPasienter = sykehusGeneratorConfig.Value.AntallPasienter;
            this.pasientGenerator = pasientGenerator;
        }

        internal Sykehus.Domene.Sykehus Generate()
        {
            var sykehus = new Sykehus.Domene.Sykehus();

            for (int i = 0; i < antallPasienter; i++)
            {
                sykehus.Pasienter.Add(pasientGenerator.Generate());
            }

            return sykehus;
        }
    }
}
