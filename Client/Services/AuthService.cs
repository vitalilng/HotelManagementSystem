﻿using HotelManagementSystem.Shared.Dto;
using System.Net.Http.Json;

namespace HotelManagementSystem.Client.Services
{
    public class AuthService : IAuthService
    {
        private readonly HttpClient _httpClient;
        public AuthService(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public async Task<CurrentUserDto> CurrentUserInfo()
        {
            CurrentUserDto? result = await _httpClient.GetFromJsonAsync<CurrentUserDto>("api/auth/currentuserinfo");
            return result ?? throw new ArgumentNullException(nameof(result));
        }

        public async Task Login(LoginDto loginRequest)
        {
            HttpResponseMessage result = await _httpClient.PostAsJsonAsync("api/auth/login", loginRequest);
            if (result.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                throw new Exception(await result.Content.ReadAsStringAsync());
            }
            result.EnsureSuccessStatusCode();
        }

        public async Task Logout()
        {
            HttpResponseMessage result = await _httpClient.PostAsync("api/auth/logout", null);
            result.EnsureSuccessStatusCode();
        }

        public async Task Register(UserDetailsDto registrationRequest)
        {
            HttpResponseMessage result = await _httpClient.PostAsJsonAsync("api/auth/register", registrationRequest);
            if (result.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                throw new Exception(await result.Content.ReadAsStringAsync());
            }
        }
    }
}