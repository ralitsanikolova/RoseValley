using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data
{
    public class Amenity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }
        public string? TimeForUsing { get; set; }
        public string? Icon { get; set; }


        public string? CreatedBy { get; set; }
        public DateTime? CreatedDate_18118020 { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedDate_18118020 { get; set; }

   
    }
}
