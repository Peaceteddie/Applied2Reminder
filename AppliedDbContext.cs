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
public class Application
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required JobSource JobSource { get; set; }
    public string? JobDescription { get; set; }
    public string? JobUrl { get; set; }
}
public class JobSource
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required JobSources SourceType { get; set; }
    public string? Description { get; set; }
    public string? Url { get; set; }
}

public enum JobSources
{
    Company,
    Recruiter
}