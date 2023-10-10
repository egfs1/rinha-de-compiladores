using RinhaDeCompiladores.Schemes.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RinhaDeCompiladores.Schemes
{
    public class Var : Term
    {
        public string Text { get; set; }

        public Var(string text)
        {
            Text = text;
        }
    }
}
