using QueLib.Server.Services.QueService;
using QueLib.Server.Services.QueService.Receiver;
using QueLib.Server.Services.QueService.Sender;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton(new RabbitMqConfig());
builder.Services.AddSingleton<QueReceiver>();
builder.Services.AddSingleton<QueSender>();
builder.Services.AddSingleton<QueReceiverBackgroundService>();
builder.Services.AddHostedService<QueReceiverBackgroundService>();
builder.Services.AddSingleton<RabbitService>();
builder.Services.AddHostedService<RabbitListener>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => // Enable middleware to serve swagger-ui
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "RabbitMQ API V1");
    });
}
//allow any policy for CORS
app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();