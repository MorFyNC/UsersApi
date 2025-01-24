using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using TestApi3K.Model;
using TestApi3K.Requests;

namespace TestApi3K.Interfaces
{
    public interface IAuthService
    {
        Task<IActionResult> LoginAsync(LoginModel login);
    }
}
