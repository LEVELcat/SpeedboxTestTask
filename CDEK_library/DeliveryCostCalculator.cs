using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CDEK_library
{
    public partial class DeliveryCostCalculator : Client
    {
        public DeliveryCostCalculator(string Account, string SecurePassword) : base(Account, SecurePassword)
        {
        }

        public float GetDeliveryCost(Guid FiasUuidOfCitySending, Guid FiasUuidOfCityReceiving,
                                                  Package package) =>
                                     GetDeliveryCostAsync(FiasUuidOfCitySending, FiasUuidOfCityReceiving, package).Result;

        public async Task<float> GetDeliveryCostAsync(Guid FiasUuidOfCitySending, Guid FiasUuidOfCityReceiving,
                                                                   Package package)
        {
            BodyOfRequest bodyOfRequest = new BodyOfRequest(FiasUuidOfCitySending, FiasUuidOfCityReceiving, 
                                                                          package,token);

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://api.edu.cdek.ru");

            client.DefaultRequestHeaders.Add("Authorization", "Bearer" + " " + token.AccesToken);

            client.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            var content = JsonDocument.Parse(JsonSerializer.Serialize(bodyOfRequest));

            var response = await client.PostAsJsonAsync("/v2/calculator/tarifflist", content);


            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var document = JsonDocument.Parse(json);

                BodyOfResponce[] responces = JsonSerializer.Deserialize<BodyOfResponce[]>(document.RootElement.GetProperty("tariff_codes"));

                var filteredTariffe = responces.Where(x => x.DeliveryMode == 1).OrderBy(x => x.DeliverySum);

                return filteredTariffe.First().DeliverySum;
            }
            else

                throw new Exception((int)response.StatusCode + " " + response.StatusCode.ToString());
        }
    }
}
