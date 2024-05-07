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
    Seed.Initialize();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();


app.Run();
