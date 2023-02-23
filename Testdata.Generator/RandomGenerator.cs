using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testdata.Generator
{
    public static class RandomGenerator
    {
        static Random random = new Random();

        public static int GetRandom(int max,int min=0)
        {
            return  min+ random.Next(max-min);
        } 

    }
}
