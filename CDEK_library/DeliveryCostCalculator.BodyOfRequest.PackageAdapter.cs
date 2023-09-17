using System.Text.Json.Serialization;

namespace CDEK_library
{
    public partial class DeliveryCostCalculator
    {
        partial class BodyOfRequest
        {
            internal class PackageAdapter
            {
                [JsonPropertyName("weight")]
                public int Weight_g => package.Weight;

                [JsonPropertyName("length")]
                public int Length_cm => ConvertMillimetersToCentimeters(package.Length_mm);

                [JsonPropertyName("width")]
                public int Width_cm => ConvertMillimetersToCentimeters(package.Width_mm);

                [JsonPropertyName("height")]
                public int Height_cm => ConvertMillimetersToCentimeters(package.Height_mm);

                [JsonIgnore]
                private Package package;

                public PackageAdapter(Package package)
                {
                    this.package = package;
                }

                int ConvertMillimetersToCentimeters(int mm) => mm % 10 != 0 ?
                                                               mm / 10 + 1 :
                                                               mm / 10;
            }

        }
    }
}
