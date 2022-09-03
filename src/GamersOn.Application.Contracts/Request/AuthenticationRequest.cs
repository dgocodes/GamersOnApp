using GamersOn.Application.Commands.AuthenticationCommands;
using System.ComponentModel.DataAnnotations;

namespace GamersOn.Api.Contracts;

public class AuthenticationRequest
{

    [Required(ErrorMessage = "Informe o e-mail")]
    [RegularExpression("^[a-zA-Z0-9_.-]+@[a-zA-Z0-9-]+.[a-zA-Z0-9-.]+$", ErrorMessage = "Informe um e-mail válido")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Informe a senha")]
    [StringLength(30, ErrorMessage = "A senha deve ter entre {2} e {1} caracteres", MinimumLength = 8)]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    public LoginCommand ToLoginCommand()
    {
        return new LoginCommand
        {
            Email = Email,
            Password = Password
        };
    }
}
