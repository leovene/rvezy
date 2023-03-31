using System;
using RVezy.WebAPI.Domain.Entities;
using RVezy.WebAPI.Domain.Models;

namespace RVezy.WebAPI.Business.Mappers
{
    public static class ReviewMapper
    {
        public static ReviewEntity ToEntity(this ReviewModel model)
        {
            return new ReviewEntity
            {
                Id = model.Id,
                ListingId = model.ListingId,
                Date = model.Date,
                ReviewerId = model.ReviewerId,
                ReviwerName = model.ReviwerName,
                Comments = model.Comments
            };
        }
    }
}

