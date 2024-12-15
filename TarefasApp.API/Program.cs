using TarefasApp.API.Extensions;
using TarefasApp.Application.Extensions;
using TarefasApp.Infra.Data.Extensions;
using TarefasApp.Infra.Storage.Extensions;
using TarefasApp.Infra.Messages.Extensions;
using TarefasApp.Domain.Extensions;
using TarefasApp.API.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddRouting(options => options.LowercaseUrls = true);


#region Services Extensions 
builder.Services.AddSwaggerDoc();
builder.Services.AddApplicationServices();
builder.Services.AddDomainServices();
builder.Services.AddDataContext(builder.Configuration);
builder.Services.AddMongoDb(builder.Configuration);
builder.Services.AddRabbitMQ(builder.Configuration);
builder.Services.AddCorsConfig(builder.Configuration);
#endregion Services Extensions 

var app = builder.Build();

#region middlewares
app.UseMiddleware<ValidationExceptionMiddleware>();
app.UseMiddleware<NotFoundExceptionMiddleware>();
#endregion middlewares

#region Apps Extensions
app.UseSwagger();
app.UseSwaggerUI();
#endregion Apps Extensions

app.UseCorsConfig();
app.UseSwaggerDoc();
app.UseAuthorization();

app.MapControllers();
app.Run();