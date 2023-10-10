using Newtonsoft.Json;
using RinhaDeCompiladores.Schemes.Abstractions;
using RinhaDeCompiladores.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RinhaDeCompiladores.Schemes
{
    public class Let : Term
    {
        public Parameter Name { get; set; }
        [JsonConverter(typeof(NodeConverter))]
        public Term Value { get; set; }
        [JsonConverter(typeof(NodeConverter))]
        public Term Next { get; set; }

        public Let(Parameter name, Term value, Term next)
        {
            Name = name;
            Value = value;
            Next = next;
        }
    }
}
