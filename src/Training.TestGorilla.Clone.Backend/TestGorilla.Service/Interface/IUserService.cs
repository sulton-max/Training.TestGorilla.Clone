using System.Linq.Expressions;
using TestGorilla.Domain.Entities.Users;

namespace TestGorilla.Service.Interface;

public interface IUserService
{
    IQueryable<User> Get(Expression<Func<User, bool>> predicate);
    ValueTask<User> GetByIdAsync(Guid id);
    ValueTask<User> CreateAsync(User user, bool saveChanges = true, CancellationToken cancellationToken = default);
    ValueTask<User> UpdateAsync(User user, bool saveChanges = true, CancellationToken cancellationToken = default);
    ValueTask<User> DeleteAsync(Guid userId, bool saveChanges = true, CancellationToken cancellationToken = default);
}
