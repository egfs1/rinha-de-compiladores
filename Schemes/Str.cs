using RinhaDeCompiladores.Schemes.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RinhaDeCompiladores.Schemes
{
    public class Str : Term
    {
        public string Value { get; set; }

        public Str(string value)
        {
            Value = value;
        }

    }
}
