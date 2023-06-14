using FluentValidation.AspNetCore;
using SozlukWebSitesi.Infrastructure.Persistence.Extensions;
using SozlukWebSitesiApi.Application.Extensions;
using SozlukWebSitesiApi.WebApi.Infrastructure.Extensions;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.


        builder.Services.AddControllers()
            .AddJsonOptions(opt =>
            {
                opt.JsonSerializerOptions.PropertyNamingPolicy = null;
            })
            .AddFluentValidation();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.ConfigureAuth(builder.Configuration);

        builder.Services.AddApplicationRegistration();
        builder.Services.AddInfrastructureRegistration(builder.Configuration);
       

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.ConfigureExceptionHandling(app.Environment.IsDevelopment());

        app.UseAuthentication();
        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}