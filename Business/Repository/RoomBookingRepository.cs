using AutoMapper;
using Business.Repository.IRepository;
using CommonFiles;
using DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Business.Repository
{
    public class RoomBookingRepository : IRoomBookingRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public RoomBookingRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<RoomBookingDTO> CreateBooking(RoomBookingDTO bookingDetails)
        {
            try
            {
                bookingDetails.CheckIn = bookingDetails.CheckIn.Date;
                bookingDetails.CheckOut = bookingDetails.CheckOut.Date;

                var roomBooking = _mapper.Map<RoomBookingDTO, RoomBooking>(bookingDetails);
                roomBooking.Status = SD.Status_Pending;
                var result = await _context.RoomBookings.AddAsync(roomBooking);
                await _context.SaveChangesAsync();

                return _mapper.Map<RoomBooking, RoomBookingDTO>(result.Entity);

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<int> DeleteBooking(int bookId)
        {
            var details = await _context.RoomBookings.FindAsync(bookId);
            if (details != null)
            {
                _context.Remove(details);
                return await  _context.SaveChangesAsync();
            }
            return 0;     
        }

        public async Task<IEnumerable<RoomBookingDTO>> GetAllBookings()
        {
            IEnumerable<RoomBookingDTO> bookings = _mapper.Map<IEnumerable<RoomBooking>, IEnumerable<RoomBookingDTO>>(
                _context.RoomBookings.Include(u => u.Room));

            return bookings;
        }

        public async Task<RoomBookingDTO> GetBooking(int orderId)
        {
            RoomBooking bookings = await _context.RoomBookings
                            .Include(r => r.Room)
                            .ThenInclude(ri => ri.Images)
                            .FirstOrDefaultAsync(i => i.Id == orderId);

            var detailsDTO = _mapper.Map<RoomBooking, RoomBookingDTO>(bookings);
            detailsDTO.TotalDays = detailsDTO.CheckOut.Subtract(detailsDTO.CheckIn).Days;
            return detailsDTO;

        }

        public async Task<bool> IsItBooked(int roomId, DateTime checkIn, DateTime checkOut)
        {
            // check if the choosed for CheckIn and CheckOut dates is not choosed betweeen the days the villa is booked
            var status = false;
            var existingBooking = await _context.RoomBookings.Where(x => x.RoomId == roomId &&
            (checkIn < x.CheckOut && checkIn.Date > x.CheckIn || checkOut.Date > x.CheckOut && checkOut.Date < x.CheckOut.Date)).FirstOrDefaultAsync();

            if (existingBooking != null)
            {
                status = true;
            }
            return status;
        }

    }
}
