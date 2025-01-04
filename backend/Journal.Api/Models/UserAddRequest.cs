using Journal.Api.Service;
using Journal.Data.Models;

namespace Journal.Api.Models
{
    public class UserAddRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string PasswordVerification { get; set; }

        public User ToEntity()
        {
            return new User
            {
                Id = Guid.NewGuid(),
                Email = Email,
                Password = PasswordHasher.HashPassword(Password)
            };
        }
    }
}
