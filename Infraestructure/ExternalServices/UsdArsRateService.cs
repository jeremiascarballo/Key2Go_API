using Application.Abstraction.ExternalService;
using Contract.External.DolarRate.Response;
using System.Net.Http.Json;

namespace Infraestructure.ExternalServices
{
    public class UsdArsRateService : IUsdArsRateService
    {
        private readonly IHttpClientFactory _clientFactory;

        public UsdArsRateService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<decimal?> GetUsdArsRateAsync()
        {
            var client = _clientFactory.CreateClient("DolarApi");

            var response = await client.GetFromJsonAsync<DolarRateResponse>("dolares/oficial");

            return response?.Venta;
        }
    }
}
