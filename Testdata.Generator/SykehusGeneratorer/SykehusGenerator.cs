using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testdata.Generator.SykehusGeneratorer
{
    internal class SykehusGenerator
    {
        int antallPasienter = 2;
        PasientGenerator pasientGenerator;

        public SykehusGenerator()
        {
            pasientGenerator = new PasientGenerator();
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
