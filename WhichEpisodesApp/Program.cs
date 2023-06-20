using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.Extensions.Azure;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using Azure.Core;
using WhichEpisodesApp.Data;
using WhichEpisodesApp.Models;

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
var client = new SecretClient(new Uri("https://whichepisodesapi.vault.azure.net/"), new DefaultAzureCredential(),options);

KeyVaultSecret secret = await client.GetSecretAsync("tmdbApiKey");

var keyVaultValue = secret.Value;

//var kvValue = new KeyVaultModel(keyVaultValue);

//var VaultApiKey = builder.Configuration[secret.Value];

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddServerSideBlazor().AddCircuitOptions(options => { options.DetailedErrors = true; });
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddSingleton<KeyVaultModel>(kvv => new KeyVaultModel(keyVaultValue));
//builder.Services.AddSingleton<KeyVaultModel>(keyVaultValue);
builder.Services.AddHttpClient();
//builder.Services.AddSingleton<KeyVaultSecret>();
//builder.Services.AddAzureClients(HttpClientBuilderExtensions => {
    //HttpClientBuilderExtensions.AddSecretClient("https://whichepisodesapi.vault.azure.net/");
//});

var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    //var keyVaultURL = app.Configuration.GetSection("keyVault:keyVaultURL");
    //var keyVault
    app.UseExceptionHandler("/Error");
}


app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();




