using Kazino.Server.Data;
using Kazino.Server.Interfaces;
using Kazino.Server.Repository;
using Kazino.Server.Servies.Promo;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using System.Text;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("PSQLCon");
builder.Services.AddDbContext<KazinoContext>(options =>
options.UseNpgsql(connectionString));
/*builder.Services.AddDbContext<KazinoContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("PSQLCon"));
});*/
builder.Services.AddControllers();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidAudience = builder.Configuration["KaziniAudience"],
            ValidIssuer = builder.Configuration["KazinoIssuer"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["KazinoSecretKey"]))
        };
    });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Host.UseSerilog((ctx, lc) => lc.ReadFrom.Configuration(ctx.Configuration));

builder.Services.AddScoped<IPromoRepository,PromoRepository>();
builder.Services.AddScoped<IPromoServies,PromoServies>();
//builder.Services.AddScoped<PromoServies>();

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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();
