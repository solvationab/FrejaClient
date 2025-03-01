using Refit;

namespace FrejaClient.Dto.AuthenticationService
{
    public class InitAuthenticationRequest
    {
        public InitAuthenticationRequest(InitAuthenticationRequestData data)
        {
            Data = data;
        }

        [AliasAs("initAuthRequest")]
        public InitAuthenticationRequestData Data { get; }
    }

    public class InitAuthenticationRequestData : Base64DtoBase
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

        [AliasAs("userInfoType")] public string UserInfoType { get; }

        [AliasAs("userInfo")] public string UserInfo { get; }

        [AliasAs("minRegistrationLevel")] public string MinRegistrationLevel { get; }

        [AliasAs("userConfirmationMethod")] public string UserConfirmationMethod { get; }

        [AliasAs("attributesToReturn")] public string[] AttributesToReturn { get; }
    }
}