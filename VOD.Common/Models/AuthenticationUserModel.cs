

namespace VOD.Common.Models
{
    public class AuthenticationUserModel
    {
        [Required(ErrorMessage = "Du måste ange Email!")]
        public string Email { get; set; } = string.Empty;
        [Required(ErrorMessage = "Du måste ange Lösenord!")]
        public string Password { get; set; } = string.Empty;
    }
}
