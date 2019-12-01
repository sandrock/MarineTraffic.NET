
namespace MarineTrafficApi
{
    using System.Threading.Tasks;

    public interface IMarineTrafficApiClient
    {
        string BaseUrl { get; }

        string ApiKey { get; set; }

        Task ExecuteAsync(IMarineTrafficRequest request, IMarineTrafficResult result);
    }
}
