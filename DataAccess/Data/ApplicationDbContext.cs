using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data
{
    public  class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext( DbContextOptions<ApplicationDbContext> options) : base(options)
        { }

        public DbSet<Room> Rooms { get; set; }
        public DbSet<RoomImage> RoomsImages { get; set;}
        public DbSet<Amenity> Amenities { get; set; }
        public DbSet<RoomBooking> RoomBookings { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasDefaultSchema("18118020");
        }
    }
}
