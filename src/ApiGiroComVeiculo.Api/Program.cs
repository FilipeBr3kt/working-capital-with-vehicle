using ApiGiroComVeiculo.Api.Common.Abstractions;
using ApiGiroComVeiculo.Api.Common.Repositories;
using ApiGiroComVeiculo.Api.Common.Utils;
using ApiGiroComVeiculo.Api.Database;
using ApiGiroComVeiculo.Api.Features.Parameters.GetParameters;
using ApiGiroComVeiculo.Api.Features.Protocol.CreateProtocol;
using ApiGiroComVeiculo.Api.Features.Protocol.GetProtocol;
using ApiGiroComVeiculo.Api.Middlewares;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen()
        .AddControllers();

    builder.Services.AddDbContext<DatabaseContext>(options =>
    {
        options.UseSqlServer(builder.Configuration.GetConnectionString(
            builder.Configuration.GetValue<string>("SecretsApi:ConnectionString")!));
    });

    builder.Services.AddMediatR(config => config.RegisterServicesFromAssembly(typeof(Program).Assembly));
    builder.Services.AddAutoMapper(typeof(MappingProfile));
    builder.Services.AddAuthentication(x =>
    {
        x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    }).AddJwtBearer(x =>
    {
        x.RequireHttpsMetadata = false;
        x.SaveToken = true;
        x.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(
                builder.Configuration.GetValue<string>("SecretsApi:SecretKey")!)),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });

    builder.Services
        .AddMemoryCache()
        .AddDistributedMemoryCache()
        .AddProblemDetails()
        .AddHttpContextAccessor()
        .AddExceptionHandler<ExceptionToProblemDetailsHandler>();

    builder.Services
        .AddScoped<IParametersRepository, GetParametersRepository>()
        .AddScoped<IGetProtocolRepository, GetProtocolRepository>()
        .AddScoped<IStoredProcedureRepository, StoredProceduresRepository>();
}
{
    var app = builder.Build();

    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    GetParametersEndpoint.AddRoutes(app);
    LoginEndpoint.AddRoutes(app);
    CreateProtocolEnpoint.AddRoutes(app);
    GetProtocolEndpoint.AddRoutes(app);
    TokenService.Configure(builder.Configuration);
    EmailSender.Configure(builder.Configuration);

    app.UseAuthentication();
    app.UseAuthorization();
    app.UseHttpsRedirection();
    app.UseExceptionHandler();
    app.Run();
}