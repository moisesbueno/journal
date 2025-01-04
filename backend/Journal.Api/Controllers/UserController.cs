using Journal.Api.Models;
using Journal.Api.Repositories;
using Journal.Api.Service;
using Journal.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Crypto.Generators;

namespace Journal.Api.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpPost("")]
        public async Task<IActionResult> AddAsync([FromBody] UserAddRequest userAddRequest)
        {
            await _userRepository.AddAsync(userAddRequest.ToEntity());
            return Ok();
        }

        [HttpPost("auth")]
        public async Task<IActionResult> AuthAsync([FromBody] UserAuthRequest userAuthRequest)
        {
            var user = await _userRepository.GetUserByEmailAsync(userAuthRequest.Email);

            if (user is null)
                return NotFound();

            var passWordIsValid = PasswordHasher.VerifyPassword(userAuthRequest.Password, user.Password);

            if (passWordIsValid)
            {
                await _userRepository.UpdatePassWordHashAsync(user.Email, userAuthRequest.Password);
                return Ok(user);
            }
            else
            {
                return NotFound();
            }
        }
    }

}
