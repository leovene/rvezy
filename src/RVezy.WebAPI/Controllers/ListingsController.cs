using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RVezy.WebAPI.Domain.Entities;
using RVezy.WebAPI.Infra.Data;
using RVezy.WebAPI.Infra.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RVezy.WebAPI.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class ListingsController : ControllerBase
    {
        private readonly ListingRepository _repository;

        public ListingsController(ListingRepository repository)
        {
            _repository = repository;
        }

        // GET: api/Listings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ListingEntity>>> GetListings()
        {
            var result = await _repository.Get();

            return Ok(result);
        }

        // GET: api/Listings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ListingEntity>> GetListing(int id)
        {
            var result = await _repository.GetById(id);

            if (result == null)
            {
                return NotFound();
            }

            return result;
        }

        // PUT: api/Listings/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutListing(int id, ListingEntity listing)
        {
            if (id != listing.Id)
            {
                return BadRequest();
            }

            if (await _repository.Put(id, listing))
            {
                return NoContent();
            }

            return NotFound();
        }

        // POST: api/Listings
        [HttpPost]
        public async Task<ActionResult<ListingEntity>> PostListing(ListingEntity listing)
        {
            await _repository.Post(listing);

            return CreatedAtAction(nameof(GetListing), new { id = listing.Id }, listing);
        }

        // DELETE: api/Listings/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteListing(int id)
        {
            var result = await _repository.Delete(id);

            if (result)
            {
                return NoContent();
            }

            return NotFound();
        }
    }

}

