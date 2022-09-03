using GamersOn.Domain.Entities;

namespace GamersOn.Application.OutputModels;

public record struct GameEvaluationResponse(Guid Id, int Rating, string? Description)
{
    public static GameEvaluationResponse FromGameEvaluation(GameEvaluation gameEvaluation)
    {
        return new GameEvaluationResponse
        {
            Id = gameEvaluation.Id,
            Description = gameEvaluation.Description,
            Rating = gameEvaluation.Rating
        };
    }

    public static List<GameEvaluationResponse> FromGameEvaluation(IList<GameEvaluation> gameEvaluation)
    {
        return gameEvaluation.Select(x => FromGameEvaluation(x))
                             .ToList();
    }
}
