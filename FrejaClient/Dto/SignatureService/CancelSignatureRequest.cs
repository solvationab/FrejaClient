using System.Text.Json.Serialization;

namespace FrejaClient.Dto.SignatureService
{
    /// <summary>
    /// Request object for cancelling a signature
    /// </summary>
    public class CancelSignatureRequest
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="signRef"></param>
        public CancelSignatureRequest(string signRef)
        {
            SignRef = signRef;
        }

        /// <summary>
        /// The value must be equal to a signature reference previously returned from a call to the Initiate sign method.
        /// 
        /// Mandatory
        /// </summary>
        [JsonPropertyName("signRef")]
        public string SignRef { get; }
    }
}