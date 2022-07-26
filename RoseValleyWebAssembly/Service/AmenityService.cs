using Models;
using Newtonsoft.Json;
using RoseValleyWebAssembly.Service.IService;

namespace RoseValleyWebAssembly.Service
{
    public class AmenityService : IAmenityService
    {
        private readonly HttpClient _httpClient;
        public AmenityService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<AmenityDTO>> GetAllAmenities()
        {
            var resp = await _httpClient.GetAsync($"/api/amenity");
            var content = await resp.Content.ReadAsStringAsync();
            var villas =JsonConvert.DeserializeObject<List<AmenityDTO>>(content);
            return villas;
        }
    }
}
