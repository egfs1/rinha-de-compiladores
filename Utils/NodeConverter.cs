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
        public Dictionary<NodeType, Type> typeMapping = new Dictionary<NodeType, Type>()
        {
            { NodeType.Var, typeof(string) },
            { NodeType.Function, typeof(string) },
            { NodeType.Call, typeof(string) },
            { NodeType.Let, typeof(string) },
            { NodeType.Str, typeof(Str) },
            { NodeType.Int, typeof(string) },
            { NodeType.Binary, typeof(string) },
            { NodeType.If, typeof(string) },
            { NodeType.Tuple, typeof(string) },
            { NodeType.First, typeof(string) },
            { NodeType.Second, typeof(string) },
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
            catch
            {
                throw new Exception($"Invalid value for Kind '{jsonObject["kind"]}'");
            }
        }

        public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
