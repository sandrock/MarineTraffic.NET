
namespace MarineTrafficApi.Internals
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public static class Constants
    {
        internal static readonly Dictionary<string, string> errorCodeDetails;
        internal static readonly Dictionary<string, MarineTrafficErrorCode> errorCodes;

        static Constants()
        {
            errorCodeDetails = new Dictionary<string, string>();
            errorCodes = new Dictionary<string, MarineTrafficErrorCode>();

            errorCodeDetails.Add("1", Messages.ErrorDetailCode1);
            errorCodeDetails.Add("10", Messages.ErrorDetailCode10);

            errorCodes.Add("1", MarineTrafficErrorCode.IncorrectCallCheckParameters);
            errorCodes.Add("10", MarineTrafficErrorCode.ServiceKeyNotFound);
            errorCodes.Add("5a2", MarineTrafficErrorCode.InsufficientCredits);
        }
    }
}
