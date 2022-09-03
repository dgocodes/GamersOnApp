using GamersOn.Application.Commands.UserCommands;
using System.ComponentModel.DataAnnotations;

namespace GamersOn.Api.Contracts;

public record struct UserRequest
{
    [Required(ErrorMessage = "Informe o nome")]
    [MaxLength(50, ErrorMessage = "A quantidade máxima de caracteres é {1}.")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Informe o e-mail")]
    [RegularExpression("^[a-zA-Z0-9_.-]+@[a-zA-Z0-9-]+.[a-zA-Z0-9-.]+$", ErrorMessage = "Informe um e-mail válido")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Informe a senha")]
    [StringLength(30, ErrorMessage = "A senha deve ter entre {2} e {1} caracteres", MinimumLength = 8)]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    public CreateUserCommand ToCreateUserCommand()
    {
        return new CreateUserCommand
        {
            Name = Name,
            Email = Email,
            Password = Password
        };    
    } 
}
