using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using Store.BlazorClient.Models;
using Store.BlazorClient.Models.RequestModel;
using Store.BlazorClient.Services.Interfaces;
using System.Threading.Tasks;

namespace Store.BlazorClient.Pages.SignIn
{
    public partial class SignIn
    {
        [Inject] private ILocalStorageService _localStorageService { get; set; }
        [Inject] private NavigationManager _navigationManager { get; set; }
        [Inject] private IAccountService _accountService { get; set; }

        public SignIn()
        {
            SignData = new SignInViewModel();
        }
        public SignInViewModel SignData { get; set; }


        protected async Task SignInAsync()
        {
            var requestModel = new SignInRequestModel
            {
                Email = SignData.UserLogin,
                Password = SignData.Password
            };
            var result = await _accountService.SignInAsync(requestModel);

            var token = new TokenModel
            {
                AccessToken = result.AccessToken,
                RefreshToken = result.RefreshToken
            };
            await _localStorageService.SetItemAsync(nameof(TokenModel), token);
            _navigationManager.NavigateTo("/", true);
        }
    }
}
