using System.Linq.Expressions;
using TestGorilla.Domain.Entities;

namespace TestGorilla.Service.Interface;

public interface ICategoryService
{
    IQueryable<Category> Get(Expression<Func<Category, bool>> expression);

    ValueTask<ICollection<Category>> Get(IEnumerable<Guid> id);

    ValueTask<Category> GetById(Guid id);

    ValueTask<Category> CreateAsync(Category category, bool saveChanges = true, CancellationToken cancellation = default);

    ValueTask<Category> UpdateAsync(string password, Category category, bool saveChanges = true, CancellationToken cancellation = default);

    ValueTask<Category> DeleteAsync(Category category, bool saveChanges = true, CancellationToken cancellation = default);

    ValueTask<Category> DeleteAsync(Guid id, bool saveChanges = true, CancellationToken cancellation = default);
}