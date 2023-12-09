using System.Text.Json.Serialization;
using ASPNETTask;
using ASPNETTask.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
var configuration = builder.Configuration;
var appSettings = configuration.GetSection("AppSettings").Get<AppSettings>();

builder.Services.Configure<AppSettings>(configuration.GetSection("AppSettings"));

builder.Services
    .AddControllersWithViews() // or AddControllers() in a Web API
    .AddJsonOptions(options => 
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<RequestLimitMiddleware>();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();