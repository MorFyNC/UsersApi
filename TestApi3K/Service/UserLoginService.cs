using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestApi3K.DataBaseContext;
using TestApi3K.Interfaces;
using TestApi3K.Model;
using TestApi3K.Requests;

namespace TestApi3K.Service
{
    public class UserLoginService : IUsersLoginsService
    {
        private readonly ContextDb _context;

        public UserLoginService(ContextDb context)
        {
            _context = context;
        }

        public async Task<IActionResult> GetAllUsersAsync()
        {
            var users = await _context.Users.ToListAsync();

            return new OkObjectResult(new
            {
                data = new { users = users },
                status = true
            });
        }

        public async Task<IActionResult> CreateNewUserAndLoginAsync(CreateNewUserAndLogin newUser)
        {
            var user = new Users()
            {
                Name = newUser.Name,
                Description = newUser.Description,
            };

            var login = new Logins()
            {
                User_id = user.id_User,
                Login = newUser.Login,
                Password = newUser.Password,
            };

            var existinglogins = await _context.Logins.ToListAsync();
            if (existinglogins.Any(x => x.Login.ToLower() == login.Login.ToLower()))
            {
                return new ConflictObjectResult(new { status = false, message = "Пользователь с таким логином уже существует" });
            }

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            await _context.Logins.AddAsync(login);
            await _context.SaveChangesAsync();

            return new OkObjectResult(new
            {
                status = true,
                message = "none"
            });
        }
    }
}
