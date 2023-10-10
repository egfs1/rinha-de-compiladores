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
    public class Function : Term
    {
        public List<Parameter> Parameters { get; set; }
        [JsonConverter(typeof(NodeConverter))]
        public Term Value { get; set; }

        public Function(List<Parameter> parameters, Term value)
        {
            Parameters = parameters;
            Value = value;
        }
    }
}
