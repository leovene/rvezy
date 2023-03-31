using System;
using CsvHelper.Configuration.Attributes;
using RVezy.WebAPI.Domain.Interfaces;

namespace RVezy.WebAPI.Domain.Entities
{
	public class ReviewEntity : IEntityBase
    {
        public int Id { get; set; }
        public int ListingId { get; set; }
        public DateTime Date { get; set; }
        public int ReviewerId { get; set; }
        public string? ReviwerName { get; set; }
        public string? Comments { get; set; }
    }
}

