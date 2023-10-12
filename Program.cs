using Newtonsoft.Json;
using RinhaDeCompiladores.Converters;
using RinhaDeCompiladores.Schemes;
using RinhaDeCompiladores.Schemes.Abstractions;

namespace RinhaDeCompiladores
{
    public interface ITranslator
    {
        public object? Evaluate(Term expression, Environment env);
    }

    class Program 
    {
        private readonly static ITranslator translator = new Interpreter();
        private readonly static Environment env = new Environment();

        static void Main(string[] args)
        {
            string jsonFile = File.ReadAllText("./var/rinha/rinha.json");
            AST ast = JsonConvert.DeserializeObject<AST>(jsonFile)!;
            translator.Evaluate(ast.Expression, env);
        }
    }
}