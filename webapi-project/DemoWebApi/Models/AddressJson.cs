using Newtonsoft.Json;

namespace DemoWebApi.Models
{
    public class AddressJson
    {
        [JsonProperty("endereco")]
        public string Address { get; set; }

        [JsonProperty("cidade")]
        public string City { get; set; }

        [JsonProperty("uf")]
        public string Country { get; set; }

        [JsonProperty("bairro")]
        public string Neighborhood { get; set; }

        [JsonProperty("cep")]
        public long ZipCode { get; set; }
    }
}