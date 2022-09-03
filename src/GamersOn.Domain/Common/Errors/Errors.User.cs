using ErrorOr;

namespace GamersOn.Domain.Common;

public static partial class Errors
{
    public static class User
    {
        public static Error EmailAlreadyRegistered(string email) => Error.Validation("User.EmailAlreadyRegistered", $"E-mail {email} já está cadastrado.");

    }
}