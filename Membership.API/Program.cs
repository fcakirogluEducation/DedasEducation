using Membership.API.Models;
using Membership.API.Requirements;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Authorization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer"));
});
builder.Services.AddIdentity<AppUser, AppRole>(options =>
{
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequiredLength = 4;

    options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789_@.";
    options.User.RequireUniqueEmail = true;

    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(15);
    options.Lockout.MaxFailedAccessAttempts = 5;
}).AddEntityFrameworkStores<AppDbContext>();

builder.Services.AddScoped<IdentityService>();
builder.Services.AddScoped<IAuthorizationHandler, BirthDateCheckRequirementHandler>();

builder.Services.AddAuthentication(option =>
{
    option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, option =>
{
    // imza
    // ömrü
    // aud
    // issuer
    var securityKey = builder.Configuration.GetSection("TokenOptions")["SecurityKey"]!;
    var audience = builder.Configuration.GetSection("TokenOptions")["Audience"]!;
    var issuer = builder.Configuration.GetSection("TokenOptions")["Issuer"]!;
    option.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidIssuer = issuer,
        ValidateAudience = true,
        ValidAudience = audience,
        ValidateLifetime = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey)),
        ValidateIssuerSigningKey = true
    };
});


builder.Services.AddAuthorization(option =>
{
    // claim based

    option.AddPolicy("CityWithIstanbulPolicy",
        configurePolicy => { configurePolicy.RequireClaim("city", "istanbul"); });

    option.AddPolicy("CityWithIstanbulPolicy2",
        configurePolicy => { configurePolicy.RequireClaim("city", "istanbul", "ankara", "erzurum"); });

    //Policy based
    option.AddPolicy("BirthDatePolicy",
        configurePolicy => { configurePolicy.AddRequirements(new BirthDateCheckRequirement() { Age = 20 }); });
});


var app = builder.Build();

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

app.Run();