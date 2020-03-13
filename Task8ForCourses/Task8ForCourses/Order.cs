using System.Text.Json.Serialization;

namespace Task8ForCourses
{
    public class Order
    {
        [JsonPropertyName("orderid")]
        public int OrderId { get; set; }
        [JsonPropertyName("productquantity")]
        public int ProductQuantity { get; set; }
        [JsonPropertyName("producttype")]
        public string ProductType { get; set; }
        [JsonPropertyName("customer")]
        public Customer Customer { get; set; }

        public override string ToString()
        {
            return $"OrderID: {OrderId} ProductQuantity: {ProductQuantity} ProductType: {ProductType}";
        }

    }
}
