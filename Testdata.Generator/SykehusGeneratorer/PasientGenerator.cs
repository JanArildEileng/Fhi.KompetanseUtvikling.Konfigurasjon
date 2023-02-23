using Sykehus.Domene;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testdata.Generator.SykehusGeneratorer
{
    internal class PasientGenerator
    {
        static string[] Pronmomens = { "han", "hun", "hen", "hin", "hyn" };
        const int maxAlder = 120;
        const int maxAntallSykdommer = 5;
        SykdomGenerator sykdomGenerator;
        public PasientGenerator()
        {
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
