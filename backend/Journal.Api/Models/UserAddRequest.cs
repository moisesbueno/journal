using Journal.Api.Service;
using Journal.Domain.Entities;

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
                Email = Email,
                Password = PasswordHasher.HashPassword(Password)
            };
        }
    }
}