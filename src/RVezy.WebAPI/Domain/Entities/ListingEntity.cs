using System;
using System.ComponentModel.DataAnnotations;
using RVezy.WebAPI.Domain.Enums;
using RVezy.WebAPI.Domain.Interfaces;

namespace RVezy.WebAPI.Domain.Entities
{
	public class ListingEntity : IEntityBase
    {
		public int Id { get; set; }
        [Required]
        public string? ListingUrl { get; set; }
        [Required]
        public string? Name { get; set; }
		public string? Description { get; set; }
		public PropertyType PropertyType { get; set; }
	}
}

