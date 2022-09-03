using GamersOn.Application.Commands.GameCommands;
using System.ComponentModel.DataAnnotations;

namespace GamersOn.Api.Contracts;

public record struct GameRequest
{
    [Required(ErrorMessage = "O nome deve ser informado")]
    [MaxLength(50, ErrorMessage = "A quantidade máxima de caracteres é {1}.")]
    public string Name { get; set; }

    [MaxLength(500, ErrorMessage = "A quantidade máxima de caracteres é {1}.")]
    public string Description { get; set; }

    public CreateGameCommand ToCreateGameCommand()
    {
        return new CreateGameCommand
        {
            Name = Name,
            Description = Description
        };
    }

    public UpdateGameCommand ToUpdateGameCommand(Guid id)
    {
        return new UpdateGameCommand
        {
            Id = id,
            Name = Name,
            Description = Description
        };
    }
}
