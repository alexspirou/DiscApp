namespace Disc.Domain.Abstractions.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(uint id);
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Save();
    }

}
