using System;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using RVezy.WebAPI.Domain.Entities;
using RVezy.WebAPI.Domain.Interfaces;
using RVezy.WebAPI.Infra.Data;

namespace RVezy.WebAPI.Infra.Repositories
{
	public class ListingRepository : IRepositoryBase<ListingEntity>
	{
        private readonly MainContext _context;

        public ListingRepository(MainContext context)
		{
            _context = context;
        }

        public async Task<bool> Delete(int id)
        {
            var listing = await _context.Listings.FindAsync(id);
            if (listing == null)
            {
                return false;
            }

            _context.Listings.Remove(listing);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<ListingEntity>> Get()
        {
            return await _context.Listings.ToListAsync();
        }

        public async Task<ListingEntity> GetById(int id)
        {
            var listing = await _context.Listings.FindAsync(id);

            return listing;
        }

        public async Task<bool> Post(ListingEntity entity)
        {
            _context.Listings.Add(entity);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> Put(int id, ListingEntity entity)
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
                if (!ListingExists(id))
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

        private bool ListingExists(int id)
        {
            return _context.Listings.Any(e => e.Id == id);
        }
    }
}