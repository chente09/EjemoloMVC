using EjemoloMVC.Models;
using Newtonsoft.Json;

namespace EjemoloMVC.Services
{
    public class DogService
    {
        private readonly HttpClient _httpClient;

        public DogService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://api.thedogapi.com/v1/");
        }

        // Obtener la lista de razas
        public async Task<List<Breed>> GetBreedsAsync(int page = 1, int limit = 10)
        {
            var response = await _httpClient.GetStringAsync($"breeds?page={page}&limit={limit}");
            var breeds = JsonConvert.DeserializeObject<List<Breed>>(response) ?? new List<Breed>();

            // Si una raza no tiene imagen, intenta obtener una
            foreach (var breed in breeds)
            {
                if (breed.Image == null || string.IsNullOrEmpty(breed.Image.Url))
                {
                    var imgResponse = await _httpClient.GetStringAsync($"images/search?breed_id={breed.Id}");
                    var images = JsonConvert.DeserializeObject<List<Image>>(imgResponse);
                    if (images != null && images.Count > 0)
                    {
                        breed.Image = images.First();
                    }
                }
            }

            return breeds;
        }


        // Obtener detalles de una raza por ID
        public async Task<Breed> GetBreedByIdAsync(string id)
        {
            var response = await _httpClient.GetStringAsync($"breeds/{id}");
            var breed = JsonConvert.DeserializeObject<Breed>(response) ?? new Breed();

            // Si la raza no tiene imagen, buscarla en el endpoint de imágenes
            if (breed.Image == null || string.IsNullOrEmpty(breed.Image.Url))
            {
                var imgResponse = await _httpClient.GetStringAsync($"images/search?breed_id={id}");
                var images = JsonConvert.DeserializeObject<List<Image>>(imgResponse);
                if (images != null && images.Count > 0)
                {
                    breed.Image = images.First();
                }
            }

            return breed;
        }

    }
}