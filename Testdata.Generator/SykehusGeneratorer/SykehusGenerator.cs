using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testdata.Generator.Configuration;

namespace Testdata.Generator.SykehusGeneratorer
{
    internal class SykehusGenerator
    {
        int antallPasienter;
        PasientGenerator pasientGenerator;

        public SykehusGenerator(IConfiguration configuration)
        {
            SykehusGeneratorConfig sykehusGeneratorConfig = new SykehusGeneratorConfig()
            {
                AntallPasienter = 2
            };
            configuration.GetSection("SykehusGenerator").Bind(sykehusGeneratorConfig);

            antallPasienter =sykehusGeneratorConfig.AntallPasienter;
            pasientGenerator = new PasientGenerator(configuration.GetSection("SykehusGenerator"));
        }


        internal Sykehus.Domene.Sykehus Generate()
        {
            var sykehus = new Sykehus.Domene.Sykehus();

            for (int i = 0; i < antallPasienter; i++)
            {
                var pasient = pasientGenerator.Generate();
                sykehus.Pasienter.Add(pasient);
            }

            return sykehus;

        }
    }
}
