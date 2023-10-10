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
    public class NodeConverter : JsonConverter
    {
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

                return jsonObject.ToObject(NodeUtils.TypeMapping[kind]);
            }
            catch (Exception e)
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
