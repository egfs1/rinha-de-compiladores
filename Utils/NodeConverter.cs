using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RinhaDeCompiladores.Schemes;
using RinhaDeCompiladores.Schemes.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RinhaDeCompiladores.Utils
{
    public class NodeConverter : JsonConverter
    {
        private Dictionary<NodeType, Type> typeMapping = new Dictionary<NodeType, Type>()
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

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Node);
        }

        public override object? ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
        {
            JObject jsonObject = JObject.Load(reader);
            try
            {
                NodeType kind = jsonObject["kind"]!.ToObject<NodeType>();

                return jsonObject.ToObject(typeMapping[kind]);
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
