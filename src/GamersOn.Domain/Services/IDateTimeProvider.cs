namespace GamersOn.Domain.Services;

public interface IDateTimeProvider
{
    DateTime UtcNow { get; }
}