using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class RoomBookingDTO
    {
        public int Id { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public double? TotalDays { get; set; }
        public double TotalCost { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public int RoomId { get; set; }
        [ForeignKey("RoomId")]
        public RoomDTO Room { get; set; }

        public string? Status { get; set; }


    }
}
