using Business.Repository;
using Business.Repository.IRepository;
using DataAccess.Data;
using Microsoft.AspNetCore.Mvc;
using Models;
using Stripe.Checkout;

namespace RoseValleyAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BookingController : Controller
    {
        private readonly IRoomBookingRepository _roomBooking;
        private readonly ApplicationDbContext _context;
        public BookingController(IRoomBookingRepository roomBooking, ApplicationDbContext context)
        {
            _roomBooking = roomBooking;
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Book([FromBody] RoomBookingDTO details)
        {
            if (ModelState.IsValid)
            {
                var result = await _roomBooking.CreateBooking(details);
                return Ok(details);
            }
            else
            {
                return BadRequest(new Error()
                {
                    Message = "Error booking a villa."
                });
            }
        }

        
        

        //[HttpPost]
        //public async Task<ActionResult<RoomBookingDTO>> BookingVilla (RoomBookingDTO request)
        //{
        //    _context.Add(request);
        //    await _context.SaveChangesAsync();

        //    return Ok(request);
        //}
    }
}
