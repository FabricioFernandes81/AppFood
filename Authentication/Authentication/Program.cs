using Authentication;
using Authentication.Configurations;
using Domain.Models;
using Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddOpenApi(); // Swagger
builder.Services.AddDbContext<ContextServer>(options => options.UseSqlServer(connectionString: @"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=AutenticationServer;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False")
                 .EnableSensitiveDataLogging()
                 .LogTo(Console.WriteLine, LogLevel.Information));


builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<ContextServer>()
    .AddDefaultTokenProviders();

builder.Services.AddIdentityServer(options =>
{
    options.Events.RaiseErrorEvents = true;
    options.Events.RaiseInformationEvents = true;
    options.Events.RaiseFailureEvents = true;
    options.Events.RaiseSuccessEvents = true;

    // options.Logging.EndpointDetailErrors = true;
})
    .AddInMemoryIdentityResources(Config.IdentityResources)
    .AddInMemoryApiScopes(Config.ApiScopes)
    .AddInMemoryClients(Config.Clients)
    .AddAspNetIdentity<ApplicationUser>()
    .AddDeveloperSigningCredential();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "IdentityServer4 API", Version = "v1" });

    c.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        Type = SecuritySchemeType.OAuth2,
        Flows = new OpenApiOAuthFlows
        {
            
            Password = new OpenApiOAuthFlow
            {
                TokenUrl = new Uri("/connect/token", UriKind.Relative), 
               /* Scopes = new Dictionary<string, string>
                {
                    { "api1", "Minha API de Exemplo" },
                    { "openid", "OpenId Scope" },
                    { "profile", "Profile Scope" },
                    { "offline","offline_access" }
                }*/
            },
            // Opcional: Flow para Authorization Code com PKCE (recomendado)
            AuthorizationCode = new OpenApiOAuthFlow
            {
                AuthorizationUrl = new Uri("/connect/authorize", UriKind.Relative),
                TokenUrl = new Uri("/connect/token", UriKind.Relative),
               /* Scopes = new Dictionary<string, string>
                {
                    { "api1", "Minha API de Exemplo" },
                    { "openid", "OpenId Scope" },
                    { "profile", "Profile Scope" }
                }*/
            }
        },
        Description = "Fluxo OAuth2/OIDC para autenticação e autorização."
    });

    // Adiciona o requisito de segurança global para todas as operações
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "oauth2"
                }
            },
            new List<string> ()//{ "api1", "openid", "profile" } // Escopos padrão para este requisito
        }
    });
});


builder.Services.AddEndpointsApiExplorer();

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy",
        builder => builder.AllowAnyOrigin()
                          .AllowAnyMethod()
                          .AllowAnyHeader());

});


// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
//builder.Services.AddOpenApi();
builder.Services.AddScoped<DatabaseIdentityServerInitializer>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "IdentityServer4 API V1");
        c.RoutePrefix = "swagger"; // Define a rota para acessar o Swagger UI (ex: /swagger)

        // Configurações para OAuth2 no Swagger UI
        c.OAuthClientId("ropc.client"); // ID do cliente configurado no IdentityServer (para ROPC)
        // c.OAuthClientId("spa.client"); // ID do cliente para Authorization Code Flow
      //  c.OAuthScopes("openid", "profile", "api1"); // Escopos solicitados
        c.OAuthUsePkce(); // Habilita PKCE se estiver usando Authorization Code Flow
        c.OAuthClientSecret("secret"); // Segredo do cliente para ROPC (NÃO use para clientes públicos como SPA/Mobile)
    });
}


app.UseCors("CorsPolicy");
app.UseHttpsRedirection();

app.UseIdentityServer();

app.UseAuthorization();

app.MapControllers();

SeedDatabase(app);

app.Run();


void SeedDatabase(IApplicationBuilder app)
{
    using (var scope = app.ApplicationServices.CreateScope())
    {
       var initRoles = scope.ServiceProvider.GetRequiredService<DatabaseIdentityServerInitializer>();
        initRoles.InitializeSeedRoles();
        initRoles.InitializeSeedUsers();
    }
}