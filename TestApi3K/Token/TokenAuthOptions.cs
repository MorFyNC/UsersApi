using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace TestApi3K.Token
{
    public class AuthOptions
    {
        public const string ISSUER = "Me";
        public const string AUDIENCE = "BlazorApp";
        const string KEY = "tidfwopkp123u5h0ginq3042iq5jasdfawefwadfaetwtawfargaergp";
        public static SymmetricSecurityKey GetSymmetricSecurityKey() =>
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(KEY));
    }
}
