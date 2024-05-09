using Applied2Reminder;
using Applied2Reminder.Components;

var builder = WebApplication.CreateBuilder(args);

builder.Services
.AddRazorComponents()
.AddInteractiveServerComponents();

builder.Services
.AddDbContext<AppliedDbContext>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}
else
{
    var configuration = app.Configuration.AsEnumerable().ToList();
    var seedData = configuration.FirstOrDefault(x => x.Key == "SeedData");
    var clearData = configuration.FirstOrDefault(x => x.Key == "ClearData");

    if (seedData.Value != null && bool.Parse(seedData.Value))
    {
        Seed.Initialize();
    }
    else if (clearData.Value != null && bool.Parse(clearData.Value))
    {
        Seed.Clear();
    }
    using AppliedDbContext db = new();
    db.Database.EnsureCreated();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();
app.Run();
