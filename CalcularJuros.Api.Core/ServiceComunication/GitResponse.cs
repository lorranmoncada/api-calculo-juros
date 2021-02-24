using Newtonsoft.Json;

namespace CalcularJuros.ServiceJuros
{
    public class GitResponse
    {
        public GitResponse(){}

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string name { get; set; }


        [JsonProperty("html_url")]
        public string html_url { get; set; }
    }
}

