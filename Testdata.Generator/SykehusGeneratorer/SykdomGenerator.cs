using Microsoft.Extensions.Options;
using Sykehus.Domene;
using Testdata.Generator.Configuration;

namespace Testdata.Generator.SykehusGeneratorer
{
    public class SykdomGenerator
    {
        string[] sykdomsnavn;
        int maxAlvorligshetsgrad;

        public SykdomGenerator(IOptions<SykdomGeneratorConfig> sykdomGeneratorConfig)
        {
            sykdomsnavn = sykdomGeneratorConfig.Value.Sykdomsnavn;
            maxAlvorligshetsgrad=sykdomGeneratorConfig.Value.MaxAlvorligshetsgrad;
        }

        internal Sykdom Generate()
        {
            var sykdom = new Sykdom()
            {
                Navn = sykdomsnavn[RandomGenerator.GetRandom(sykdomsnavn.Length)],
                Alvorligshetsgrad = RandomGenerator.GetRandom(maxAlvorligshetsgrad, 1)
            };
            return sykdom;
        }

    }
}
