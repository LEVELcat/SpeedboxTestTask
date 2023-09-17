using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CDEK_library
{
    public class City
    {
        [JsonPropertyName("code")]
        public int Code { get; set; }

        [JsonPropertyName("city")]
        public string Name { get; set; }
    }
}
