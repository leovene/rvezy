using System;
using Microsoft.AspNetCore.Mvc;
using RVezy.WebAPI.Domain.Entities;

namespace RVezy.WebAPI.Domain.Interfaces
{
	public interface IRepositoryBase<T> where T: IEntityBase
	{
        Task<IEnumerable<T>> Get();
        Task<T> GetById(int id);
        Task<bool> Put(int id, T entity);
        Task<bool> Post(T entity);
        Task<bool> Delete(int id);
    }
}

