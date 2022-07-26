using Business.Repository.IRepository;
using CommonFiles;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models;
using System.Globalization;

namespace RoseValleyAPI.Controllers
{
    [Route("api/[controller]")]
    public class RoomController : Controller
    {
        //Get all villas and get 1 villa 
       
        private readonly IRoomRepository _roomRepository;

        public RoomController(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRooms(string checkIn = null, string checkOut = null)
        {
            if (string.IsNullOrEmpty(checkIn) || string.IsNullOrEmpty(checkOut))
            {
                return BadRequest(new Error()
                {
                    StatusCode = StatusCodes.Status400BadRequest,
                    Message = "All parameters are needed"
                });
            }
            if (!DateTime.TryParseExact(checkIn, "MM/dd/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out var dtCheckIn))
            {
                return BadRequest(new Error()
                {
                    StatusCode = StatusCodes.Status400BadRequest,
                    Message = "The needed format is MM/dd/yyyy"
                });
            }
            if (!DateTime.TryParseExact(checkOut, "MM/dd/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out var dtCheckOut))
            {
                return BadRequest(new Error()
                {
                    StatusCode = StatusCodes.Status400BadRequest,
                    Message = "The needed format is MM/dd/yyyy"
                });
            }
            var allRooms = await _roomRepository.GetAllRooms(checkIn, checkOut);
            return Ok(allRooms);
        }

       // [Authorize(Roles = SD.Role_Admin)]
        [HttpGet("{roomId}")]
        public async Task<IActionResult> GetRoom(int? roomId, string checkIn = null, string checkOut = null)
        {
            if (roomId == null)
            {
                return BadRequest(new Error()
                {
                    Title = "Invalid Villa Id",
                    Message = "Id cannot be null",
                    StatusCode = StatusCodes.Status400BadRequest
                });
            }

            if (string.IsNullOrEmpty(checkIn) || string.IsNullOrEmpty(checkOut))
            {
                return BadRequest(new Error()
                {
                    StatusCode = StatusCodes.Status400BadRequest,
                    Message = "All parameters are needed"
                });
            }
            if (!DateTime.TryParseExact(checkIn, "MM/dd/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out var dtCheckIn))
            {
                return BadRequest(new Error()
                {
                    StatusCode = StatusCodes.Status400BadRequest,
                    Message = "The needed format is MM/dd/yyyy"
                });
            }
            if (!DateTime.TryParseExact(checkOut, "MM/dd/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out var dtCheckOut))
            {
                return BadRequest(new Error()
                {
                    StatusCode = StatusCodes.Status400BadRequest,
                    Message = "The needed format is MM/dd/yyyy"
                });
            }

            var details = await _roomRepository.GetRoom(roomId.Value, checkIn, checkOut);

            if (details == null)
            {
                return BadRequest(new Error()
                {
                    Title = "Invalid Villa Id",
                    Message = "Not Found",
                    StatusCode = StatusCodes.Status404NotFound
                });
            }

            return Ok(details);

        }
    }
}

