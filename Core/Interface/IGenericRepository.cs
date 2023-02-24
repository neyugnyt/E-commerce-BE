using Core.Entiies;
using Core.Specifications;

namespace Core.Interface
{
    public interface IGenericRepository<T> where T : BaseEnity
    {
        Task<T> GetByIdAsync(int id);
        Task<IReadOnlyList<T>> GetAllAsync();
        Task<T> GetEntityWithSpec(ISpecification<T> spec);
        Task<IReadOnlyList<T>> GetAsync(ISpecification<T> spec);
    }
}
