using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using WhichEpisodesApp.Data;

var builder = WebApplication.CreateBuilder(args);

//api key from secrets
var tmdbApiKey = builder.Configuration["API_key"];

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddHttpClient();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}


app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");
//app.MapGet("/", () => tmdbApiKey);

app.Run();

