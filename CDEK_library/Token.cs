using System.Text.Json;
using System.Text.Json.Serialization;

namespace CDEK_library
{
    public struct Token
    {
        [JsonPropertyName("access_token")]
        internal string AccesToken { get; set; }

        public Token(string AccesToken)
        {
            this.AccesToken = AccesToken;
        }

        public static Token DeserializeFromJson(string json) => JsonSerializer.Deserialize<Token>(json);

        public static Token GetToken(string Account, string SecurePassword) => GetTokenAsync(Account, SecurePassword).Result;
        public static async Task<Token> GetTokenAsync(string Account, string SecurePassword)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://api.edu.cdek.ru");

            var response = await client.PostAsync(
                "/v2/oauth/token" + "?" +
                "grant_type=client_credentials" + "&" +
                $"client_id={Account}" + "&" +
                $"client_secret={SecurePassword}", 
                null);

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();

                var root = JsonDocument.Parse(json).RootElement;


                return new Token(root.GetProperty("access_token").ToString());
            }
            else
                throw new Exception((int)response.StatusCode + " " + response.StatusCode.ToString());
        } 
    }
}
