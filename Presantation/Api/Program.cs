var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var env = builder.Environment;

builder.Configuration.
    SetBasePath(env.ContentRootPath)                        // bu satýr biz production veya development profillerinden hangisini kullandýðýmýðýzý belli ediyor fakat burayý generic tutarsak production server root burada çalýþabilir
    .AddJsonFile("appsettings.json",optional:false)         // optional false yaparak her defasýnda appsettings e giderek profillere baksýn
    .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional:true);    // optional true ile hangi profil kullanýldðý seçilebilsin


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
