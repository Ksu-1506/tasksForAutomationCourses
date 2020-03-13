using System.Text.Json.Serialization;

namespace Task8ForCourses
{
    public class Customer
    {
        [JsonPropertyName("customerid")]
        public string CustomerId { get; set; }
        [JsonPropertyName("customername")]
        public string CustomerName { get; set; }
        public override string ToString()
        {
            return $"CustomerID: {CustomerId} CustomerName: {CustomerName}";
        }

    }
}
