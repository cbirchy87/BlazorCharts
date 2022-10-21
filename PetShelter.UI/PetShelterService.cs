using System.Net.Http.Json;
using System.Security.Cryptography;

namespace PetShelter.UI
{
    public class PetShelterService
    {
        private readonly HttpClient httpClient;

        public PetShelterService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public string GetBaseUrl()
        {
            return httpClient.BaseAddress.ToString();
        }
        public async Task<List<Animal>> GetAllAnimals()
        {
           var response =  await httpClient.GetAsync("Animal");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<List<Animal>>();
            }
            throw new Exception("NoData");
        }
        public async Task<List<Animal>> GetAnimalByType(string type)
        {
            var response = await httpClient.GetAsync($"Animal/type?type={type}");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<List<Animal>>();
            }
            throw new Exception("NoData");
        }


    }
}
