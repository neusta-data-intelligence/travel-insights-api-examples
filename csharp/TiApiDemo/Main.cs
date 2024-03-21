using TiApiDemo;

var jwtToken = await new TokenClient().FetchToken();
var aggregationResponse = await new TravelInsightsClient().Call(jwtToken, StaticTiApiRequestPayload.JsonPayload);
Console.WriteLine(aggregationResponse);