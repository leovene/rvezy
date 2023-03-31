using System;
using CsvHelper.Configuration.Attributes;

namespace RVezy.WebAPI.Domain.Models
{
	public class CalendarModel
	{
        [Name("listing_id")]
        public int ListingId { get; set; }
        [Name("date")]
        public DateTime Date { get; set; }
        [Name("available")]
        public bool Available { get; set; }
        [Name("price")]
        public string? Price { get; set; }
	}
}

