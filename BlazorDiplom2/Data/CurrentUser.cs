using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;

namespace BlazorDiplom2.Data
{
    public static class CurrentUser
    {
        //public static LocalStorage LocalStorage { get; set; }

        public static AspNetUsers User { get; set; }

        public static string Role { get; private set; }

        public static async Task SetUserAsync(AuthenticationStateProvider authenticationStateProvider, UserManager<AspNetUsers> _userManager)
        {
            try // потом убрать
            {
                var authstate = await authenticationStateProvider.GetAuthenticationStateAsync();
                var user = authstate.User;
                User = await _userManager.GetUserAsync(user);
                if (User != null)
                {
                    var roles = await _userManager.GetRolesAsync(User);//.GetRoles(User.Id);
                    Role = roles.First();
                }
            }
            catch (Exception ex)
            {

            }
           
            
        }
    }
}
