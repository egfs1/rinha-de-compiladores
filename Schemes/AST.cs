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
    public class AST
    {
        public string Name { get; set; }
        [JsonConverter(typeof(NodeConverter))]
        public Term Expression { get; set; }
        public Location Location { get; set; }

        public AST(string name, Term expression, Location location)
        {
            Name = name;
            Expression = expression;
            Location = location;
        }
    }
}
