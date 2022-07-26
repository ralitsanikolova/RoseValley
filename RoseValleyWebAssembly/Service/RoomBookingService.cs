using Models;
using Newtonsoft.Json;
using RoseValleyWebAssembly.Service.IService;
using System.Net.Http.Json;
using System.Text;

namespace RoseValleyWebAssembly.Service
{
    public class RoomBookingService : IRoomBookingSevice
    {
        private readonly HttpClient _httpClient;

        public RoomBookingService(HttpClient httpClient)
        {
            _httpClient = httpClient; 
        }

        public async Task<RoomBookingDTO> BookingVilla(RoomBookingDTO request)
        {
            var result = await _httpClient.PostAsJsonAsync("api/booking/book", request);
            return await result.Content.ReadFromJsonAsync<RoomBookingDTO>(); 
        }

       

        public async Task<RoomBookingDTO> SaveBookingDetails(RoomBookingDTO bookingDetails)
        {
            //Because of an error of User
            bookingDetails.Id = 12345;

            var content = JsonConvert.SerializeObject(bookingDetails);
            var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");
            var responce = await _httpClient.PostAsync("api/booking/book", bodyContent);                     

            if (responce.IsSuccessStatusCode)
            {
                var contentTemp = await responce.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<RoomBookingDTO>(contentTemp);
                return result;
            }
            else
            {
                var contentBook = await responce.Content.ReadAsStringAsync();
                var errorModel = JsonConvert.DeserializeObject<Error>(content);
                throw new Exception(errorModel.Message);
            }
        }
    }
}


