using APINotas;
using APINotas.Services;

var builder = WebApplication.CreateBuilder(args);
var CorsPolicy = "_CorsPolicy";

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSqlServer<NotesContext>("Data Source=localhost; Initial Catalog=NotesDB;user id=SA;Password=Hola.123;TrustServerCertificate=true");

builder.Services.AddScoped<INoteService, NoteService>();

//prueba de CORS


builder.Services.AddCors(options =>
{
    options.AddPolicy(CorsPolicy,
        policy =>
        {
            policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
        });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("_CorsPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();
