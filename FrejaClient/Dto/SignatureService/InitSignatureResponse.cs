using System;
using System.Text.Json.Serialization;

namespace FrejaClient.Dto.SignatureService
{
    public class InitSignatureResponse
    {
        public InitSignatureResponse(string signRef)
        {
            if (string.IsNullOrWhiteSpace(signRef))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(signRef));

            SignRef = signRef;
        }

        [JsonPropertyName("signRef")]
        public string SignRef { get; }
    }
}