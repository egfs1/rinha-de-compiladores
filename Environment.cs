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
        private readonly Environment? Parent;
        private readonly Dictionary<string, object?> Variables;

        public Environment(Environment? parent = null)
        {
            Parent = parent;
            Variables = new Dictionary<string, object?>();
        }

        public void DeclareVariable(string varname, object? value)
        {
            if(varname != "_")
            {
                Variables[varname] = value;
            }
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

            if (Parent != null)
                return Parent.Resolve(varname);

            throw new Exception($"Cannot resolve '{varname}' as it does not exist.");
        }
    }
}
