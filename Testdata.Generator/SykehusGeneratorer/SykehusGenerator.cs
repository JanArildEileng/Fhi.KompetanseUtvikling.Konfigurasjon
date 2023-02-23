using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                var pasient = pasientGenerator.Generate();
                sykehus.Pasienter.Add(pasient);
            }

            return sykehus;

        }
    }
}
