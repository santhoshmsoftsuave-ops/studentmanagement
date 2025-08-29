using MediatR;
using Microsoft.Azure.Cosmos;
using StudentManagement.Cqrs.Api.Repository;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<CosmosClient>(sp =>
{
    CosmosClientOptions options = new CosmosClientOptions()
    {
        HttpClientFactory = () =>
        {
            HttpMessageHandler handler = new HttpClientHandler()
            {
                ServerCertificateCustomValidationCallback = (req, cert, chain, errors) => true
            };
            return new HttpClient(handler);
        }
    };

    return new CosmosClient(
        "https://localhost:8081",
        "C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw==",
        options
    );
});
builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddMediatR(typeof(Program).Assembly);
builder.Services.AddControllers();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
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
