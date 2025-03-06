using EjemoloMVC.Models;
using Newtonsoft.Json;

namespace EjemoloMVC.Services
{
    public class PokemonService
    {
        private readonly HttpClient _httpClient;

        public PokemonService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<PokemonResponse> GetPokemonsAsync(int offset = 0, int limit = 20)
        {
            var response = await _httpClient.GetStringAsync($"https://pokeapi.co/api/v2/pokemon?offset={offset}&limit={limit}");
            var pokemons = JsonConvert.DeserializeObject<PokemonResponse>(response);

            if (pokemons?.Results != null)
            {
                foreach (var item in pokemons.Results)
                {
                    // Extraemos el ID desde la URL, que siempre termina en /{id}/
                    var segments = item.Url.TrimEnd('/').Split('/');
                    var id = segments.Last();

                    // Generamos la URL de la imagen
                    item.ImageUrl = $"https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/{id}.png";
                }
            }

            return pokemons ?? new PokemonResponse();
        }



        public async Task<Pokemon> GetPokemonAsync(string param)
        {
            var response = await _httpClient.GetStringAsync($"https://pokeapi.co/api/v2/pokemon/{param}");
            var pokemon = JsonConvert.DeserializeObject<Pokemon>(response);

            if (pokemon == null)
            {
                throw new Exception("No se pudo deserializar el Pokémon.");
            }

            return pokemon;
        }
    }

    public class PokemonResponse
    {
        public int Count { get; set; }
        public string Next { get; set; }
        public string Previous { get; set; }
        public List<PokemonItem> Results { get; set; }
    }

    public class PokemonItem
    {
        public string Name { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
    }

}