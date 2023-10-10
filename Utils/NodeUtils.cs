using RinhaDeCompiladores.Schemes.Abstractions;
using RinhaDeCompiladores.Schemes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RinhaDeCompiladores.Utils
{
    public static class NodeUtils
    {
        public static readonly Dictionary<NodeType, Type> TypeMapping = new Dictionary<NodeType, Type>()
        {
            { NodeType.Var, typeof(Var) },
            { NodeType.Function, typeof(Function) },
            { NodeType.Call, typeof(Call) },
            { NodeType.Let, typeof(Let) },
            { NodeType.Str, typeof(Str) },
            { NodeType.Int, typeof(Int) },
            { NodeType.Bool, typeof(Bool) },
            { NodeType.Binary, typeof(Binary) },
            { NodeType.If, typeof(If) },
            { NodeType.Tuple, typeof(Schemes.Tuple) },
            { NodeType.First, typeof(First) },
            { NodeType.Second, typeof(Second) },
            { NodeType.Print, typeof(Print) }
        };
    }
}
