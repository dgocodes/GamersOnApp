namespace GamersOn.Domain.Entities;

public class GameEvaluation : Entity
{
    public int Rating { get; set; }

    public string? Description { get; set; }

    //public virtual Guid UserId { get; set; }

    //public virtual User User { get; set; } = new User();

    public virtual Guid GameId { get; set; }
}

