using Microsoft.EntityFrameworkCore;
using DotNetEnv;

namespace Applied2Reminder;

public class AppliedDbContext : DbContext
{
    public DbSet<Application> Applications { get; set; }
    public DbSet<JobSource> JobSources { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        Env.TraversePath().Load();
        optionsBuilder.UseNpgsql($"Host={Env.GetString("POSTGRES_HOST")};Port={Env.GetString("POSTGRES_PORT")};Database={Env.GetString("POSTGRES_DB")};Username={Env.GetString("POSTGRES_USER")};Password={Env.GetString("POSTGRES_PASSWORD")};");
    }

}