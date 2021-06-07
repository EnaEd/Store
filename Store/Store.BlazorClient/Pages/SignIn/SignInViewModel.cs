using System.ComponentModel.DataAnnotations;

namespace Store.BlazorClient.Pages.SignIn
{
    public class SignInViewModel
    {
        [Required(ErrorMessage = "field musn't be empty")]
        public string UserLogin { get; set; }
        [Required(ErrorMessage = "field musn't be empty")]
        public string Password { get; set; }
    }
}
