using GamersOn.Api;
using GamersOn.Application;
using GamersOn.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddPresentention(builder.Configuration)
                .AddApplication()
                .AddInfrastructure(builder.Configuration);


var app = builder.Build();
{
    //app.UseMiddleware<ErrorHandlingMiddlware>();
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseHttpsRedirection();
    app.UseAuthentication();
    app.UseAuthorization();
    app.MapControllers();
    app.Run();
}