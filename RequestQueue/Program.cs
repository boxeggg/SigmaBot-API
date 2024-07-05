
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using SigmaBotAPI.Data;
using SigmaBotAPI.Services;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddTransient<ISongRepository, SongRepository>();
builder.Services.AddTransient<IStatusRepository, StatusRepository>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddSwaggerGen().AddSwaggerGenNewtonsoftSupport();
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));



var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseCors(x => x
    .AllowAnyMethod()
    .AllowAnyHeader()
    .AllowCredentials()
    .SetIsOriginAllowed(origin => true));
}

app.UseSwagger();
app.UseSwaggerUI();


app.UseAuthorization();

app.MapControllers();

app.Run();
