global using Career_Connect.Api.Services;
global using Microsoft.EntityFrameworkCore;
global using Career_Connect.Api.Data;
global using Microsoft.AspNetCore.Identity;
global using Swashbuckle.AspNetCore.Filters;
global using Microsoft.OpenApi.Models;


var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
// injecting services 
builder.Services.AddScoped<ICreateConnectionService, CreateConnectionService>();

 // db context using sqlite
    builder.Services.AddDbContext<DataContext>(options => options.UseSqlite("Data Source=network.db"));

builder.Services.AddAuthorization();
builder.Services.AddIdentityApiEndpoints<IdentityUser>()
    .AddEntityFrameworkStores<DataContext>();


    builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new() { Title = "Career-Connect.Api", Version = "v1" });
    options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
    });
    options.OperationFilter<SecurityRequirementsOperationFilter>();
});



var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapIdentityApi<IdentityUser>();

app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.UseHttpsRedirection();
app.Run();


