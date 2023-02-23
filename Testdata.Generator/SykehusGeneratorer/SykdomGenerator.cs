using Sykehus.Domene;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testdata.Generator.SykehusGeneratorer
{
    internal class SykdomGenerator
    {
      
        static string[] sykdomsnavn = { "Host", "Harke", "Snufse" };
        static int maxAlvorligshetsgrad = 5;

        internal Sykdom Generate()
        {
            var sykdom = new Sykdom();

            sykdom.Navn = sykdomsnavn[RandomGenerator.GetRandom(sykdomsnavn.Length)];
            sykdom.Alvorligshetsgrad =RandomGenerator.GetRandom(maxAlvorligshetsgrad,1);


            return sykdom;
        }

    }
}
