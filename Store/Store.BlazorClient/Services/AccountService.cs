using Store.BlazorClient.Models;
using Store.BlazorClient.Models.RequestModel;
using Store.BlazorClient.Services.Interfaces;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;

namespace Store.BlazorClient.Services
{
    public class AccountService : IAccountService
    {
        private readonly HttpClient _httpClient;

        public AccountService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<TokenModel> SignInAsync(SignInRequestModel model)
        {

            var response = await _httpClient.PostAsJsonAsync("https://localhost:44317/api/Account/signin", model);
            string content = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<TokenModel>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            return result;
        }
    }
}
