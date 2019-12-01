
namespace MarineTrafficApi
{
    using System;

    public sealed class MarineTrafficError
    {
        public MarineTrafficError()
        {
        }

        public MarineTrafficError(string code, MarineTrafficErrorCode knownCode, string message, string line)
            : this(code, knownCode, message, line, null)
        {
        }

        public MarineTrafficError(MarineTrafficErrorCode knownCode, string message, string line, string detail)
            : this(knownCode.ToString(), knownCode, message, line, null)
        {
        }

        public MarineTrafficError(string code, MarineTrafficErrorCode knownCode, string message, string line, string detail)
        {
            this.Code = code;
            this.KnownCode = knownCode;
            this.Message = message;
            this.ErrorLine = line;
            this.Detail = detail;
        }

        public string Code { get; set; }

        public MarineTrafficErrorCode KnownCode { get; set; }

        public string Message { get; set; }

        /// <summary>
        /// For CSV results, this is the full error line.
        /// </summary>
        public string ErrorLine { get; set; }

        /// <summary>
        /// Gets a hint for the application developer. 
        /// </summary>
        public string Detail { get; set; }

        public override string ToString()
        {
            return "Error " + this.Code + " " + this.Message;
        }
    }
}