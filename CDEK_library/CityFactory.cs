using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CDEK_library
{
    public class CityFactory : Client
    {
        public City City { get; private set; }

        public CityFactory(string Account, string SecurePassword, Guid FromFias) : base(Account, SecurePassword)
        {
            this.City = GetCityFromFias(FromFias);
        }
        public CityFactory(Token token, Guid FromFias) : base (token)
        {
            this.City = GetCityFromFias(FromFias);
        }

        City GetCityFromFias(Guid Fias) => GetCityFromFiasAsync(Fias).Result;
        async Task<City> GetCityFromFiasAsync(Guid Fias)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://api.edu.cdek.ru");

            client.DefaultRequestHeaders.Add("Authorization", "Bearer" + " " + token.AccesToken);

            client.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            var response = await client.GetAsync("/v2/location/cities" + "?fias_guid=" + Fias.ToString());

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();

                var root = JsonDocument.Parse(json).RootElement;

                try
                {
                    var firstCity = root.EnumerateArray().First();

                    return JsonSerializer.Deserialize<City>(firstCity);
                }
                catch
                {
                    throw new Exception("City with this FIAS not found");
                }
            }
            else
            {
                throw new Exception((int)response.StatusCode + " " + response.StatusCode.ToString());
            }
        }
    }
}
