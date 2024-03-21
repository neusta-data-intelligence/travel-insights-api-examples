using System.Net.Http.Headers;

namespace TiApiDemo;

public class TravelInsightsClient
{
    public async Task<string> Call(JwtToken token, string payload)
    {
        var tiBaseUrl = EnvironmentExtensions.GetVariableOrThrow("NDI_TI_API_BASE_URL");
        var tiAggregationUrl = tiBaseUrl + "/public/historicdata/touroperator-aggregation";

        using var client = new HttpClient
        {
            DefaultRequestHeaders =
            {
                Authorization = new AuthenticationHeaderValue("Bearer", token.AccessToken)
            }
        };

        var requestContent = new StringContent(payload, new MediaTypeHeaderValue("application/json"));
        var queryResponseMessage = await client.PostAsync(tiAggregationUrl, requestContent);
        queryResponseMessage.EnsureSuccessStatusCode();

        return await queryResponseMessage.Content.ReadAsStringAsync();
    }
}