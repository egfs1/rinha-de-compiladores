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
    public enum BinaryOp
    {
        Add,
        Sub,
        Mul,
        Div,
        Rem,
        Eq,
        Neq,
        Lt,
        Gt,
        Lte,
        Gte,
        And,
        Or
    }

    public class Binary : Term
    {
        [JsonConverter(typeof(NodeConverter))]
        public Term Lhs { get; set; }
        public BinaryOp Op { get; set; }
        [JsonConverter(typeof(NodeConverter))]
        public Term Rhs { get; set; }

        public Binary(Term lhs, BinaryOp op, Term rhs)
        {
            Lhs = lhs;
            Op = op;
            Rhs = rhs;
        }
    }
}
