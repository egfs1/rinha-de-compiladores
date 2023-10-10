using RinhaDeCompiladores.Schemes.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RinhaDeCompiladores.Schemes
{
    public class Int : Term
    {
        public int Value { get; set; }

        public Int(int value)
        {
            Value = value;
        }
    }
}
