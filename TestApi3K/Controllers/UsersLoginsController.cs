using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TestApi3K.Interfaces;
using TestApi3K.Requests;

namespace TestApi3K.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class UsersLoginsController
    {
        private readonly IUsersLoginsService _userLoginService;

        public UsersLoginsController(IUsersLoginsService userLoginService)
        {
            _userLoginService = userLoginService;
        }

        [HttpGet]
        [Route("getAllUsers")]
        public async Task<IActionResult> GetAllUsers()
        {
            Console.WriteLine("Обращение");
            return await _userLoginService.GetAllUsersAsync();
        }

        [HttpPost]
        [Route("createNewUserAndLogin")]
        public async Task<IActionResult> CreateNewUserAndLogin(CreateNewUserAndLogin newUser)
        {
            return await _userLoginService.CreateNewUserAndLoginAsync(newUser);
        }

        
    }
}
