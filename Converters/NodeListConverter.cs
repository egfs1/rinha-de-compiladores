using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RinhaDeCompiladores.Schemes;
using RinhaDeCompiladores.Schemes.Abstractions;
using RinhaDeCompiladores.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RinhaDeCompiladores.Converters
{
    public class NodeListConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(List<Node>);
        }

        public override object? ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
        {
            reader.MaxDepth = 256;

            var jsonArray = JArray.Load(reader);
            var list = new List<Term>();

            foreach (var jsonObject in jsonArray)
            {
                try
                {
                    NodeType kind = jsonObject["kind"]!.ToObject<NodeType>();

                    list.Add((Term)jsonObject.ToObject(NodeUtils.TypeMapping[kind])!);
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
            }

            return list;
        }

        public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
