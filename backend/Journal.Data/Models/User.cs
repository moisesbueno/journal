

namespace Journal.Data.Models;

public partial class User
{
    public Guid Id { get; set; }

    public string Email { get; set; }

    public string Password { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }
}
