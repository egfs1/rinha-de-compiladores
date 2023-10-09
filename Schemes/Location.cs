using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RinhaDeCompiladores.Schemes
{
    public class Location
    {
        public int Start { get; set; }
        public int End { get; set; }
        public string Filename { get; set; }

        public Location(int start, int end, string filename)
        {
            Start = start;
            End = end;
            Filename = filename;
        }
    }
}
