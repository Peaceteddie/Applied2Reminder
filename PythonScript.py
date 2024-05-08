import re


text = """
<div class="absolute flex size-full z-20" style="background-color:#6666;"
@onclick="@((e) =>{if(!IsInsideModal){Source = null; ClearSourceCallback.InvokeAsync().Wait();}})">
<dialog class="absolute flex place-self-center rounded-3xl size-2/3 top-20"
@onmouseenter="@((e) => IsInsideModal = true)" @onmouseleave="@((e) => IsInsideModal = false)" open>
<div class="flex flex-col w-full">
<h1 class="flex place-content-center text-center">@Source.Name</h1>
<div class="container flex flex-row size-full">
<div class="flex flex-col px-4 w-1/3">
<h2 class="text-center text-3xl">Applications</h2>
<div class="flex px-4 self-start">
<InputText @bind-Value="Search" placeholder="Search" @oninput="SearchApplications"
class="outline outline-slate-400 p-4 pe-16 rounded-full self-center" />
<div class=" flex">
<button
class="absolute bg-white outline outline-slate-400 rounded-full size-14 text-3xl -translate-x-full z-10"
@onclick="SearchApplications">🔎</button>
</div>
</div>
<ul class="flex flex-col gap-4 items-center max-h-full overflow-y-auto py-5"
style="direction:rtl;mask:linear-gradient(0deg, #0000, #000 5%, #000 95%, #0000);scrollbar-width:thin;">
@if (Applications is not null)
{
@foreach (var application in PriorityCollection())
{
<li class="content-center max-h-40 min-h-40 min-w-40 max-w-40 cursor-pointer rounded-full text-center text-xl shadow-lg"
@onclick="()=> ShowDetails(application)" style="background-color:@(_color);direction:ltr;">
@application.Name
</li>
}
}
</ul>
</div>
<div class="outline p-10 rounded-3xl size-full">
@if (JobApplication is not null)
{
<div>
<h1>@JobApplication.Name</h1>
<p>@JobApplication.JobDescription</p>
</div>
}
</div>
</div>
</div>
</dialog>
</div>
"""
pattern = r'class="([a-zA-Z0-9\s-]+)"'
matches = re.findall(pattern, text)

for match in matches:
    for item in match.split():
        if item.startswith("m"):
            print(item)
