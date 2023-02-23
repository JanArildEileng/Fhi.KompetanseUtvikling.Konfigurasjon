using Microsoft.Extensions.Options;
using Sykehus.Domene;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            var sykdom = new Sykdom();

            sykdom.Navn = sykdomsnavn[RandomGenerator.GetRandom(sykdomsnavn.Length)];
            sykdom.Alvorligshetsgrad =RandomGenerator.GetRandom(maxAlvorligshetsgrad,1);


            return sykdom;
        }

    }
}
