using Newtonsoft.Json;

namespace EjemoloMVC.Models
{
    public class Pokemon
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
        public Sprites Sprites { get; set; } // Asegúrate de que esta propiedad esté correctamente mapeada
        public List<AbilityInfo> Abilities { get; set; }
        public List<TypeInfo> Types { get; set; }
    }

    public class Sprites
    {
        [JsonProperty("back_default")]
        public string BackDefault { get; set; }

        [JsonProperty("back_female")]
        public string BackFemale { get; set; }

        [JsonProperty("back_shiny")]
        public string BackShiny { get; set; }

        [JsonProperty("back_shiny_female")]
        public string BackShinyFemale { get; set; }

        [JsonProperty("front_default")]
        public string FrontDefault { get; set; }

        [JsonProperty("front_female")]
        public string FrontFemale { get; set; }

        [JsonProperty("front_shiny")]
        public string FrontShiny { get; set; }

        [JsonProperty("front_shiny_female")]
        public string FrontShinyFemale { get; set; }
    }

    public class AbilityInfo
    {
        public Ability Ability { get; set; }
    }

    public class Ability
    {
        public string Name { get; set; }
    }

    public class TypeInfo
    {
        public TypeDetail Type { get; set; }
    }

    public class TypeDetail
    {
        public string Name { get; set; }
    }
}