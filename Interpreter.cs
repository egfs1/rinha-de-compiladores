using RinhaDeCompiladores.Schemes;
using RinhaDeCompiladores.Schemes.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RinhaDeCompiladores
{
    public class Interpreter : ITranslator
    {
        public object? Evaluate(Term node)
        {
            switch (node.Kind)
            {
                case NodeType.Var:
                    return null;

                case NodeType.Function:
                    return null;

                case NodeType.Call:
                    return null;

                case NodeType.Let:
                    return null;

                case NodeType.Str:
                    return ((Str) node).Value;

                case NodeType.Int:
                    return null;

                case NodeType.Binary:
                    return null;

                case NodeType.If:
                    return null;

                case NodeType.Tuple:
                    return null;

                case NodeType.First:
                    return null;

                case NodeType.Second:
                    return null;

                case NodeType.Print:
                    object? value = Evaluate(((Print) node).Value);
                    Console.WriteLine(value);
                    return null;

                default:
                    return null;
            }
        }
    }
}
