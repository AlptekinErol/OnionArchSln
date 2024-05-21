using Persistance;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var env = builder.Environment;
builder.Configuration
    .SetBasePath(env.ContentRootPath)
    .AddJsonFile("appsettings.json", optional: false)       // optional olarak 2 dosyadan hangisini se�ebilir
    .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);  // product veya development oldu�unu se�mek zorunda


builder.Services.AddPersistance(builder.Configuration);  // konfig�rasyonlar� register ettik

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
