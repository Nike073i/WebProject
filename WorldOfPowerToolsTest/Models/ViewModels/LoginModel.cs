using System.Net.Cache;
using System.ComponentModel.DataAnnotations;

namespace WorldOfPowerToolsTest.Models.ViewModels
{
    public class LoginModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [UIHint("Password")]
        public string Password { get; set; }

        public string ReturnUrl { get; set; } = "/";
    }
}