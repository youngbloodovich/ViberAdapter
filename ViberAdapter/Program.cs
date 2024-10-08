using ViberAdapter.Clients;
using ViberAdapter.Models.Settings;
using ViberAdapter.Services;

var builder = WebApplication.CreateBuilder(args);

// Configs
builder.Services.Configure<ViberSettings>(builder.Configuration.GetSection("ViberSettings"));

// Add services to the container.
builder.Services.AddTransient<IViberClient, ViberClient>();
builder.Services.AddTransient<IWebhookService, WebhookService>();

builder.Services.AddHttpClient();
builder.Services
    .AddControllers(options => options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true)
    .AddNewtonsoftJson();
builder.Services.AddLogging();
builder.Services.AddHttpLogging(options =>
{
    options.LoggingFields = Microsoft.AspNetCore.HttpLogging.HttpLoggingFields.All;
});
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
app.UseHttpLogging();
app.MapControllers();

app.Run();