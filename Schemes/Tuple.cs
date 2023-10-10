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
    public class Tuple : Term
    {
        [JsonConverter(typeof(NodeConverter))]
        public Term First { get; set; }
        [JsonConverter(typeof(NodeConverter))]
        public Term Second { get; set; }

        public Tuple(Term first, Term second)
        {
            First = first;
            Second = second;
        }
    }
}
