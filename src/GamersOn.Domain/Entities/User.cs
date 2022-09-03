namespace GamersOn.Domain.Entities;

public class User : Entity
{
    public string Name { get; set; }

    public string Email { get; set; }

    public byte[] PasswordHash { get; set; }

    public byte[] PasswordSalt { get; set; }

    public bool IsBanned { get; set; } = false;

    public void Ban()
    {
        IsBanned = true;
    }

    public void Unban()
    {
        IsBanned = false;
    }
}

