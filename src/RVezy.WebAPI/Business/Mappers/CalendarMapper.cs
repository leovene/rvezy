using System;
using RVezy.WebAPI.Domain.Entities;
using RVezy.WebAPI.Domain.Models;

namespace RVezy.WebAPI.Business.Mappers
{
    public static class CalendarMapper
    {
        public static CalendarEntity ToEntity(this CalendarModel model)
        {
            return new CalendarEntity
            {
                ListingId = model.ListingId,
                Date = model.Date,
                Available = model.Available,
                Price = model.Price
            };
        }
    }
}

