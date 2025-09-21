using PcSpecsRPC.Client.Common.Contracts;
using PcSpecsRPC.Client.Common.Interfaces;
using PcSpecsRPC.Client.Common.Requests;
using PcSpecsRPC.Client.Common.Responses;
using System.Net.Http.Json;

namespace PcSpecsRPC.Client.Common.Services
{
    public class ApiClient : IApiClient
    {
        private readonly HttpClient _httpClient;

        public ApiClient(string baseUrl)
        {
            _httpClient = new HttpClient { BaseAddress = new Uri(baseUrl) };
        }

        public async Task<SpecResultResponse> SendSpecsAsync(SendSpecRequest request)
        {
            var response = await _httpClient.PostAsJsonAsync(Endpoints.PcSpecs, request);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<SpecResultResponse>();
        }
    }
}
