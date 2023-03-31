using System;
using RVezy.WebAPI.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using CsvHelper.Configuration.Attributes;

namespace RVezy.WebAPI.Domain.Models
{
	public class ListingModel
	{
        [Name("id")]
        public int Id { get; set; }
        [Name("listing_url")]
        public string? ListingUrl { get; set; }
        [Name("name")]
        public string? Name { get; set; }
        [Name("description")]
        public string? Description { get; set; }
        [Name("property_type")]
        public string? PropertyType { get; set; }
    }
}

