using RinhaDeCompiladores.Schemes.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RinhaDeCompiladores.Schemes
{
    public class Bool : Term
    {
        public bool Value { get; set; }

        public Bool(bool value)
        {
            Value = value;
        }
    }
}
