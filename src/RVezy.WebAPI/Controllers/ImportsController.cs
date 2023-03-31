using System;
using Microsoft.AspNetCore.Mvc;
using RVezy.WebAPI.Business.Mappers;
using RVezy.WebAPI.Domain.Entities;
using RVezy.WebAPI.Infra.Repositories;
using RVezy.WebAPI.Services;

namespace RVezy.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImportsController : ControllerBase
    {
        private readonly ListingRepository _listingRepository;
        private readonly CalendarRepository _calendarRepository;
        private readonly ReviewRepository _reviewRepository;
        private readonly CSVParseService _parse;

        public ImportsController(ListingRepository listingRepository, CalendarRepository calendarRepository,
            ReviewRepository reviewRepository, CSVParseService parse)
        {
            _listingRepository = listingRepository;
            _calendarRepository = calendarRepository;
            _reviewRepository = reviewRepository;
            _parse = parse;
        }

        // GET: api/Linsting
        [HttpGet]
        [Route("Listing")]
        public async Task<ActionResult<IEnumerable<CalendarEntity>>> ImportListing()
        {
            var result = _parse.ToListingModel("listings.csv");
            var entities = result.Select(c => c.ToEntity()).ToList();

            foreach(var entity in entities)
            {
                await _listingRepository.Delete(entity.Id);
                await _listingRepository.Post(entity);
            }

            return Ok(result);
        }

        // GET: api/Calendar
        [HttpGet]
        [Route("Calendar")]
        public async Task<ActionResult<IEnumerable<CalendarEntity>>> ImportCalendar()
        {
            var result = _parse.ToCalendarModel("calendar.csv");
            var entities = result.Select(c => c.ToEntity()).ToList();

            foreach (var entity in entities)
            {
                await _calendarRepository.Delete(entity.Id);
                await _calendarRepository.Post(entity);
            }

            return Ok(result);
        }

        // GET: api/Review
        [HttpGet]
        [Route("Review")]
        public async Task<ActionResult<IEnumerable<CalendarEntity>>> ImportReview()
        {
            var result = _parse.ToReviewModel("reviews.csv");
            var entities = result.Select(c => c.ToEntity()).ToList();

            foreach (var entity in entities)
            {
                await _reviewRepository.Delete(entity.Id);
                await _reviewRepository.Post(entity);
            }

            return Ok(result);
        }
    }
}

