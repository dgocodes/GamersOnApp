namespace GamersOn.Domain.Entities;

public abstract class Entity
{
    public Guid Id { get; private set; } = Guid.NewGuid();

    public bool Active { get; protected set; } = true;
}
