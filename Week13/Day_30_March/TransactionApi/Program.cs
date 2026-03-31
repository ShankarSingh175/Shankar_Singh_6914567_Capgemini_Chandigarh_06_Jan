using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using AutoMapper;

// 🔹 Create builder
var builder = WebApplication.CreateBuilder(args);

// 🔹 Add Controllers
builder.Services.AddControllers();

// 🔹 Configure CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

// 🔹 Configure SQLite (Local Database File)
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=transactions.db"));

// 🔹 Configure AutoMapper
builder.Services.AddAutoMapper(typeof(Program));

// 🔐 JWT Configuration
var jwtKey = builder.Configuration["Jwt:Key"] 
             ?? "ThisIsASuperSecretKeyThatIsAtLeast32Chars!";
var key = Encoding.ASCII.GetBytes(jwtKey);

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false; // ⚠️ true in production
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false,
        ValidateAudience = false,
        ClockSkew = TimeSpan.Zero
    };
});

// 🔹 Authorization
builder.Services.AddAuthorization();

// 🔹 Swagger + JWT Support
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
    {
        Description = "Enter JWT as: Bearer {your token}",
        Name = "Authorization",
        In = Microsoft.OpenApi.Models.ParameterLocation.Header,
        Type = Microsoft.OpenApi.Models.SecuritySchemeType.Http,
        Scheme = "bearer"
    });

    options.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
    {
        {
            new Microsoft.OpenApi.Models.OpenApiSecurityScheme
            {
                Reference = new Microsoft.OpenApi.Models.OpenApiReference
                {
                    Type = Microsoft.OpenApi.Models.ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});

var app = builder.Build();

// 🔹 Middleware Pipeline
app.UseCors("AllowAll");


    app.UseSwagger();
    app.UseSwaggerUI();



// 🔐 Authentication & Authorization
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

// 🔹 Seed database
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.EnsureCreated();

    if (!db.Users.Any())
    {
        var user1 = new User { Username = "john", PasswordHash = PasswordHasher.Hash("123456") };
        var user2 = new User { Username = "alice", PasswordHash = PasswordHasher.Hash("123456") };

        db.Users.AddRange(user1, user2);
        db.SaveChanges();

        var transactions = new List<Transaction>
        {
            new Transaction { UserId = user1.Id, Amount = 100, Date = DateTime.Now.AddDays(-2), Type = "Credit" },
            new Transaction { UserId = user1.Id, Amount = 50, Date = DateTime.Now.AddDays(-1), Type = "Debit" },
            new Transaction { UserId = user2.Id, Amount = 200, Date = DateTime.Now.AddDays(-3), Type = "Credit" },
            new Transaction { UserId = user2.Id, Amount = 30, Date = DateTime.Now, Type = "Debit" }
        };

        db.Transactions.AddRange(transactions);
        db.SaveChanges();
    }
}

// 🔹 Run Kestrel on port 5000
app.Run();