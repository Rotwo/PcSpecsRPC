using PcSpecsRPC.Client.Common.Requests;
using PcSpecsRPC.Client.Common.Responses;

namespace PcSpecsRPC.Client.Common.Interfaces
{
    public interface IApiClient
    {
        Task<SpecResultResponse> SendSpecsAsync(SendSpecRequest request);
    }
}
