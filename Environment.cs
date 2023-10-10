using RinhaDeCompiladores.Schemes.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RinhaDeCompiladores
{
    public class Environment
    {
        private Dictionary<string, object?> Variables;
        private Environment? Parent;

        public Environment(Environment? parent = null)
        {
            Parent = parent;
            Variables = new Dictionary<string, object?>();
        }

        public object? DeclareVariable(string varname, object? value)
        {
            Variables[varname] = value;
            return value;
        }

        public object? LookupVariable(string varname)
        {
            Environment env = Resolve(varname);
            return env.Variables[varname];
        }

        public Environment Resolve(string varname)
        {
            if (Variables.ContainsKey(varname))
                return this;

            if (Parent == null)
                throw new Exception($"Cannot resolve '{varname}' as it does not exist.");

            return Parent.Resolve(varname);
        }
    }
}
