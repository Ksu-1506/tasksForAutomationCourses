using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Task8ForCourses
{
    public class Shipment
    {
        [JsonPropertyName("shipmentid")]
        public string ShipmentId { get; set; }
        [JsonPropertyName("deliveryaddress")]
        public string DeliveryAddress { get; set; }
        [JsonPropertyName("orders")]
        public List<Order> Orders { get; set; }
    }
}
