using Catalog.API.Entities;

namespace Catalog.API.Repositories.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task CreateEntity(T entity);
        Task<bool> UpdateEntity(T entity);
        Task<bool> DeleteEntity(string id);
    }
}
