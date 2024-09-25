using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OnionDemo.Domain.Entity;

namespace OnionDemo.Infrastructure
{
    public class BookMyHomeContext : DbContext
    {
        public BookMyHomeContext(DbContextOptions<BookMyHomeContext> options) 
            : base(options)
        {
        }

        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Accommodation> Accommodations { get; set; }
        public DbSet<Host> Hosts { get; set; }
        public DbSet<Review> Reviews { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);
        //    modelBuilder.Entity<Booking>()
        //        .HasOne(a => a.Accommodation)
        //        .WithMany(b => b.Bookings)
        //        .HasForeignKey(a => a.Id)
        //        .OnDelete(DeleteBehavior.Cascade);

        //    modelBuilder.Entity<Accommodation>()
        //        .HasOne(a => a.Host)
        //        .WithMany(b => b.Accommodations)
        //        .HasForeignKey(a => a.HostId)
        //        .OnDelete(DeleteBehavior.Cascade);
        //}
    }
}
