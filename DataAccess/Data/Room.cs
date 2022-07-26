using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data
{
    public class Room
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int Occupancy { get; set; }

        [Required]
        public double RegularRate { get; set; }
        public string? Description { get; set; }

        public string? CreatedBy { get; set; }
        public DateTime? CreatedDate_18118020 { get; set; } = DateTime.UtcNow;
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedDate_18118020 { get; set; }

        public virtual ICollection<RoomImage>? Images { get; set; }

    }
}
