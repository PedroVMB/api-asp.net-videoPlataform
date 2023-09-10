using API_ASP_VIDEOS_PLATAFORM.Data;
using API_ASP_VIDEOS_PLATAFORM.Profiles;
using API_ASP_VIDEOS_PLATAFORM.services;
using API_ASP_VIDEOS_PLATAFORM.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Configurar a conexão com o banco de dados
var connectionString = builder.Configuration.GetConnectionString("VideoPlataformConnection");
builder.Services.AddDbContext<VideoPlataformContext>(opts =>
    opts.UseLazyLoadingProxies().UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));


// Registrar o serviço TeacherService
builder.Services.AddTransient<TeacherService>();
builder.Services.AddTransient<StudentService>();
builder.Services.AddTransient<VideoService>();

// Configurar AutoMapper
builder.Services.AddAutoMapper(typeof(TeacherProfile));
builder.Services.AddAutoMapper(typeof(StudentProfile));
builder.Services.AddAutoMapper(typeof(VideoProfile));

// Configurar controllers e JSON serialization
builder.Services.AddControllers().AddNewtonsoftJson();

// Configurar Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configurar o pipeline de solicitação HTTP
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

// Aplicar migrações automaticamente durante a inicialização
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var dbContext = services.GetRequiredService<VideoPlataformContext>();
    dbContext.Database.Migrate();
}

app.Run();
