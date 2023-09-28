using System.Linq.Expressions;
using TestGorilla.Data.Data;
using TestGorilla.Domain.Models;
using TestGorilla.Service.Helpers;
using TestGorilla.Service.Services.Interfaces;

namespace TestGorilla.Service.Services;

public class UserCredentialsService : IUserCredentialsService
{
    private readonly IDataContext _appDataContext;
    private readonly IPasswordHasherService _passwordHasher;
    private readonly IValidatorService _validatorService;

    public UserCredentialsService(IDataContext appDataContext, IPasswordHasherService passwordHasher, IValidatorService validatorService)
    {
        _appDataContext = appDataContext;
        _passwordHasher = passwordHasher;
        _validatorService = validatorService;
    }

    public ValueTask<UserCredentials> CreateAsync(UserCredentials userCredentials, bool saveChanges = true, CancellationToken cancellation = default)
    {
        throw new NotImplementedException();
    }

    public ValueTask<UserCredentials> DeleteAsync(UserCredentials userCredentials, bool saveChanges = true, CancellationToken cancellation = default)
    {
        throw new NotImplementedException();
    }

    public ValueTask<UserCredentials> DeleteAsync(Guid id, bool saveChanges = true, CancellationToken cancellation = default)
    {
        throw new NotImplementedException();
    }

    public IQueryable<UserCredentials> Get(Expression<Func<UserCredentials, bool>> expression)
    {
        throw new NotImplementedException();
    }

    public ValueTask<ICollection<UserCredentials>> Get(IEnumerable<Guid> ids)
    {
        throw new NotImplementedException();
    }

    public ValueTask<UserCredentials> GetById(Guid id)
    {
        throw new NotImplementedException();
    }

    public ValueTask<UserCredentials> UpdateAsync(UserCredentials userCredentials, bool saveChanges = true, CancellationToken cancellation = default)
    {
        throw new NotImplementedException();
    }

    private bool IsExistsUserCredentials(UserCredentials userCredentials)
    {
        return true;
    }

    private bool IsValidToCreate(UserCredentials userCredentials)
    {
        return true;
    }

    private bool IsValidToUpdate(UserCredentials userCredentials)
    {
        return true;
    }
}