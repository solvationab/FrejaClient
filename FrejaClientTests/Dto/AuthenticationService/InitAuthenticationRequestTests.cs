using FluentAssertions;
using FrejaClient.Dto.AuthenticationService;

namespace FrejaClientTests.Dto.AuthenticationService
{
    [TestClass]
    public class InitAuthenticationRequestTests
    {
        [TestMethod]
        public void Create1()
        {
            var initAuthenticationRequest = new InitAuthenticationRequest(
                new InitAuthenticationRequestData(
                    "userInfoType",
                    "userInfo",
                    "minRegistrationLevel",
                    "userConfirmationMethod",
                    ["attributesToReturn"]
                    )
                );

            initAuthenticationRequest.Should().NotBeNull();
            initAuthenticationRequest.Data.Should().NotBeNull();
            initAuthenticationRequest.Data.UserInfoType.Should().Be("userInfoType");
            initAuthenticationRequest.Data.UserInfo.Should().Be("userInfo");
            initAuthenticationRequest.Data.MinRegistrationLevel.Should().Be("minRegistrationLevel");
            initAuthenticationRequest.Data.UserConfirmationMethod.Should().Be("userConfirmationMethod");
            initAuthenticationRequest.Data.AttributesToReturn.Should().BeEquivalentTo(["attributesToReturn"]);
        }

        [TestMethod]
        public void Create2()
        {
            var initAuthenticationRequest = new InitAuthenticationRequest(
                new InitAuthenticationRequestData(
                    "userInfoType",
                    "userInfo"
                    )
                );
            initAuthenticationRequest.Should().NotBeNull();
            initAuthenticationRequest.Data.Should().NotBeNull();
            initAuthenticationRequest.Data.UserInfoType.Should().Be("userInfoType");
            initAuthenticationRequest.Data.UserInfo.Should().Be("userInfo");
            initAuthenticationRequest.Data.MinRegistrationLevel.Should().BeNull();
            initAuthenticationRequest.Data.UserConfirmationMethod.Should().BeNull();
            initAuthenticationRequest.Data.AttributesToReturn.Should().BeNull();
        }
    }
}
