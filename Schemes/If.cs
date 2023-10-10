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
    public class If : Term
    {
        [JsonConverter(typeof(NodeConverter))]
        public Term Condition { get; set; }
        [JsonConverter(typeof(NodeConverter))]
        public Term Then { get; set; }
        [JsonConverter(typeof(NodeConverter))]
        public Term Otherwise { get; set; }

        public If(Term condition, Term then, Term otherwise)
        {
            Condition = condition;
            Then = then;
            Otherwise = otherwise;
        }
    }
}
