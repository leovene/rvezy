using System;
using Microsoft.EntityFrameworkCore;
using RVezy.WebAPI.Domain.Entities;
using RVezy.WebAPI.Domain.Interfaces;
using RVezy.WebAPI.Infra.Data;

namespace RVezy.WebAPI.Infra.Repositories
{
    public class CalendarRepository : IRepositoryBase<CalendarEntity>
    {
        private readonly MainContext _context;

        public CalendarRepository(MainContext context)
        {
            _context = context;
        }

        public async Task<bool> Delete(int id)
        {
            var calendar = await _context.Calendars.FindAsync(id);
            if (calendar == null)
            {
                return false;
            }

            _context.Calendars.Remove(calendar);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<CalendarEntity>> Get()
        {
            return await _context.Calendars.ToListAsync();
        }

        public async Task<CalendarEntity> GetById(int id)
        {
            var calendar = await _context.Calendars.FindAsync(id);

            return calendar;
        }

        public async Task<bool> Post(CalendarEntity entity)
        {
            _context.Calendars.Add(entity);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> Put(int id, CalendarEntity entity)
        {
            if (id != entity.Id)
            {
                return false;
            }

            _context.Entry(entity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CalendarExists(id))
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }

            return true;
        }

        private bool CalendarExists(int id)
        {
            return _context.Calendars.Any(e => e.Id == id);
        }
    }
}

