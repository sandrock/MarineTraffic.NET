
namespace MarineTrafficApi
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;

    public abstract class MarineTrafficBaseResult : IMarineTrafficResult
    {
        protected bool succeed;

        public MarineTrafficBaseResult()
        {
        }

        public bool Succeed
        {
            get { return this.succeed && (this.Errors == null || this.Errors.Count == 0); }
        }

        public IList<MarineTrafficError> Errors { get; set; } = new List<MarineTrafficError>();

        public abstract Task ReadHttpMessage(HttpResponseMessage resultMessage);
    }
}
