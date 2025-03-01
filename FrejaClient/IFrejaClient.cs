using FrejaClient.Dto.AuthenticationService;
using Refit;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace FrejaClient
{
    public interface IFrejaClient
    {
        #region Authentication Service
        [Post("/authentication/1.0/initAuthentication")]
        Task<InitAuthenticationResponse> InitAuthentication([Body] InitAuthenticationRequest request);

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

    public class Base64EncoderDelegatingHandler : DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            //request.Content = new StreamContent(
            //    new CryptoStream(
            //        await request.Content.ReadAsStreamAsync(), 
            //        new ToBase64Transform(), 
            //        CryptoStreamMode.Write)
            //    );

            // TODO: Use ReadAsByteArray instead?
            var json = await request.Content.ReadAsStringAsync();

            var bytes = System.Text.Encoding.UTF8.GetBytes(json);

            var base64 = System.Convert.ToBase64String(bytes);

            request.Content = new StringContent(base64, System.Text.Encoding.UTF8, "application/json");

            return await base.SendAsync(request, cancellationToken);
        }
    }
}
