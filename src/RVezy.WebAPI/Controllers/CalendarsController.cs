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
    public class CalendarsController : ControllerBase
    {
        private readonly CalendarRepository _repository;

        public CalendarsController(CalendarRepository repository)
        {
            _repository = repository;
        }

        // GET: api/Calendars
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CalendarEntity>>> GetCalendars()
        {
            var result = await _repository.Get();

            return Ok(result);
        }

        // GET: api/Calendars/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CalendarEntity>> GetCalendar(int id)
        {
            var result = await _repository.GetById(id);

            if (result == null)
            {
                return NotFound();
            }

            return result;
        }

        // PUT: api/Calendars/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCalendar(int id, CalendarEntity calendar)
        {
            if (id != calendar.Id)
            {
                return BadRequest();
            }

            if (await _repository.Put(id, calendar))
            {
                return NoContent();
            }

            return NotFound();
        }

        // POST: api/Calendars
        [HttpPost]
        public async Task<ActionResult<CalendarEntity>> PostCalendar(CalendarEntity calendar)
        {
            await _repository.Post(calendar);

            return CreatedAtAction(nameof(GetCalendar), new { id = calendar.Id }, calendar);
        }

        // DELETE: api/Calendars/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCalendar(int id)
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
