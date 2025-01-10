namespace Journal.Domain.Entities;

public partial class User : Entity
{
    public string Email { get; set; }

    public string Password { get; set; }
}