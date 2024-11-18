using Microsoft.OpenApi.Models;
using PhloSystems.Helpers;
using PhloSystems.Service.Concrete;
using PhloSystems.Service.Contract;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Phlo Systems", Version = "v1" });
    c.AddSecurityDefinition("ApiKey", new OpenApiSecurityScheme()
    {
        Description = "Use this as a api-key : NeerajSinha",
        In = ParameterLocation.Header,
        Name = "x-api-key", //header with api key
        Type = SecuritySchemeType.ApiKey,
        Scheme= "ApiKeyScheme"
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "ApiKey"
                },
                Scheme = "ApiKeyScheme",
                Name = "x-api-key",
                In = ParameterLocation.Header
            },
            new List<string>()
        }
    });
});
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddAutoMapper(typeof(PhloSystemsMapper));
builder.Services.AddHttpClient();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
