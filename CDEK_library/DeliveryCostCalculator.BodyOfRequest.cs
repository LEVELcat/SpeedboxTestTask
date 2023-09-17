using System.Text.Json.Serialization;

namespace CDEK_library
{
    public partial class DeliveryCostCalculator : Client
    {
        partial class BodyOfRequest
        {
            [JsonInclude]
            [JsonPropertyName("type")]
            public int? Type { get; private set; } = 2;

            [JsonInclude]
            [JsonPropertyName("currency")]
            public int? Currency { get; private set; } = 1;

            [JsonInclude]
            [JsonPropertyName("lang")]
            public string? Language { get; private set; } = "rus";

            [JsonInclude]
            [JsonPropertyName("from_location")]
            public City CitySending { get; private set; }

            [JsonInclude]
            [JsonPropertyName("to_location")]
            public City CityReceiving { get; private set; }

            [JsonInclude]
            [JsonPropertyName("packages")]
            public PackageAdapter[] Packages { get; private set; }

            public BodyOfRequest(Guid CitySending, Guid CityReceiving, Package package, Token token)
            {
                this.CitySending = new CityFactory(token, CitySending).City;
                this.CityReceiving = new CityFactory(token, CityReceiving).City;
                this.Packages = new PackageAdapter[] { new PackageAdapter(package)}; 
            }
        }
    }
}
