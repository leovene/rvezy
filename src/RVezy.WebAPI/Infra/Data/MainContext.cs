using System;
using Microsoft.EntityFrameworkCore;
using System.Xml;
using RVezy.WebAPI.Domain.Entities;

namespace RVezy.WebAPI.Infra.Data
{
    public class MainContext : DbContext
    {
        public MainContext(DbContextOptions<MainContext> options) : base(options)
        {
        }

        public DbSet<ListingEntity> Listings { get; set; }
        public DbSet<CalendarEntity> Calendars { get; set; }
        public DbSet<ReviewEntity> Reviews { get; set; }
    }
}

