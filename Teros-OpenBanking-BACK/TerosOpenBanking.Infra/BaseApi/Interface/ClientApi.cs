using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace TerosOpenBanking.Infra.BaseApi.Interface
{
    public class ClientApi : IClientApi
    {
        private readonly HttpClient _httpClient;

        public ClientApi(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> SendPostAsync(string url)
        {
            var response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
               return await response.Content.ReadAsStringAsync();
            }

            return string.Empty;
        }
    }
}
