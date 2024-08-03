using ERP3000.EndPoints;
using ERP3000.Helpers;
using ERP3000.Repository;
using ERP3000.Repository.Conctracts;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connection = builder.Configuration.GetConnectionString("dbConnection")!;

builder.Services.ConfiguredCors();
builder.Services.ConfiguredSqlServerContext(connection);
builder.Services.ConfigureRepositoryManager();
builder.Services.ConfigureServiceManager();
builder.Services.AddControllers();


var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

EndPoints.MainEnPoint(app);
app.MapControllers();
app.Run();

