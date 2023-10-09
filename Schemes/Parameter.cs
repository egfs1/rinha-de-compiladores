using RinhaDeCompiladores.Schemes.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RinhaDeCompiladores.Schemes
{
    public class Parameter : Node
    {
        public string Text { get; set; }

        public Parameter(string text)
        {
            Text = text;
        }
    }
}
