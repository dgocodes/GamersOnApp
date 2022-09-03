using GamersOn.Domain.Entities;

namespace GamersOn.Application.Contracts.Response;

public record struct LoginResponse(string Token, User User);
