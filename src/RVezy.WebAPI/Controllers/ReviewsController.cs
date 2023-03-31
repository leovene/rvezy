using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RVezy.WebAPI.Domain.Entities;
using RVezy.WebAPI.Infra.Data;
using RVezy.WebAPI.Infra.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace RVezy.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        private readonly ReviewRepository _repository;

        public ReviewsController(ReviewRepository repository)
        {
            _repository = repository;
        }

        // GET: api/Reviews
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReviewEntity>>> GetReviews()
        {
            var result = await _repository.Get();

            return Ok(result);
        }

        // GET: api/Reviews/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ReviewEntity>> GetReview(int id)
        {
            var result = await _repository.GetById(id);

            if (result == null)
            {
                return NotFound();
            }

            return result;
        }

        // PUT: api/Reviews/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReview(int id, ReviewEntity review)
        {
            if (id != review.Id)
            {
                return BadRequest();
            }

            if (await _repository.Put(id, review))
            {
                return NoContent();
            }

            return NotFound();
        }

        // POST: api/Reviews
        [HttpPost]
        public async Task<ActionResult<ReviewEntity>> PostReview(ReviewEntity review)
        {
            await _repository.Post(review);

            return CreatedAtAction(nameof(GetReview), new { id = review.Id }, review);
        }

        // DELETE: api/Reviews/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReview(int id)
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


