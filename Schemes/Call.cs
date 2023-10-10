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
    public class Call : Term
    {
        [JsonConverter(typeof(NodeConverter))]
        public Term Callee { get; set; }
        [JsonConverter(typeof(NodeListConverter))]
        public List<Term> Arguments { get; set; }

        public Call(Term callee, List<Term> arguments)
        {
            Callee = callee;
            Arguments = arguments;
        }
    }
}
