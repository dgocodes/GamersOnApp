using ErrorOr;

namespace GamersOn.Domain.Common;

public static partial class Errors
{
    public static class Application
    {
        public static Error IdInvalid(Guid id, Guid correspondingId) => Error.Validation("Application.IdInvalid", $"ID {id} does not match {correspondingId}");

        public static Error NotFound(Guid id, string type) => Error.NotFound($"{type} Not Found", $"{type} {id} not found");

        public static Error NotFound(string type) => Error.NotFound($"{type} Not Found", $"{type} not found");
    }
}