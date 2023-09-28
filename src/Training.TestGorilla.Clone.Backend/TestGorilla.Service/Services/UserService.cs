using System.Linq.Expressions;
using TestGorilla.Data.Data;
using TestGorilla.Domain.Models;
using TestGorilla.Service.Helpers;
using TestGorilla.Service.Services.Interfaces;

namespace TestGorilla.Service.Services;

public class UserService : IUserService
{
    private readonly IDataContext _appDateContext;
    private readonly IValidatorService _validatorService;

    public UserService(IDataContext appDateContext, IValidatorService validatorService)
    {
        _appDateContext = appDateContext;
        _validatorService = validatorService;
    }

    public async ValueTask<User> CreateAsync(User user, bool saveChanges = true)
    {
        await _appDateContext.SaveChangesAsync();
        if (saveChanges)
            await _appDateContext.SaveChangesAsync();
        return user;
    }

    public async ValueTask<User> DeleteAsync(User user, bool saveChanges = true)
    {
        var existUser = await GetByIdAsync(user.Id);
        if (existUser is null)
            throw new InvalidOperationException("User not found");

        await _appDateContext.SaveChangesAsync();
        return existUser;
    }

    public ValueTask<User> DeleteAsync(Guid id, bool saveChanges = true)
    {
        throw new NotImplementedException();
    }

    public IQueryable<User> Get(Expression<Func<User, bool>> predicate)
    {
        return _appDateContext.Users.Where(predicate.Compile()).AsQueryable();
    }

    public ValueTask<ICollection<User>> GetAsync(IEnumerable<Guid> ids)
    {
        var users = _appDateContext.Users.Where(user => ids.Contains(user.Id));
        return new ValueTask<ICollection<User>>(users.ToList());
    }

    public ValueTask<User?> GetByIdAsync(Guid id)
    {
        var user = _appDateContext.Users.FirstOrDefault(user => user.Id == id);
        return new ValueTask<User?>(user);
    }

    public async ValueTask<User> UpdateAsync(User user, bool saveChanges = true)
    {
        var existUser = _appDateContext.Users.FirstOrDefault(searchingUser => searchingUser.Id == user.Id);

        if (existUser is null)
            throw new InvalidOperationException("User not found");

        existUser.FirstName = user.FirstName;
        existUser.LastName = user.LastName;
        existUser.EmailAddress = user.EmailAddress;
        existUser.PhoneNumber = user.PhoneNumber;

        await _appDateContext.SaveChangesAsync();
        return existUser;
    }
}
