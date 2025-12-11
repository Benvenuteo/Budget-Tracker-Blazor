using Blazored.LocalStorage;
using BudgetTracker.Shared.DTOs;
using Microsoft.AspNetCore.Components.Authorization;
using System.Net.Http.Json;

namespace BudgetTracker.BlazorWASM.Services
{
    public interface IAuthenticationService
    {
        Task<AuthResponseDto> Login(LoginDto loginModel);
        Task Logout();
        Task<bool> Register(RegisterDto registerModel);
    }

    public class AuthenticationService : IAuthenticationService
    {
        private readonly HttpClient _client;
        private readonly AuthenticationStateProvider _authStateProvider;
        private readonly ILocalStorageService _localStorage;

        public AuthenticationService(HttpClient client, AuthenticationStateProvider authStateProvider, ILocalStorageService localStorage)
        {
            _client = client;
            _authStateProvider = authStateProvider;
            _localStorage = localStorage;
        }

        public async Task<AuthResponseDto> Login(LoginDto loginModel)
        {
            var response = await _client.PostAsJsonAsync("api/Auth/login", loginModel);
            var result = await response.Content.ReadFromJsonAsync<AuthResponseDto>();

            if (response.IsSuccessStatusCode)
            {
                await _localStorage.SetItemAsync("authToken", result.Token);

                await _authStateProvider.GetAuthenticationStateAsync();
                result.IsSuccess = true;
                return result;
            }
            return new AuthResponseDto { IsSuccess = false };
        }

        public async Task Logout()
        {
            await _localStorage.RemoveItemAsync("authToken");
            await _authStateProvider.GetAuthenticationStateAsync();
        }

        public async Task<bool> Register(RegisterDto registerModel)
        {
            var response = await _client.PostAsJsonAsync("api/Auth/register", registerModel);

            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException("Rejestracja nieudana");
            }

            return true;
        }
    }
}
