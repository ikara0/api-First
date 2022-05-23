using System.Text.Json.Serialization;

namespace BilgeAdam.Common.Dtos.Customer
{
    public class CustomerListDto
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("companyName")]
        public string CompanyName { get; set; }

        [JsonPropertyName("contactName")]
        public string ContactName { get; set; }

        [JsonPropertyName("contacTitle")]
        public string ContactTitle { get; set; }

        [JsonPropertyName("address")]
        public string Address { get; set; }

        [JsonPropertyName("phone")]
        public string Phone { get; set; }

        [JsonPropertyName("fax")]
        public string Fax { get; set; }
    }
}