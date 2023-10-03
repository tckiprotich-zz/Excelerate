global using NetworkAPI.Data;
global using Microsoft.EntityFrameworkCore;
global using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
global using Microsoft.AspNetCore.Identity;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
{
    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen(options =>
    {
        options.SwaggerDoc("v1", new() { Title = "NetworkAPI", Version = "v1" });
        options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
        {
            In = ParameterLocation.Header,
            Name = "Authorization",
            Type = SecuritySchemeType.ApiKey,
        } );
        options.OperationFilter<SecurityRequirementsOperationFilter>();
    });

    // add services
    builder.Services.AddScoped<INewConnection, NewConnection>();
    // db context using sqlite
    builder.Services.AddDbContext<DataContext>(options => options.UseSqlite("Data Source=network.db"));

    builder.Services.AddAuthorization();
    builder.Services.AddIdentityApiEndpoints<IdentityUser>()
        .AddEntityFrameworkStores<DataContext>();
    
}
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

{
    app.MapIdentityApi<IdentityUser>();

    app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();
}


