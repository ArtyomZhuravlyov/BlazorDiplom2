using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
//@inject DB _db;
//@inject UserManager<AspNetUsers> _userManager;
//@inject AuthenticationStateProvider GetAuthenticationStateAsync

namespace BlazorDiplom2.Data
{
    public class Service
    {

        private readonly UserManager<AspNetUsers> _userManager;
        private readonly AuthenticationStateProvider _getAuthenticationStateAsync;
        public AspNetUsers CurrentAspNetUser { get;set; }

        public Service(UserManager<AspNetUsers> userManager, AuthenticationStateProvider getAuthenticationStateAsync)
        {
            _userManager = userManager;
            _getAuthenticationStateAsync = getAuthenticationStateAsync;

            CurrentAspNetUser = GetCurrentUserAsync().Result;
        }

        

        private async Task<AspNetUsers> GetCurrentUserAsync()
        {
            //if (currentAspNetUser == null)
            //{
                var authstate = await _getAuthenticationStateAsync.GetAuthenticationStateAsync();
                var user = authstate.User;
                var aspUser = await _userManager.GetUserAsync(user);
            //}
            return aspUser;
        }
    }
}
