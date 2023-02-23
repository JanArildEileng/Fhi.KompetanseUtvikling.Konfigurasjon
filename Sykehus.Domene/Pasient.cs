using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sykehus.Domene
{
    public class Pasient
    {
        public int Alder { get; set; }
        public string Pronomen { get; set; }


        public List<Sykdom> Sykdommer { get; set; } = new List<Sykdom>();

    }
}
