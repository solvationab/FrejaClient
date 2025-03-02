using System;
using System.Text.Json.Serialization;

namespace FrejaClient.Dto.AuthenticationService
{
    public class InitAuthenticationResponse
    {
        public InitAuthenticationResponse(string authRef)
        {
            if (authRef == null) 
                throw new ArgumentNullException(nameof(authRef));

            AuthRef = authRef;
        }

        [JsonPropertyName("authRef")]
        public string AuthRef { get; }
    }
}