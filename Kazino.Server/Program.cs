using Kazino.Server.Data;
using Kazino.Server.Interfaces;
using Kazino.Server.Repository;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("PSQLCon");
builder.Services.AddDbContext<KazinoContext>(options =>
options.UseNpgsql(connectionString));
/*builder.Services.AddDbContext<KazinoContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("PSQLCon"));
});*/
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles; // Или ReferenceHandler.IgnoreCycles - Но вместо этого, надо использовать DTO
    });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Host.UseSerilog((ctx, lc) => lc.ReadFrom.Configuration(ctx.Configuration));

builder.Services.AddScoped<IPromoRepository,PromoRepository>();

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();
