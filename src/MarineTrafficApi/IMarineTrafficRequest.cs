
namespace MarineTrafficApi
{
    using System.Net.Http;

    public interface IMarineTrafficRequest
    {
        void PrepareHttpMessage(IMarineTrafficApiClient client, HttpRequestMessage message);
    }
}