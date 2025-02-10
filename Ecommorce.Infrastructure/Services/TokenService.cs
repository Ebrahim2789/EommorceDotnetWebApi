
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
namespace Ecommorce.Infrastructure.Services
{
public interface ITokenService
{
    Task<string> GetAccessTokenAsync();
    Task<string> RefreshTokenAsync();
}

public class TokenService : ITokenService
{
    private string _accessToken;
    private string _refreshToken;
    private readonly HttpClient _httpClient;

    public TokenService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<string> GetAccessTokenAsync()
    {
        if (string.IsNullOrEmpty(_accessToken) || IsTokenExpired(_accessToken))
        {
            return await RefreshTokenAsync();
        }
        return _accessToken;
    }

    public async Task<string> RefreshTokenAsync()
    {
        var response = await _httpClient.PostAsJsonAsync("http://localhost:5179/api/Auth/Refresh", new { refreshToken = _refreshToken });

        if (response.IsSuccessStatusCode)
        {
            var tokenResponse = await response.Content.ReadFromJsonAsync<TokenResponse>();
            _accessToken = tokenResponse.AccessToken;
            _refreshToken = tokenResponse.RefreshToken;
            return _accessToken;
        }

        throw new Exception("Unable to refresh token.");
    }

    private bool IsTokenExpired(string token)
    {
        // Implement logic to check if the token is expired (e.g., by decoding JWT)
        return false; // Placeholder, replace with actual check
    }
}

public class TokenResponse
{
    public string AccessToken { get; set; }
    public string RefreshToken { get; set; }
}

public class TokenStorage
{
    private string _accessToken;
    private string _refreshToken;

    public string GetAccessToken() => _accessToken;
    public void SetAccessToken(string token) => _accessToken = token;

    public string GetRefreshToken() => _refreshToken;
    public void SetRefreshToken(string token) => _refreshToken = token;
}
}