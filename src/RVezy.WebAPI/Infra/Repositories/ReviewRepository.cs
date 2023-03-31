using System;
using Microsoft.EntityFrameworkCore;
using RVezy.WebAPI.Domain.Entities;
using RVezy.WebAPI.Domain.Interfaces;
using RVezy.WebAPI.Infra.Data;

namespace RVezy.WebAPI.Infra.Repositories
{
    public class ReviewRepository : IRepositoryBase<ReviewEntity>
    {
        private readonly MainContext _context;

        public ReviewRepository(MainContext context)
        {
            _context = context;
        }

        public async Task<bool> Delete(int id)
        {
            var review = await _context.Reviews.FindAsync(id);
            if (review == null)
            {
                return false;
            }

            _context.Reviews.Remove(review);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<ReviewEntity>> Get()
        {
            return await _context.Reviews.ToListAsync();
        }

        public async Task<ReviewEntity> GetById(int id)
        {
            var review = await _context.Reviews.FindAsync(id);

            return review;
        }

        public async Task<bool> Post(ReviewEntity entity)
        {
            _context.Reviews.Add(entity);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> Put(int id, ReviewEntity entity)
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
                if (!ReviewExists(id))
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

        private bool ReviewExists(int id)
        {
            return _context.Reviews.Any(e => e.Id == id);
        }
    }
}

