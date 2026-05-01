using System.ComponentModel.DataAnnotations;

namespace UserManagementApi.Models.Authentication.Signup
{
    public class RegisterUser
    {
        [Required(ErrorMessage ="Username is required")]
        public string? username{ get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "Email is required.")]
        public string? email { get; set; }


        [Required(ErrorMessage = "Password is required.")]
        public string? password { get; set; }


    }
}
