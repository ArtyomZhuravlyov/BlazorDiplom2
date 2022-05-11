using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;

namespace BlazorDiplom2.Data
{
    public static class CurrentUser
    {
        //public static LocalStorage LocalStorage { get; set; }

        public static AspNetUsers User { get; set; }

        public static string Role { get; set; }

        //public static async Task SetUserAsync(AuthenticationStateProvider authenticationStateProvider, UserManager<AspNetUsers> userManager)
        //{
        //    try // потом убрать
        //    {
        //        var authstate = await authenticationStateProvider.GetAuthenticationStateAsync();
        //        var user = authstate.User;
        //        User = await userManager.GetUserAsync(user);
        //        if (User != null)
        //        {
        //            var roles = await userManager.GetRolesAsync(User);//.GetRoles(User.Id);
        //            Role = roles.First();
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //    }


        //}

        public static async Task SetUserAsync()
        {

        }
    }
}
