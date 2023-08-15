using ViberAdapter.Clients;
using ViberAdapter.Models.Settings;
using ViberAdapter.Services;

var builder = WebApplication.CreateBuilder(args);

// Configs
builder.Services.Configure<ViberSettings>(builder.Configuration.GetSection("ViberSettings"));

// Add services to the container.
builder.Services.AddHttpClient();

builder.Services.AddTransient<IViberClient, ViberClient>();
builder.Services.AddTransient<IWebhookService, WebhookService>();

builder.Services.AddControllers();
builder.Services.AddLogging();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseAuthorization();
app.MapControllers();

app.Run();