using expenseTrackerPOC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();


//builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
//    .AddJwtBearer(options =>
//{
//options.TokenValidationParameters = new TokenValidationParameters
//{
//ValidateIssuer = true,
//ValidateAudience = true,
//ValidateLifetime = true,
//ValidateIssuerSigningKey = true,
//ValidIssuer = builder.Configuration["JwtSettings:Issuer"],
//ValidAudience = builder.Configuration["JwtSettings:Audience"],
//IssuerSigningKey = new SymmetricSecurityKey(
//        Encoding.UTF8.GetBytes(builder.Configuration["JwtSettings:SecretKey"])),
//ClockSkew = TimeSpan.Zero
//};

//options.Events = new JwtBearerEvents
//{
//OnAuthenticationFailed = context =>
//{
//if (context.Exception.GetType() == typeof(SecurityTokenExpiredException))
//{
//context.Response.Headers.Add("Token-Expired", "true");
//}
//return Task.CompletedTask;
//}
//};
//});

// Use middleware


// Protected Controller
//[Authorize]
//[ApiController]
//public class UserController : ControllerBase
//{
//    [HttpGet("profile")]
//    public IActionResult GetProfile()
//    {
//        var userId = User.FindFirst("userId")?.Value;
//        var email = User.FindFirst(ClaimTypes.Email)?.Value;
//        // Use claims data
//    }
//}