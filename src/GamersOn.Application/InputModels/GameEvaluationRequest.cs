using System.ComponentModel.DataAnnotations;

namespace GamersOn.Application.InputModels;

public record struct GameEvaluationRequest
{
    [Range(1, 10, ErrorMessage = "O valor de avaliação deve estar entre {1} e {2}.")]
    public int Rating { get; set; }

    [MaxLength(500, ErrorMessage = "A quantidade máxima de caracteres é {1}.")]
    public string Description { get; set; }
}
