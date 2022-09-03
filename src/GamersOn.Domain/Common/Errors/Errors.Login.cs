using ErrorOr;

namespace GamersOn.Domain.Common;

public static partial class Errors
{
    public static class Login
    {
        public static Error IsBanned() => Error.Validation("Auth.Banned", $"Seu usuário está banido, contate o suporte.");

        public static Error InvalidCredentials() => Error.Validation("Auth.InvalidCredentials", $"E-mail ou senha inválidos");
    }
}