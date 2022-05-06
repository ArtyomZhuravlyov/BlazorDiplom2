using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;

namespace BlazorDiplom2.Data
{
    public static class CurrentUser
    {
        //public static LocalStorage LocalStorage { get; set; }

        public static AspNetUsers User { get; set; }

        public static async void SetUserAsync(AuthenticationStateProvider authenticationStateProvider, UserManager<AspNetUsers> _userManager)
        {
            var authstate = await authenticationStateProvider.GetAuthenticationStateAsync();
            var user = authstate.User;
            User = await _userManager.GetUserAsync(user);
        }
    }
}
