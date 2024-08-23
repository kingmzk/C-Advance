using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using Config.Demo;
using System.Reflection.PortableExecutable;

public class Program
{
    public static void Main(string[] args)
{
    var builder = WebApplication.CreateBuilder(args);

    // Access Configuration
    var configuration = builder.Configuration;
    var version = configuration.GetValue<string>("version");
    var dataBase = configuration["Settings:Database"];
    Console.WriteLine($"Version: {version}"); // Print version in console
    Console.WriteLine($"Database setting: {dataBase}"); // Print database setting in console

    builder.Services.AddSingleton(version);
    builder.Services.Configure<Custom>(configuration.GetSection("Custom"));
    builder.Services.AddSingleton<IConfiguration>(builder.Configuration);

    // Add controllers, Swagger, etc.
    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    var app = builder.Build();

    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();
    app.UseAuthorization();
    app.MapControllers();

    app.Run();

        //CreateHostBuilder(args).Build().Run();
    }



    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.ConfigureAppConfiguration((hostingContext, config) =>
                {
                    var replacement = new Dictionary<string, string>
                    {
                    { "-v", "Version" }
                    };
                    config.AddCommandLine(args, replacement);
                });
                webBuilder.UseStartup<Program>();
            });

}
