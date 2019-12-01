
namespace MarineTrafficApi
{
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;

    public interface IMarineTrafficResult
    {
        bool Succeed { get; }

        IList<MarineTrafficError> Errors { get; }

        Task ReadHttpMessage(HttpResponseMessage resultMessage);
    }
}