namespace Applied2Reminder;

public static class Seed
{
    public static void Initialize()
    {
        using AppliedDbContext context = new();
        context.Database.EnsureDeleted();
        context.Database.EnsureCreated();
        var applications = new List<Application>
        {
            new() {
                Name = "Junior Web Developer",
                JobSource = new JobSource
                {
                    Name = "Unity Company",
                    SourceType = JobSources.Company,
                    Description = "A company that makes VR experiences in Unity.",
                    Url = "https://www.unitycompany.com"

                },
                JobDescription = "A Junior Web Developer. Keywords: .net, python, javascript, html, css",
                JobUrl = "https://www.applied2reminder.com/job/junior-web-developer",
            },
            new() {
                Name = "Senior Web Developer",
                JobSource = new JobSource
                {
                    Name = "Dotnet Recruiter Company",
                    SourceType = JobSources.Recruiter,
                    Description = "Dotnet Recruiter Company",
                    Url = "https://www.dotnetrecruitercompany.com"

                },
                JobDescription = "A Senior Web Developer. Keywords: .net, devops, docker, angular, kubernetes, aws",
                JobUrl = "https://www.applied2reminder.com/job/senior-web-developer",
            }
        };
        context.Applications.AddRange(applications);
        context.SaveChanges();
        context.Dispose();
        Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
        Console.WriteLine("~~                                                          ~~");
        Console.WriteLine("~~        SUCCESS: Database seeded with initial data        ~~");
        Console.WriteLine("~~                                                          ~~");
        Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
    }
}