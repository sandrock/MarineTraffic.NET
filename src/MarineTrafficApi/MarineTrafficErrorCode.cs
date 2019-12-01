
namespace MarineTrafficApi
{
    public enum MarineTrafficErrorCode
    {
        /// <summary>
        /// The default error code. 
        /// </summary>
        Unknown = 0,

        /// <summary>
        /// Error emited by the library when data is incorrect in a response body.
        /// </summary>
        DataParseError = -2,

        /// <summary>
        /// Error emited by the library when the result error cannot be parsed.
        /// </summary>
        FailedToParseError = -1,

        /// <summary>
        /// MT error: the request is incorrect. Have you specified an API key? 
        /// </summary>
        IncorrectCallCheckParameters = 1,

        /// <summary>
        /// MT error: missing API key.
        /// </summary>
        ServiceKeyNotFound = 10,

        /// <summary>
        /// MT error: too many credits are required to fulfil this API call.
        /// </summary>
        InsufficientCredits = 5002,
    }
}
