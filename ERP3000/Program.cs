using ERP3000.EndPoints;
using ERP3000.Helpers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connection = builder.Configuration.GetConnectionString("dbConnection")!;
builder.Services.ConfiguredCors();
builder.Services.ConfiguredSqlServerContext(connection);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

EndPoints.MainEnPoint(app);

app.Run();

