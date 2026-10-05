using AOAHub.Db;
using Microsoft.EntityFrameworkCore;

internal class Program
{
    private static void Main(string[] args)
    {
        WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddDbContext<AOAContext>(options =>
        {
            options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
        });

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddHealthChecks();

        builder.Services.AddCors(options =>
        {
            options.AddPolicy("UI", policy => policy
                .WithOrigins("http://localhost:5277", "https://localhost:7279")
                .AllowAnyHeader()
                .AllowAnyMethod());
        });

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        // No HTTPS redirection: Caddy terminates TLS and talks to Kestrel over plain http on localhost.
        // CORS only matters in dev; in production the UI and API share an origin via the proxy.
        app.UseCors("UI");

        app.MapHealthChecks("/status");

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}