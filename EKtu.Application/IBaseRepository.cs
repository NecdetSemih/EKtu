using EKtu.Domain.Common;

namespace EKtu.Application
{
    public interface IBaseRepository<T> where T : BaseEntity,new()
    {
        Task AddAsync(T entity);
        Task RemoveAsync(T entity);
        Task UpdateAsync(T entity);
        Task GetById(T entity);

    }
}
