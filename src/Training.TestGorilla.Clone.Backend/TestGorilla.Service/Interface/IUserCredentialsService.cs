using System.Linq.Expressions;
using TestGorilla.Domain.Entities.Users;

namespace TestGorilla.Service.Interface;

public interface IUserCredentialsService
{
    IQueryable<UserCredentials> Get(Expression<Func<UserCredentials, bool>> expression);

    ValueTask<ICollection<UserCredentials>> Get(IEnumerable<Guid> ids);

    ValueTask<UserCredentials> GetById(Guid id);

    ValueTask<UserCredentials> CreateAsync(UserCredentials userCredentials, bool saveChanges = true, CancellationToken cancellation = default);

    ValueTask<UserCredentials> UpdateAsync(string password, UserCredentials userCredentials, bool saveChanges = true, CancellationToken cancellation = default);

    ValueTask<UserCredentials> DeleteAsync(UserCredentials userCredentials, bool saveChanges = true, CancellationToken cancellation = default);

    ValueTask<UserCredentials> DeleteAsync(Guid id, bool saveChanges = true, CancellationToken cancellation = default);
}