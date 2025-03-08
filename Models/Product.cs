using Newtonsoft.Json;

namespace EjemoloMVC.Models
{
    public class Dog
    {
        public string Id { get; set; } = string.Empty;

        [JsonProperty("url")]
        public string ImageUrl { get; set; } = string.Empty;

        [JsonProperty("breeds")]
        public List<Breed>? Breeds { get; set; } = new();
    }

    public class Breed
    {
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;

        [JsonProperty("life_span")]
        public string LifeSpan { get; set; } = string.Empty;

        [JsonProperty("bred_for")]
        public string BredFor { get; set; } = string.Empty;

        public string Temperament { get; set; } = string.Empty;

        [JsonProperty("image")]
        public Image? Image { get; set; } // Propiedad para la imagen
    }

    public class Image
    {
        [JsonProperty("id")]
        public string Id { get; set; } = string.Empty;

        [JsonProperty("url")]
        public string Url { get; set; } = string.Empty;
    }
}
