using Roedores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace VeterinariaExoticos
{
    public class RoedorConverter : JsonConverter<Roedor>
    {
        /// <summary>
        /// Se crea un diccionario que mapea nombres de Tipo
        /// </summary>
        private static Dictionary<string, Type> _typeMapping = new Dictionary<string, Type>
        {
            { nameof(Hamster), typeof(Hamster) },
            { nameof(Raton), typeof(Raton) },
            { nameof(Topo), typeof(Topo) }
        };

        /// <summary>
        /// Deserializa el tipo de Roedor para poder leerlo.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="typeToConvert"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        /// <exception cref="JsonException"></exception>
        public override Roedor Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            using (JsonDocument doc = JsonDocument.ParseValue(ref reader))
            {
                if (doc.RootElement.TryGetProperty("Discriminator", out JsonElement typeProperty))
                {
                    string? typeName = typeProperty.GetString();
                    if (_typeMapping.TryGetValue(typeName, out Type? type))
                    {
                        if(type != null)
                        {
                            return (Roedor?)JsonSerializer.Deserialize(doc.RootElement.GetRawText(), type, options);
                        }else
                        {
                            throw new JsonException("Type is null.");
                        }
                    }
                }
                throw new JsonException("Cannot determine type for Roedor.");
            }
        }

        /// <summary>
        /// Serializa el tipo de Roedor para poder guardarlo.
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="value"></param>
        /// <param name="options"></param>
        public override void Write(Utf8JsonWriter writer, Roedor value, JsonSerializerOptions options)
        {
            var type = value.GetType();
            writer.WriteStartObject();
            writer.WriteString("Discriminator", type.Name);
            foreach (var prop in type.GetProperties())
            {
                if (prop.CanRead && prop.CanWrite)
                {
                    var propValue = prop.GetValue(value);
                    writer.WritePropertyName(prop.Name);
                    JsonSerializer.Serialize(writer, propValue, prop.PropertyType, options);
                }
            }

            writer.WriteEndObject();
        }

    }
}
