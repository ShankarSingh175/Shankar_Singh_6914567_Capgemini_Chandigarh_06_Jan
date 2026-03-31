using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using log4net;
using log4net.Config;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// ====== Configure log4net safely ======
var logRepository = LogManager.GetRepository(Assembly.GetEntryAssembly()!);
XmlConfigurator.Configure(logRepository, new FileInfo("log4net.config"));

// ====== JWT Settings ======
var jwtKey = "ThisIsASecretKeyForJWTToken123!";
var key = Encoding.ASCII.GetBytes(jwtKey);

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key)
    };
});

builder.Services.AddControllers();

var app = builder.Build();

// ====== Middleware: Log every request ======
app.Use(async (context, next) =>
{
    var logger = LogManager.GetLogger(typeof(Program));
    logger.Info($"Request: {context.Request.Method} {context.Request.Path} at {DateTime.UtcNow}");
    await next();
});

app.UseAuthentication();
app.UseAuthorization();

// ====== Middleware: Handle Unauthorized / Forbidden ======
app.Use(async (context, next) =>
{
    await next();
    var logger = LogManager.GetLogger(typeof(Program));
    if (context.Response.StatusCode == 401)
        logger.Warn($"Unauthorized access to {context.Request.Path}");
    else if (context.Response.StatusCode == 403)
        logger.Warn($"Forbidden access to {context.Request.Path}");
});

app.MapControllers();

app.Run();