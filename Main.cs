using Newtonsoft.Json;
using RinhaDeCompiladores.Schemes;
using RinhaDeCompiladores.Schemes.Abstractions;

namespace RinhaDeCompiladores
{
    public interface ITranslator
    {
        public object? Evaluate(Term expression, Environment env);
    }

    public class Program 
    {
        private static ITranslator translator = new Interpreter();
        private static Environment env = new Environment();

        static void Main(string[] args)
        {
            var ast = JsonConvert.DeserializeObject<AST>(File.ReadAllText("./Files/print_declared_var.json"))!;
            translator.Evaluate(ast.Expression, env);
        }
    }

}