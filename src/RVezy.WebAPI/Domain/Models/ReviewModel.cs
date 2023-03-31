using System;
using CsvHelper.Configuration.Attributes;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace RVezy.WebAPI.Domain.Models
{
    public class ReviewModel
	{
        [Name("listing_id")]
        public int ListingId { get; set; }
        [Name("id")]
        public int Id { get; set; }
        [Name("date")]
        public DateTime Date { get; set; }
        [Name("reviewer_id")]
        public int ReviewerId { get; set; }
        [Name("reviewer_name")]
        public string? ReviwerName { get; set; }
        [Name("comments")]
        public string? Comments { get; set; }
    }
}

