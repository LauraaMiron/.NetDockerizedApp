
using Microsoft.EntityFrameworkCore;
using Npgsql;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
/////////////DATABASE CONTEXT DEPENDENCY INJECTION

var dbHost = Environment.GetEnvironmentVariable("DB_HOST");
//dbHost = "localhost:5432";
var connectionString = $"Host={dbHost};Port=5432;Username=laura;Password=laura;Database=postgres";
builder.Services.AddDbContext<ClientApplicationTest1.ClientDbContext>(opt => opt.UseNpgsql(connectionString));


var app = builder.Build();

app.UseAuthorization();

app.MapControllers();

app.Run();
