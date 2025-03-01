using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace FrejaClient.Dto
{
    public abstract class Base64DtoBase
    {
        private static readonly JsonSerializerOptions Options = new JsonSerializerOptions
        {
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
        };

        public override string ToString()
        {
            var json = JsonSerializer.Serialize(this, GetType(), Options);

            var base64 = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(json));

            return base64;
        }
    }
}