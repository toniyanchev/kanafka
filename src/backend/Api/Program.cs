using Kanafka;
using Kanafka.Admin.Api.Consumers;
using Kanafka.Admin.Application;
using Kanafka.Admin.Domain;
using Kanafka.Admin.Infrastructure.Core;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(builder.Configuration);

// Kanafka Consumers
builder.Services.AddKanafkaConsumer<ReproduceConsumer>(Topics.ReproduceMessages);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();
app.MapControllers();

app.Run();