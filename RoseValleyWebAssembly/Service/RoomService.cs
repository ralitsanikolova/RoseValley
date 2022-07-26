using Models;
using Newtonsoft.Json;
using RoseValleyWebAssembly.Service.IService;

namespace RoseValleyWebAssembly.Service
{
    public class RoomService : IRoomService
    {
        private readonly HttpClient _client;
        public RoomService(HttpClient client)
        {
            _client = client;
        }
        public async Task<RoomDTO> GetRoomDetail(int roomId, string checkIn, string checkOut)
        {
            var responce = await _client.GetAsync($"/api/room/{roomId}?checkIn={checkIn}&checkOut={checkOut}");

            if (responce.IsSuccessStatusCode)
            {
                var content = await responce.Content.ReadAsStringAsync();
                var room = JsonConvert.DeserializeObject<RoomDTO>(content); 
                return room;
            }
            else
            {
                var content = await responce.Content.ReadAsStringAsync();
                var errorModel = JsonConvert.DeserializeObject<Error>(content);
                throw new Exception(errorModel.Message);
            }
        }

        public async Task<IEnumerable<RoomDTO>> GetRooms(string checkIn, string checkOut)
        {
            var responce = await _client.GetAsync($"/api/room?checkIn={checkIn}&checkOut={checkOut}");

            var content =  await responce.Content.ReadAsStringAsync();
            var rooms = JsonConvert.DeserializeObject<IEnumerable<RoomDTO>>(content);
            return rooms;
        }
    }
}
