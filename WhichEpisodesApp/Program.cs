﻿using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using Azure.Core;
using WhichEpisodesApp.Data;

var builder = WebApplication.CreateBuilder(args);

//api key from secrets
var tmdbApiKey = builder.Configuration["API_key"];

//this code is from https://learn.microsoft.com/en-us/azure/key-vault/general/tutorial-net-create-vault-azure-web-app#configure-the-web-app-to-connect-to-key-vault
SecretClientOptions options = new SecretClientOptions()
    {
        Retry =
        {
            Delay= TimeSpan.FromSeconds(2),
            MaxDelay = TimeSpan.FromSeconds(16),
            MaxRetries = 5,
            Mode = RetryMode.Exponential
         }
    };
var client = new SecretClient(new Uri("https://WhichEpisodesAPI.vault.azure.net/"), new DefaultAzureCredential(),options);

KeyVaultSecret secret = client.GetSecret("tmdbApiKey");

string secretValue = secret.Value;

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddServerSideBlazor().AddCircuitOptions(options => { options.DetailedErrors = true; });
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddHttpClient();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}

//this code is from https://learn.microsoft.com/en-us/azure/key-vault/general/tutorial-net-create-vault-azure-web-app#configure-the-web-app-to-connect-to-key-vault
SecretClientOptions options = new SecretClientOptions()
    {
        Retry =
        {
            Delay= TimeSpan.FromSeconds(2),
            MaxDelay = TimeSpan.FromSeconds(16),
            MaxRetries = 5,
            Mode = RetryMode.Exponential
         }
    };
var client = new SecretClient(new Uri("https://WhichEpisodesAPI.vault.azure.net/"), new DefaultAzureCredential(),options);

KeyVaultSecret secret = client.GetSecret("tmdbApiKey");

string secretValue = secret.Value;


app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");


app.Run();

