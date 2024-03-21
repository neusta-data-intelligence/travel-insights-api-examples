namespace TiApiDemo;

public static class StaticTiApiRequestPayload
{
    public const string JsonPayload = """
                                      {
                                          "dateCubes": [
                                              {
                                                  "timestampRange": {
                                                      "from": "2023-09-21",
                                                      "to": "2023-11-20"
                                                  },
                                                  "travelTimestampRange": {
                                                      "from": "2023-11-01",
                                                      "to": "2024-03-31"
                                                  }
                                              }
                                          ],
                                          "inclusionFilters": {
                                              "airportsOfArrival": [
                                                  "PMI"
                                              ]
                                      
                                          },
                                          "limit": 100,
                                          "linkActorResultsToMarket": false,
                                          "metadata": {
                                              "brands": [
                                              ],
                                              "collection": "BOOKING_REQUESTS",
                                              "dataSources": [
                                                  "AMADEUS"
                                              ],
                                              "productCategory": "PACKAGE"
                                          },
                                          "targetDimension": "HOTEL_GIATA_ID"
                                      }
                                      """;
}