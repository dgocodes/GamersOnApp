using GamersOn.Domain.Entities;

namespace GamersOn.Application.OutputModels;

public record struct LoginResponse(string Token, UserResponse? User);