using Newtonsoft.Json.Linq;
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
        public object? Evaluate(Term node, Environment env)
        {
            switch (node.Kind)
            {
                case NodeType.Var:
                    Var varNode = (Var)node;
                    return env.LookupVariable(varNode.Text);

                case NodeType.Function:
                    return null;

                case NodeType.Call:
                    return null;

                case NodeType.Let:
                    Let letNode = (Let)node;
                    env.DeclareVariable(letNode.Name.Text, Evaluate(letNode.Value, env));
                    Evaluate(letNode.Next, env);
                    return null;

                case NodeType.Str:
                    return ((Str)node).Value;

                case NodeType.Int:
                    return ((Int)node).Value;

                case NodeType.Bool:
                    return ((Bool)node).Value;

                case NodeType.Binary:
                    return EvaluateBinary((Binary)node, env);

                case NodeType.If:
                    return null;

                case NodeType.Tuple:
                    return null;

                case NodeType.First:
                    if (node is First firstNode && firstNode.Value is Schemes.Tuple tupleFirstNode)
                        return Evaluate(tupleFirstNode.First, env);
                    else
                        throw new Exception("");

                case NodeType.Second:
                    if (node is Second secondNode && secondNode.Value is Schemes.Tuple tupleSecondNode)
                        return Evaluate(tupleSecondNode.Second, env);
                    else
                        throw new Exception("");

                case NodeType.Print:
                    object? printValue = Evaluate(((Print)node).Value, env);
                    Console.WriteLine(printValue);
                    return printValue;

                default:
                    throw new Exception($"Kind '{node.Kind}' does not exist.");
            }
        }

        #region binary

        private object? EvaluateBinary(Binary node, Environment env)
        {
            object? lhs = Evaluate(node.Lhs, env);
            object? rhs = Evaluate(node.Rhs, env);

            if (lhs is int && rhs is int)
            {
                return EvaluateBinaryNumeric((int)lhs, (int)rhs, node.Op);
            }
            else if (lhs is bool && rhs is bool)
            {
                return EvaluateBinaryBoolean((bool)lhs, (bool)rhs, node.Op);
            }
            else if (lhs is string && rhs is string || lhs is int && rhs is string || lhs is string && rhs is int)
            {
                return EvaluateBinaryText(lhs.ToString()!, rhs.ToString()!, node.Op);
            }
            else
            {
                throw new Exception($"Binary operation is impossible between '{lhs?.GetType().Name ?? "null"}' and '{rhs?.GetType().Name ?? "null"}'");
            }
        }

        private object? EvaluateBinaryNumeric(int lhs, int rhs, BinaryOp op)
        {
            switch (op)
            {
                case BinaryOp.Add:
                    return lhs + rhs;
                case BinaryOp.Sub:
                    return lhs - rhs;
                case BinaryOp.Mul:
                    return lhs * rhs;
                case BinaryOp.Div:
                    return lhs / rhs;
                case BinaryOp.Rem:
                    return lhs % rhs;
                case BinaryOp.Eq:
                    return lhs == rhs;
                case BinaryOp.Neq:
                    return lhs != rhs;
                case BinaryOp.Lt:
                    return lhs < rhs;
                case BinaryOp.Gt:
                    return lhs > rhs;
                case BinaryOp.Lte:
                    return lhs <= rhs;
                case BinaryOp.Gte:
                    return lhs >= rhs;
                default:
                    throw new Exception($"'{op}' is not valid for numeric operations.");
            }
        }

        private object? EvaluateBinaryBoolean(bool lhs, bool rhs, BinaryOp op)
        {
            switch (op)
            {
                case BinaryOp.Eq:
                    return lhs == rhs;
                case BinaryOp.Neq:
                    return lhs != rhs;
                case BinaryOp.And:
                    return lhs && rhs;
                case BinaryOp.Or:
                    return lhs || rhs;
                default:
                    throw new Exception($"'{op}' is not valid for boolean operations.");
            }
        }

        private object? EvaluateBinaryText(string lhs, string rhs, BinaryOp op)
        {
            switch (op)
            {
                case BinaryOp.Add:
                    return lhs + rhs;
                case BinaryOp.Eq:
                    return lhs == rhs;
                case BinaryOp.Neq:
                    return lhs != rhs;
                default:
                    throw new Exception($"'{op}' is not valid for text operations.");
            }
        }

        #endregion
    }
}
