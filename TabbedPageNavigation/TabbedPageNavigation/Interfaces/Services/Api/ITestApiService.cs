using System.Threading;
using System.Threading.Tasks;

using Refit;

namespace TabbedPageNavigation.Interfaces.Services.Api
{
    [Headers("Content-Type: application/json;encoding=UTF-8")]
    public interface ITestApiService
    {
        [Get("/api/test")]
        Task TestApiAsync(CancellationToken cancellationToken);
    }
}