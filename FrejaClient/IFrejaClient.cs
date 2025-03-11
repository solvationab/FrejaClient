using FrejaClient.Dto.AuthenticationService;
using FrejaClient.Dto.SignatureService;
using Refit;
using System.Threading.Tasks;

namespace FrejaClient
{
    public interface IFrejaClient
    {
        #region Authentication Service
        [Post("/authentication/1.0/initAuthentication")]
        Task<InitAuthenticationResponse> InitAuthentication([Body(BodySerializationMethod.UrlEncoded)] InitAuthenticationRequest request);

        [Post("/authentication/1.0/getOneResult")]
        Task<GetOneAuthenticationResultResponse> GetOneAuthenticationResult([Body(BodySerializationMethod.UrlEncoded)] GetOneAuthenticationResultRequest request);

        [Post("/authentication/1.0/getResults")]
        Task<GetAuthenticationResultsResponse> GetAuthenticationResults([Body(BodySerializationMethod.UrlEncoded)] GetAuthenticationResultsRequest request);

        [Post("/authentication/1.0/cancel")]
        Task<CancelAuthenticationResponse> CancelAuthentication([Body(BodySerializationMethod.UrlEncoded)] CancelAuthenticationRequest request);
        #endregion

        #region Signature Service
        [Post("/sign/1.0/initSignature")]
        Task<InitSignatureResponse> InitSignature([Body(BodySerializationMethod.UrlEncoded)] InitSignatureRequest request);

        [Post("/sign/1.0/getOneResult")]
        Task<GetOneSignatureResultResponse> GetOneSignatureResult([Body(BodySerializationMethod.UrlEncoded)] GetOneSignatureResultRequest request);

        [Post("/sign/1.0/getResults")]
        Task<GetSignatureResultsResponse> GetSignatureResults([Body(BodySerializationMethod.UrlEncoded)] GetSignatureResultsRequest request);

        [Post("/sign/1.0/cancel")]
        Task<CancelSignatureResponse> CancelSignature([Body(BodySerializationMethod.UrlEncoded)] CancelSignatureRequest request);
        #endregion

        #region Organisation ID Service
        #endregion

        #region Custodianship Service
        #endregion

        #region Custom Identifier Management
        #endregion
    }
}
