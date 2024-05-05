using Microsoft.EntityFrameworkCore;
using DotNetEnv;
using System.ComponentModel.DataAnnotations;

namespace Applied2Reminder;

public class AppliedDbContext : DbContext
{
    public DbSet<Application> Applications { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        Env.TraversePath().Load();
        optionsBuilder.UseNpgsql($"Host={Env.GetString("POSTGRES_HOST")};Port={Env.GetString("POSTGRES_PORT")};Database={Env.GetString("POSTGRES_DB")};Username={Env.GetString("POSTGRES_USER")};Password={Env.GetString("POSTGRES_PASSWORD")};");
    }

    public class Application
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required JobSource JobSource { get; set; }

    }

    public class JobSource
    {
        public int Id { get; set; }
        public required string Name { get; set; }
    }
    public class Company : JobSource { }
    public class Recruiter : JobSource { }

    public enum JobSources
    {
        Company,
        Recruiter
    }
}