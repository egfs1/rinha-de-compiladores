using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RinhaDeCompiladores.Schemes.Abstractions
{
    public enum NodeType
    {
        Var,
        Function,
        Call,
        Let,
        Str,
        Int,
        Bool,
        Binary,
        If,
        Tuple,
        First,
        Second,
        Print
    }

    public abstract class Node
    {
        public Location Location { get; set; }
    }

    public abstract class Term : Node
    {
        public NodeType Kind { get; set; }
    }
}
