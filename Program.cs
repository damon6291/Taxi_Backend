using Taxi_Backend.Services;
using System.Text;
using Taxi_Backend.Data;
using Microsoft.EntityFrameworkCore;
using Taxi_Backend.Managers;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using Microsoft.AspNetCore.Identity;
using Taxi_Backend.Models.DBModels;
using Taxi_Backend.Hubs;
using Taxi_Backend;
using Ta.Managers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

var conn = builder.Configuration.GetConnectionString("defaultString");

builder.Services.AddScoped<IEmailService, EmailService>();
builder.Services.AddScoped<IMapService, MapService>();

builder.Services.AddScoped<TaxiHub>();

builder.Services.AddScoped<AuthManager>();
builder.Services.AddScoped<UserManager>();
builder.Services.AddScoped<BackgroundManager>();
builder.Services.AddScoped<HubManager>();
builder.Services.AddScoped<TripManager>();
builder.Services.AddScoped<CompanyManager>();
builder.Services.AddScoped<DriverManager>();

builder.Services.AddHostedService<BackgroundWorkerServiceCustomerQueue>();
builder.Services.AddHostedService<BackgroundWorkerServiceMatching>();

builder.Services.AddTransient<DataGenerator>();

builder.Services.AddDbContext<TaxiDBContext>(options => options.UseNpgsql(conn).UseLowerCaseNamingConvention());

builder.Services.AddAuthorization();

builder.Services.AddIdentity<AppUser, AppRole>()
    .AddEntityFrameworkStores<TaxiDBContext>()
    .AddApiEndpoints();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddHttpContextAccessor();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        Description = "Standard Authorization header using the Bearer scheme (\"bearer {token}\")",
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });

    options.OperationFilter<SecurityRequirementsOperationFilter>();
});
builder.Services.AddAuthentication()
    .AddBearerToken(IdentityConstants.BearerScheme);


builder.Services.AddCors(options => options.AddPolicy(name: "corsapp", policy =>
{
    policy.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));

builder.Services.AddSignalR(e =>
{
    e.MaximumReceiveMessageSize = 102400000;
    e.KeepAliveInterval = TimeSpan.FromMinutes(5);
    e.ClientTimeoutInterval = TimeSpan.FromMinutes(10);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsProduction())
{
    app.UseMiddleware<SwaggerBasicAuthMiddleware>();
}
app.UseSwagger();
app.UseSwaggerUI(x => x.DocExpansion(docExpansion: Swashbuckle.AspNetCore.SwaggerUI.DocExpansion.None));

app.MapCustomIdentityApi<AppUser>();

app.UseRouting();

app.UseCors("corsapp");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapHub<TaxiHub>("/Taxi");

// Auto migrate db on start
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<TaxiDBContext>();
    if (context.Database.GetPendingMigrations().Any())
    {
        context.Database.Migrate();
    }

}

app.Run();
