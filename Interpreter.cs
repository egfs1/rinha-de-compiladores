using RinhaDeCompiladores.Schemes;
using RinhaDeCompiladores.Schemes.Abstractions;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace RinhaDeCompiladores
{
    public class Interpreter : ITranslator
    {
        public object? Evaluate(Term node, Environment env)
        {
            switch (node.Kind)
            {
                case NodeType.Str:
                    return ((Str)node).Value;

                case NodeType.Int:
                    return ((Int)node).Value;

                case NodeType.Bool:
                    return ((Bool)node).Value;

                case NodeType.Tuple:
                    return EvaluateTuple((Schemes.Tuple)node, env);

                case NodeType.First:
                    return EvaluateTupleFirst((First)node, env);

                case NodeType.Second:
                    return EvaluateTupleSecond((Second)node, env);

                case NodeType.Binary:
                    return EvaluateBinary((Binary)node, env);

                case NodeType.Var:
                    return EvaluateVar((Var)node, env);

                case NodeType.Let:
                    return EvaluateLet((Let)node, env);

                case NodeType.Function:
                    return EvaluateFunction((Function)node, env);

                case NodeType.Call:
                    return EvaluateCall((Call)node, env);

                case NodeType.If:
                    return EvaluateIf((If)node, env);

                case NodeType.Print:
                   return EvaluatePrint((Print)node, env);

                default:
                    throw new Exception($"Kind '{node.Kind}' does not exist.");
            }
        }

        #region tuple

        private Tuple<object?, object?> EvaluateTuple(Schemes.Tuple node, Environment env)
        {
            object? first = Evaluate(node.First, env);
            object? second = Evaluate(node.Second, env);
            return new Tuple<object?, object?>(first, second);
        }

        private object? EvaluateTupleFirst(First node, Environment env)
        {
            if (node.Value is Schemes.Tuple tupleNode)
            {
                return EvaluateTuple(tupleNode, env).Item1;
            }
            else
            {
                throw new Exception("");
            }
        }

        private object? EvaluateTupleSecond(Second node, Environment env)
        {
            if (node.Value is Schemes.Tuple tupleNode)
            {
                return EvaluateTuple(tupleNode, env).Item2;
            }
            else
            {
                throw new Exception("");
            }
        }

        #endregion

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

        #region variable

        private object? EvaluateVar(Var node, Environment env)
        {
            string varname = node.Text;
            return env.LookupVariable(varname);
        }

        private object? EvaluateLet(Let node, Environment env)
        {
            string varname = node.Name.Text;
            Term value = node.Value;
            Term next = node.Next;
            env.DeclareVariable(varname, Evaluate(value, env));
            return Evaluate(next, env);
        }

        #endregion

        #region function

        public object? EvaluateFunction(Function node, Environment env)
        {
            return node;
        }

        public object? EvaluateCall(Call node, Environment env)
        {
            object? callee = Evaluate(node.Callee, env);

            if (callee is Function calleeFunction)
            {
                if (node.Arguments.Count != calleeFunction.Parameters.Count)
                {
                    throw new Exception($"Call passed {node.Arguments.Count} arguments, function accepts {calleeFunction.Parameters.Count}");
                }

                Environment functionEnv = new Environment(env);

                for (int i = 0; i < calleeFunction.Parameters.Count; i++)
                {
                    functionEnv.DeclareVariable(calleeFunction.Parameters[i].Text, Evaluate(node.Arguments[i], env));
                }

                return Evaluate(calleeFunction.Value, functionEnv);
            }
            else
            {
                throw new Exception("Cannot call a non-function object.");
            }
        }

        #endregion

        #region conditional

        public object? EvaluateIf(If node, Environment env)
        {
            object? condition = Evaluate(node.Condition, env);

            if (condition is bool conditionBool)
            {
                if (conditionBool)
                    return Evaluate(node.Then, env);
                else
                    return Evaluate(node.Otherwise, env);
            }
            else
            {
                throw new Exception("Condition is not boolean");
            }
        }

        #endregion

        #region output

        public object? EvaluatePrint(Print node, Environment env)
        {
            object? value = Evaluate(node.Value, env);
            Console.WriteLine(value);
            return value;
        }

        #endregion
    }
}
