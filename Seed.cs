using Bogus;
using System.Linq;
namespace Applied2Reminder;

public static class Seed
{
    public static void Initialize()
    {
        using AppliedDbContext context = new();
        context.Database.EnsureDeleted();
        context.Database.EnsureCreated();

        Faker Faker = new();
        var CompanyCount = 50;
        var ApplicationCount = 50;

        var SourceTypes = Enum.GetValues<JobSources>().ToList();

        var FakeCompanies = Enumerable.Range(1, CompanyCount).Aggregate(new List<JobSource>(), (list, i) =>
        {
            list.Add(new JobSource
            {
                Name = Faker.Company.CompanyName(),
                Description = Faker.Company.CatchPhrase(),
                SourceType = SourceTypes[Faker.Random.Int(0, SourceTypes.Count - 1)],
                Url = Faker.Internet.Url()
            });
            return list;
        });

        var applications =
            FakeCompanies.SelectMany(company => Enumerable.Range(1, ApplicationCount).Select(i => new Application
            {
                Name = Faker.Name.JobTitle(),
                Source = company,
                Description = Faker.Lorem.Paragraph(),
                Url = Faker.Internet.Url()
            })).ToList();

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