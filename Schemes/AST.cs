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
    public class AST : Node
    {
        public string Name { get; set; }
        [JsonConverter(typeof(NodeConverter))]
        public Term Expression { get; set; }

        public AST(string name, Term expression)
        {
            Name = name;
            Expression = expression;
        }
    }
}
