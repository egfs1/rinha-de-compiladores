using Newtonsoft.Json;
using RinhaDeCompiladores.Converters;
using RinhaDeCompiladores.Schemes.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RinhaDeCompiladores.Schemes
{
    public class Second : Term
    {
        [JsonConverter(typeof(NodeConverter))]
        public Term Value { get; set; }
        public Second(Term value)
        {
            Value = value;
        }
    }
}
