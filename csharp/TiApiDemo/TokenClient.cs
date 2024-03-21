using System.Text.Json;

namespace TiApiDemo;

public class TokenClient
{
    public async Task<JwtToken> FetchToken()
    {
        var oauthBaseUrl = EnvironmentExtensions.GetVariableOrThrow("NDI_OAUTH_PROVIDER");
        var oauthAppClientId = EnvironmentExtensions.GetVariableOrThrow("NDI_OAUTH_APP_CLIENT_ID");
        var oauthUserName = EnvironmentExtensions.GetVariableOrThrow("NDI_OAUTH_USER_NAME");
        var oauthUserSecret = EnvironmentExtensions.GetVariableOrThrow("NDI_OAUTH_USER_SECRET");
        var oauthScope = "https://travelinsightsb2cprod.onmicrosoft.com/backend/apiaccess";
        var oauthSigninFlowUrl = oauthBaseUrl + "/oauth2/v2.0/token?p=B2C_1_ropc_v0";

        var content = BuildPayload(oauthAppClientId, oauthScope, oauthUserName, oauthUserSecret);
        
        using var client = new HttpClient();
        var loginHttpResponse = await client.PostAsync(oauthSigninFlowUrl, content);
        loginHttpResponse.EnsureSuccessStatusCode();
        
        var responseBody = await loginHttpResponse.Content.ReadAsStringAsync();
        var jwtToken = JsonSerializer.Deserialize<JwtToken>(responseBody,
            new JsonSerializerOptions { PropertyNameCaseInsensitive = true })!;
        
        if (jwtToken.AccessToken == null)
        {
            throw new InvalidOperationException("Could not fetch access token");
        }
        
        return jwtToken;
    }

    private static FormUrlEncodedContent BuildPayload(string oauthAppClientId, string oauthScope, string oauthUserName,
        string oauthUserSecret)
    {
        return new FormUrlEncodedContent(new[]
        {
            new KeyValuePair<string, string>("client_id", oauthAppClientId),
            new KeyValuePair<string, string>("scope", oauthScope),
            new KeyValuePair<string, string>("grant_type", "password"),
            new KeyValuePair<string, string>("username", oauthUserName),
            new KeyValuePair<string, string>("password", oauthUserSecret),
            new KeyValuePair<string, string>("response_type", "token"),
        });
    }
}