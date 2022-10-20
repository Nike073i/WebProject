using Microsoft.AspNetCore.Identity;

namespace WorldOfPowerToolsTest.Models
{
    public static class IdentitySeedData
    {
        private const string _AdminUser = "Admin";
        private const string _AdminPassword = "Secret123$";

        public static async void EnsurePopulated(UserManager<IdentityUser> userManager)
        {
            var user = await userManager.FindByIdAsync(_AdminUser);
            if (user == null)
            {
                user = new IdentityUser(_AdminUser);
                await userManager.CreateAsync(user, _AdminPassword);
            }
        }
    }
}