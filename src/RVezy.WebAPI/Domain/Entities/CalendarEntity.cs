using System;
using RVezy.WebAPI.Domain.Interfaces;

namespace RVezy.WebAPI.Domain.Entities
{
	public class CalendarEntity : IEntityBase
    {
        public int Id { get; set; }
        public int ListingId { get; set; }
        public DateTime Date { get; set; }
        public bool Available { get; set; }
        public string? Price { get; set; }
    }
}

