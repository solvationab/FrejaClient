using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Refit;

namespace FrejaClient.Extensions
{
    public class FrejaFormUrlEncodedParameterFormatter : DefaultFormUrlEncodedParameterFormatter
    {
        private static readonly JsonSerializerOptions Options = new JsonSerializerOptions
        {
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
        };

        /// <summary>
        /// Formats the specified parameter value.
        /// </summary>
        /// <param name="parameterValue">The parameter value.</param>
        /// <param name="formatString">The format string.</param>
        /// <returns></returns>
        public override string Format(object parameterValue, string formatString)
        {
            if (parameterValue != null && parameterValue.GetType().IsClass)
            {
                var json = JsonSerializer.Serialize(parameterValue, parameterValue.GetType(), Options);

                var base64 = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(json));

                return base64;
            }

            return base.Format(parameterValue, formatString);
        }
    }
}