using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace TestApi3K.Model
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Login is required")]
        [JsonPropertyName("Login")]
        public string Login { get; set; }

        [JsonPropertyName("Password")]
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
    }
}
