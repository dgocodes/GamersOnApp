﻿using ErrorOr;
using GamersOn.Application.OutputModels;
using MediatR;

namespace GamersOn.Application.Commands.UserCommands;

public record struct CreateUserCommand(string Name,
                                       string Email,
                                       string Password) : IRequest<ErrorOr<UserResponse>>;

