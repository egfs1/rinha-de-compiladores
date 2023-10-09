using Newtonsoft.Json;
using RinhaDeCompiladores.Schemes;
using RinhaDeCompiladores.Schemes.Abstractions;

namespace RinhaDeCompiladores
{
    public interface ITranslator
    {
        public object? Evaluate(Term expression);
    }

    public class Program
    {
        private static ITranslator translator = new Interpreter();

        static void Main(string[] args)
        {
            var ast = JsonConvert.DeserializeObject<AST>(File.ReadAllText("./Files/print.json"))!;
            translator.Evaluate(ast.Expression);
        }
    }

}