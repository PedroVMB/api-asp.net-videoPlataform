using API_ASP_VIDEOS_PLATAFORM.Data;
using API_ASP_VIDEOS_PLATAFORM.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Configurar a conex�o com o banco de dados
var connectionString = builder.Configuration.GetConnectionString("VideoPlataformConnection");
builder.Services.AddDbContext<VideoPlataformContext>(opts =>
    opts.UseLazyLoadingProxies().UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));


// Registrar o servi�o TeacherService
builder.Services.AddTransient<TeacherService>();

// Configurar AutoMapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Configurar controllers e JSON serialization
builder.Services.AddControllers().AddNewtonsoftJson();

// Configurar Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configurar o pipeline de solicita��o HTTP
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

// Aplicar migra��es automaticamente durante a inicializa��o
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var dbContext = services.GetRequiredService<VideoPlataformContext>();
    dbContext.Database.Migrate();
}

app.Run();
