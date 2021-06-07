using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Store.BlazorClient.Models;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Store.BlazorClient
{
    public class StoreAuthStateProvider : AuthenticationStateProvider
    {
        private readonly ILocalStorageService _localStorageService;

        public StoreAuthStateProvider(ILocalStorageService localStorageService)
        {
            _localStorageService = localStorageService;
        }
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var token = await _localStorageService.GetItemAsync<TokenModel>(nameof(TokenModel));
            if (token is null)
            {
                var anonymous = new ClaimsIdentity();
                var anonymousPrincipal = new ClaimsPrincipal(anonymous);
                return new AuthenticationState(anonymousPrincipal);
            }


            //TODO EE: parse access token to get real data
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name,token.AccessToken)
            };

            var identity = new ClaimsIdentity(claims, "Bearer");
            var principal = new ClaimsPrincipal(identity);
            return new AuthenticationState(principal);

        }
    }
}
