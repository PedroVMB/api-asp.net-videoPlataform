using API_ASP_VIDEOS_PLATAFORM.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API_ASP_VIDEOS_PLATAFORM.Data;

public class VideoPlataformContext : DbContext
{
    public DbSet<Teacher> teachers { get; set; } 

    public VideoPlataformContext(DbContextOptions<VideoPlataformContext> opts) : base(opts)
    {
    }

}
