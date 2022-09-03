using GamersOn.Domain.Entities;

namespace GamersOn.Application.OutputModels;
public record struct GameResponse(Guid Id, string Name, string Description, List<GameEvaluationResponse> Evaluations)
{
    public static GameResponse FromGame(Game game)
    {
        var gameResponse = new GameResponse
        {
            Id = game.Id,
            Name = game.Name,
            Description = game.Description
        };

        if (game.Evaluations.Any())
        {
            gameResponse.Evaluations = GameEvaluationResponse.FromGameEvaluation(game.Evaluations);
        }

        return gameResponse;
    }

    public static IEnumerable<GameResponse> FromGame(IEnumerable<Game> games)
    {
        return games.Select(x => FromGame(x)).ToList();
    }
}