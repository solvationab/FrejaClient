using FrejaClient.Dto.AuthenticationService;
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
        Task<GetOneResultResponse> GetOneResult([Body] GetOneResultRequest request);

        [Post("/authentication/1.0/getResults")]
        Task<GetResultsResponse> GetResults([Body] GetResultsRequest request);

        [Post("/authentication/1.0/cancel")]
        Task<CancelResponse> Cancel([Body] CancelRequest request);
        #endregion

        #region Signature Service
        #endregion

        #region Organisation ID Service
        #endregion

        #region Custodianship Service
        #endregion

        #region Custom Identifier Management
        #endregion
    }
}
