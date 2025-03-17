using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using System.Net.Http;
using System.Net.Http.Json;

namespace SmartBalanceBlazor.Auth
{
    public class TokenHandler : DelegatingHandler
    {
        private readonly ILocalStorageService _localStorage;
        private readonly HttpClient _httpClient;
        private readonly NavigationManager _navigation;

        public TokenHandler(ILocalStorageService localStorage, IHttpClientFactory httpClientFactory, NavigationManager navigation)
        {
            _localStorage = localStorage;
            _httpClient = httpClientFactory.CreateClient();
            _navigation = navigation;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var token = await _localStorage.GetItemAsync<string>("authToken");
            if (!string.IsNullOrEmpty(token))
            {
                request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            }

            var response = await base.SendAsync(request, cancellationToken);

            if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                var refreshToken = await _localStorage.GetItemAsync<string>("refreshToken");
                var userName = await _localStorage.GetItemAsync<string>("userName");

                if (!string.IsNullOrEmpty(refreshToken) && !string.IsNullOrEmpty(userName))
                {
                    var refreshRequest = new RefreshTokenRequest { UserName = userName, RefreshToken = refreshToken };
                    var refreshResponse = await _httpClient.PostAsJsonAsync("https://smartbalanceapi.onrender.com/api/Authentication/refresh", refreshRequest);

                    if (refreshResponse.IsSuccessStatusCode)
                    {
                        var result = await refreshResponse.Content.ReadFromJsonAsync<RefreshTokenResponse>();
                        await _localStorage.SetItemAsync("authToken", result.token); // Note: Use 'token' to match the server response
                        await _localStorage.SetItemAsync("refreshToken", result.refreshToken); // Note: Use 'refreshToken' to match the server response

                        request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", result.token);
                        return await base.SendAsync(request, cancellationToken); // Retry the original request
                    }
                }

                // If refresh fails, clear storage and redirect
                await _localStorage.RemoveItemAsync("authToken");
                await _localStorage.RemoveItemAsync("refreshToken");
                await _localStorage.RemoveItemAsync("userName");
                _navigation.NavigateTo("/login");
            }

            return response;
        }
    }

    public class RefreshTokenRequest
    {
        public string UserName { get; set; } = string.Empty;
        public string RefreshToken { get; set; } = string.Empty;
    }

    public class RefreshTokenResponse
    {
        public string token { get; set; } = string.Empty;
        public string refreshToken { get; set; } = string.Empty;
    }
}