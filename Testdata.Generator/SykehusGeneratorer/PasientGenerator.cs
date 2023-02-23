using Microsoft.Extensions.Configuration;
using Sykehus.Domene;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testdata.Generator.Configuration;

namespace Testdata.Generator.SykehusGeneratorer
{
    internal class PasientGenerator
    {
        string[] Pronmomens;
        int maxAlder;
        int maxAntallSykdommer;
        SykdomGenerator sykdomGenerator;
        public PasientGenerator(IConfiguration configuration)
        {

            PasientGeneratorConfig pasientGeneratorConfig = new PasientGeneratorConfig()
            {
                Pronmomens= new string[] { "han", "hun", "hen", "hin", "hyn" },
                maxAlder=10,
                maxAntallSykdommer=5
            };
            configuration.GetSection("PasientGenerator").Bind(pasientGeneratorConfig);

            Pronmomens = pasientGeneratorConfig.Pronmomens;
            maxAlder = pasientGeneratorConfig.maxAlder;
            maxAntallSykdommer = pasientGeneratorConfig.maxAntallSykdommer;

            sykdomGenerator = new SykdomGenerator();
        }


        internal Pasient Generate()
        {
            var pasient = new Pasient();
            pasient.Alder = RandomGenerator.GetRandom(maxAlder);
            pasient.Pronomen = Pronmomens[RandomGenerator.GetRandom(Pronmomens.Length)];
            for (int i = 0; i < RandomGenerator.GetRandom(maxAntallSykdommer,1); i++)
            {
                var sykdom = sykdomGenerator.Generate();
                pasient.Sykdommer.Add(sykdom);

            }

            return pasient;
        }
    }
}
