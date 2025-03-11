using System.Text.Json.Serialization;

namespace FrejaClient.Dto.AuthenticationService
{
    public class InitAuthenticationRequest
    {
        public InitAuthenticationRequest(InitAuthenticationRequestData data)
        {
            Data = data;
        }

        [JsonPropertyName("initAuthRequest")]
        public InitAuthenticationRequestData Data { get; }
    }

    public class InitAuthenticationRequestData
    {
        public InitAuthenticationRequestData(
            string userInfoType,
            string userInfo,
            string minRegistrationLevel = null,
            string userConfirmationMethod = null,
            string[] attributesToReturn = null
        )
        {
            UserInfoType = userInfoType;
            UserInfo = userInfo;
            MinRegistrationLevel = minRegistrationLevel;
            UserConfirmationMethod = userConfirmationMethod;
            AttributesToReturn = attributesToReturn;
        }

        [JsonPropertyName("userInfoType")] public string UserInfoType { get; }

        [JsonPropertyName("userInfo")] public string UserInfo { get; }

        [JsonPropertyName("minRegistrationLevel")] public string MinRegistrationLevel { get; }

        [JsonPropertyName("userConfirmationMethod")] public string UserConfirmationMethod { get; }

        [JsonPropertyName("attributesToReturn")] public string[] AttributesToReturn { get; }
    }
}