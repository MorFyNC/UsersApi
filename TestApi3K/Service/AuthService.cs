using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using TestApi3K.DataBaseContext;
using TestApi3K.Interfaces;
using TestApi3K.Model;
using TestApi3K.Requests;
using TestApi3K.Token;

namespace TestApi3K.Service
{
    public class AuthService: IAuthService
    {
        public readonly ContextDb _context;
        
        public AuthService(ContextDb context)
        {
            _context = context;
        }

        public async Task<IActionResult> LoginAsync(LoginModel loginModel)
        {
            var existing = await _context.Logins.ToListAsync();
            var login = existing.FirstOrDefault(x => x.Login == loginModel.Login && x.Password == loginModel.Password);
            if (login is null)
            {
                return new OkObjectResult(new 
                { 
                    data = new data(),
                    status = false, 
                    Message = "Логин и/или пароль введены неверно" });
            }
            var user = await _context.Users.FirstOrDefaultAsync(x => x.id_User == login.User_id);

            return new OkObjectResult(new 
            {
                data = new data
                {
                    JWT = TokenGenerator.GenerateJwtToken(login.Login),
                    Role = user.Role,
                    Username = user.Name,
                },
                status = true, 
                Message = $"Успешный вход как '{user.Name}'" });
        }

        class data
        {
            public string JWT { get; set; }
            public string Role { get; set; }
            public string Username { get; set; }
            
        }
    }
}
