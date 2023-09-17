using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CDEK_library
{
    public abstract class Client
    {
        [JsonIgnore]
        protected Token token;

        public Client(string Account, string SecurePassword) : this(Token.GetToken(Account, SecurePassword))
        { }

        protected Client(Token token)
        {
            this.token = token;
        }
    }
}
