using Chaquitaclla_API_TSW.Crops.Application.CommandServices;
using  Chaquitaclla_API_TSW.Crops.Application.QueryServices;
using  Chaquitaclla_API_TSW.Crops.Domain.Repositories;
using  Chaquitaclla_API_TSW.Crops.Domain.Services;
using  Chaquitaclla_API_TSW.Crops.Infrastructure.Persistence.EFC.Repositories;
using Chaquitaclla_API_TSW.Forum.Application.CommandServices;
using Chaquitaclla_API_TSW.Forum.Application.QueryService;
using Chaquitaclla_API_TSW.Forum.Domain.Repositories;
using Chaquitaclla_API_TSW.Forum.Domain.Services;
using Chaquitaclla_API_TSW.Forum.Infrastructure.Persistence.EFC.Repositories;
using Chaquitaclla_API_TSW.IAM.Application.Internal.CommandServices;
using Chaquitaclla_API_TSW.IAM.Application.Internal.OutboundServices;
using Chaquitaclla_API_TSW.IAM.Application.Internal.QueryServices;
using Chaquitaclla_API_TSW.IAM.Domain.Repositories;
using Chaquitaclla_API_TSW.IAM.Domain.Services;
using Chaquitaclla_API_TSW.IAM.Infrastructure.Hashing.BCrypt.Services;
using Chaquitaclla_API_TSW.IAM.Infrastructure.Persistence.EFC.Repositories;
using Chaquitaclla_API_TSW.IAM.Infrastructure.Pipeline.Middleware.Extensions;
using Chaquitaclla_API_TSW.IAM.Infrastructure.Tokens.JWT.Configuration;
using Chaquitaclla_API_TSW.IAM.Infrastructure.Tokens.JWT.Services;
using Chaquitaclla_API_TSW.IAM.Interfaces.ACL;
using Chaquitaclla_API_TSW.IAM.Interfaces.ACL.Services;
using Chaquitaclla_API_TSW.Profiles.Application.Internal.CommandServices;
using Chaquitaclla_API_TSW.Profiles.Application.Internal.QueryServices;
using Chaquitaclla_API_TSW.Profiles.Domain.Repositories;
using Chaquitaclla_API_TSW.Profiles.Domain.Services;
using Chaquitaclla_API_TSW.Profiles.Infrastructure.Persistence.EFC.Repositories;
using Chaquitaclla_API_TSW.Shared.Domain.Repositories;
using  Chaquitaclla_API_TSW.Shared.Interfaces.ASP.Configuration;
using  Chaquitaclla_API_TSW.Shared.Infrastructure.Persistence.EFC.Configuration;
using  Chaquitaclla_API_TSW.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(options =>
{
    options.Conventions.Add(new KebabCaseRouteNamingConvention());
});


// Add Database Connection String
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Configure Database Context and Logging Level
builder.Services.AddDbContext<AppDbContext>(
    options =>
    {
        if (connectionString != null)
            if (builder.Environment.IsDevelopment())
                options.UseMySQL(connectionString)
                    .LogTo(Console.WriteLine, LogLevel.Information)
                    .EnableSensitiveDataLogging()
                    .EnableDetailedErrors();
            else if (builder.Environment.IsProduction())
                options.UseMySQL(connectionString)
                    .LogTo(Console.WriteLine, LogLevel.Error)
                    .EnableDetailedErrors();    
    });

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(
    c =>
    {
        c.SwaggerDoc("v1",
            new OpenApiInfo
            {
                Title = "Chaquitaclla_API_TSW",
                Version = "v1",
                Description = "Chaquitaclla Error 404 Platform API",
                TermsOfService = new Uri("https://github.com/upc-pre-202401-si730-ws53-Error-404/Web-Services"),
                Contact = new OpenApiContact
                {
                    Name = "Error 404 development team",
                    Email = "u202124343@upc."
                },
                License = new OpenApiLicense
                {
                    Name = "Apache 2.0",
                    Url = new Uri("https://www.apache.org/licenses/LICENSE-2.0.html")
                }
            });
        c.EnableAnnotations();
        c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        {
            In = ParameterLocation.Header,
            Description = "Please enter token",
            Name = "Authorization",
            Type = SecuritySchemeType.Http,
            BearerFormat = "JWT",
            Scheme = "bearer"
        });
        c.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Id = "Bearer",
                        Type = ReferenceType.SecurityScheme
                    }
                },
                Array.Empty<string>()
            } 
        });
    });


builder.Services.AddRouting(options => options.LowercaseUrls = true);

// Add CORS Policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowedAllPolicy",
        policy => policy
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
});

// Shared Bounded Context Dependency Injections
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

//Sowings Bounded Context Dependency Injections

builder.Services.AddScoped<ISowingRepository, SowingRepository>();
builder.Services.AddScoped<ISowingCommandService, SowingCommandService>();
builder.Services.AddScoped<ISowingQueryService, SowingQueryService>();

//Controls Bounded Context Dependency Injections

builder.Services.AddScoped<IControlRepository, ControlRepository>();
builder.Services.AddScoped<IControlCommandService, ControlCommandService>();
builder.Services.AddScoped<IControlQueryService, ControlQueryService>();

//Crops Bounded Context Dependency Injections

builder.Services.AddScoped<ICropRepository, CropRepository>();
builder.Services.AddScoped<ICropCommandService, CropCommandService>();
builder.Services.AddScoped<ICropQueryService, CropQueryService>();

builder.Services.AddScoped<IDiseaseRepository, DiseaseRepository>();
builder.Services.AddScoped<IDiseaseCommandService, DiseaseCommandService>();
builder.Services.AddScoped<IDiseaseQueryService, DiseaseQueryService>();

builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductCommandService, ProductCommandService>();
builder.Services.AddScoped<IProductQueryService, ProductQueryService>();

builder.Services.AddScoped<IPestRepository, PestRepository>();
builder.Services.AddScoped<IPestCommandService, PestCommandService>();
builder.Services.AddScoped<IPestQueryService, PestQueryService>();

builder.Services.AddScoped<ICareRepository, CareRepository>();
builder.Services.AddScoped<ICareCommandService, CareCommandService>();
builder.Services.AddScoped<ICareQueryService, CareQueryService>();

//Forum Bounded Context Dependency Injections
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ICategoryCommandService, CategoryCommandService>();
builder.Services.AddScoped<ICategoryQueryService, CategoryQueryService>();

builder.Services.AddScoped<IQuestionRepository, QuestionRepository>();
builder.Services.AddScoped<IQuestionCommandService, QuestionCommandService>();
builder.Services.AddScoped<IQuestionQueryService, QuestionQueryService>();

builder.Services.AddScoped<IAnswerRepository, AnswerRepository>();
builder.Services.AddScoped<IAnswerCommandService, AnswerCommandService>();
builder.Services.AddScoped<IAnswerQueryService, AnswerQueryService>();

// IAM Bounded Context Injection Configuration
builder.Services.Configure<TokenSettings>(builder.Configuration.GetSection("TokenSettings"));
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserCommandService, UserCommandService>();
builder.Services.AddScoped<IUserQueryService, UserQueryService>();
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<IHashingService, HashingService>();
builder.Services.AddScoped<IIamContextFacade, IamContextFacade>();

builder.Services.AddScoped<IControlRepository, ControlRepository>();
builder.Services.AddScoped<IControlCommandService, ControlCommandService>();
builder.Services.AddScoped<IControlQueryService, ControlQueryService>();

// Profiles Bounded Context Dependency Injections
builder.Services.AddScoped<IProfileRepository, ProfileRepository>();
builder.Services.AddScoped<IProfileCommandService, ProfileCommandService>();
builder.Services.AddScoped<IProfileQueryService, ProfileQueryService>();
builder.Services.AddScoped<ISubscriptionCommandService, SubscriptionCommandService>();
builder.Services.AddScoped<ISubscriptionRepository, SubscriptionRepository>();

builder.Services.AddScoped<IProductsBySowingRepository, ProductsBySowingRepository>();



var app = builder.Build();

// Verify Database Objects are created
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<AppDbContext>();
    context.Database.EnsureCreated();
}


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Apply CORS Policy
app.UseCors("AllowedAllPolicy");

app.UseRequestAuthorization();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
