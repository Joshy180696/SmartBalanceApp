using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http.Json;
using System.Security.Claims;

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
                // Attempt to refresh token
                var refreshToken = await _localStorage.GetItemAsync<string>("refreshToken");
                var userName = (await GetAuthenticationStateAsync()).User.Identity?.Name;

                if (!string.IsNullOrEmpty(refreshToken) && !string.IsNullOrEmpty(userName))
                {
                    var refreshRequest = new RefreshTokenRequest { UserName = userName, RefreshToken = refreshToken };
                    var refreshResponse = await _httpClient.PostAsJsonAsync("https://smartbalanceapi.onrender.com/api/Authentication/refresh", refreshRequest);

                    if (refreshResponse.IsSuccessStatusCode)
                    {
                        var result = await refreshResponse.Content.ReadFromJsonAsync<RefreshTokenResponse>();
                        await _localStorage.SetItemAsync("authToken", result.Token);
                        await _localStorage.SetItemAsync("refreshToken", result.RefreshToken);

                        // Retry the original request with the new token
                        request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", result.Token);
                        return await base.SendAsync(request, cancellationToken);
                    }
                }

                // If refresh fails, redirect to login
                _navigation.NavigateTo("/login");
            }

            return response;
        }

        private async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var token = await _localStorage.GetItemAsync<string>("authToken");
            if (string.IsNullOrEmpty(token)) return new AuthenticationState(new ClaimsPrincipal());

            var handler = new JwtSecurityTokenHandler();
            var jwtToken = handler.ReadJwtToken(token);
            var identity = new ClaimsIdentity(jwtToken.Claims, "jwt");
            return new AuthenticationState(new ClaimsPrincipal(identity));
        }
    }

    public class RefreshTokenRequest
    {
        public string UserName { get; set; } = string.Empty;
        public string RefreshToken { get; set; } = string.Empty;
    }

    public class RefreshTokenResponse
    {
        public string Token { get; set; } = string.Empty;
        public string RefreshToken { get; set; } = string.Empty;
    }
}
