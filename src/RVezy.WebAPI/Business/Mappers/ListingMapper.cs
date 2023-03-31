using System;
using RVezy.WebAPI.Domain.Entities;
using RVezy.WebAPI.Domain.Enums;
using RVezy.WebAPI.Domain.Models;

namespace RVezy.WebAPI.Business.Mappers
{
    public static class ListingMapper
    {
        public static ListingEntity ToEntity(this ListingModel model)
        {
            return new ListingEntity
            {
                Id = model.Id,
                ListingUrl = model.ListingUrl ?? throw new ArgumentNullException(nameof(model.ListingUrl)),
                Name = model.Name ?? throw new ArgumentNullException(nameof(model.Name)),
                Description = model.Description,
                PropertyType = MapPropertyType(model.PropertyType)
            };
        }

        private static PropertyType MapPropertyType(string? propertyType)
        {
            if (string.IsNullOrWhiteSpace(propertyType))
            {
                return PropertyType.House;
            }

            propertyType = propertyType.Trim();

            switch (propertyType.ToLower())
            {
                case "apartment":
                    return PropertyType.Apartment;
                default:
                    return PropertyType.House;
            }
        }
    }

}

