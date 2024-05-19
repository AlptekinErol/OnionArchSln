var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var env = builder.Environment;

builder.Configuration.
    SetBasePath(env.ContentRootPath)                        // bu sat�r biz production veya development profillerinden hangisini kulland���m���z� belli ediyor fakat buray� generic tutarsak production server root burada �al��abilir
    .AddJsonFile("appsettings.json",optional:false)         // optional false yaparak her defas�nda appsettings e giderek profillere baks�n
    .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional:true);    // optional true ile hangi profil kullan�ld�� se�ilebilsin


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
