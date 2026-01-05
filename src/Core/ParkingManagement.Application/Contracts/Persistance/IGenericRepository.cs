using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingManagement.Application.Contracts.Persistance
{
    public interface IGenericRepository <T> where T : class
    {
        public Task<IEnumerable<T>> GetAllAsync();
        public Task<T?> GetAsync(int id);
        public Task DeleteAsync(int id);
        public Task UpdateAsync(T entity);
        public Task<T> AddAsync(T entity);
    }
}
