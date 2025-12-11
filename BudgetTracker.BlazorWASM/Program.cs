using Blazored.LocalStorage;
using Blazored.Toast;
using BudgetTracker.BlazorWASM;
using BudgetTracker.BlazorWASM.Auth;
using BudgetTracker.BlazorWASM.Services;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// Rejestracja LocalStorage i Toast
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddBlazoredToast();

// Rejestracja Autoryzacji
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();

// Konfiguracja HttpClient (z adresem API)
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7269") });

// Rejestracja serwisów
builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
builder.Services.AddScoped<ChartService>();
builder.Services.AddScoped<ITransactionService, TransactionService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();

await builder.Build().RunAsync();