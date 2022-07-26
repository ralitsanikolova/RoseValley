﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class RoomDTO
    {
        //Required for client side validation
        public int Id { get; set; }

        [Required(ErrorMessage ="Please enter room name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter occupancy")]
        public int Occupancy { get; set; }

        [Range(1,1000, ErrorMessage ="Price must be between 1 and 1000")]
        public double RegularRate { get; set; }
        public string? Description { get; set; }

        public double TotalDays { get; set; }
        public double TotalAmount { get; set; }

        public virtual ICollection<RoomImageDTO> RoomImages { get; set; }
        public List<string>? ImageUrls { get; set; }

    }
}
