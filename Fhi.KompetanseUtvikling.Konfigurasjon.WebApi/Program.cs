using Fhi.KompetanseUtvikling.Konfigurasjon.WebApi.Configuration;
using Testdata.Generator;
using Testdata.Generator.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

Testdata.Generator.DependencyInjection.AddDependencyInjection.AddGenerator(builder.Services, builder.Configuration.GetSection("TestDataGenerator"));

builder.Services.Configure<SecretConfiguration>(builder.Configuration.GetSection("Secret"));
builder.Services.Configure<AntallSykehusConfig>(builder.Configuration);

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
