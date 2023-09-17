using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CDEK_library
{
    public partial class DeliveryCostCalculator : Client
    {
        internal class BodyOfResponce
        {
            [JsonPropertyName("tariff_code")]
            public int TariffeCode { get; set; }

            [JsonPropertyName("delivery_mode")]
            public int DeliveryMode { get; set; }
            [JsonPropertyName("delivery_sum")]
            public float DeliverySum { get; set; }

            public BodyOfResponce(int deliveryMode, float deliverySum)
            {
                DeliveryMode = deliveryMode;
                DeliverySum = deliverySum;
            }
        }
    }
}
