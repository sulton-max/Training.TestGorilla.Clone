using System.ComponentModel.DataAnnotations;
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

    public async ValueTask<UserCredentials> CreateAsync(UserCredentials userCredentials, bool saveChanges = true, CancellationToken cancellation = default)
    {
        if (!IsValidToCreate(userCredentials))
        {
            throw new ValidationException("Invalid Credentials to create");
        }

        userCredentials.Password = _passwordHasher.Hash(userCredentials.Password);
        await _appDataContext.UserCredentials.AddAsync(userCredentials);

        if (saveChanges)
            await _appDataContext.UserCredentials.SaveChangesAsync();

        return userCredentials;
    }

    public async ValueTask<UserCredentials> DeleteAsync(UserCredentials userCredentials, bool saveChanges = true, CancellationToken cancellation = default)
    {
        var deleted = await GetById(userCredentials.Id);
        if (deleted is null)
        {
            throw new ValidationException("Credentials not exists");
        }

        deleted.IsDeleted = true;
        deleted.DeletedDate = DateTime.UtcNow;

        if (saveChanges)
            await _appDataContext.UserCredentials.SaveChangesAsync();

        return deleted;
    }

    public async ValueTask<UserCredentials> DeleteAsync(Guid id, bool saveChanges = true, CancellationToken cancellation = default)
    {
        var deleted = await GetById(id);
        if (deleted is null)
        {
            throw new ValidationException("Credentials is not found");
        }

        deleted.IsDeleted = true;
        deleted.DeletedDate = DateTime.UtcNow;

        if (saveChanges)
            await _appDataContext.UserCredentials.SaveChangesAsync();

        return deleted;
    }

    public IQueryable<UserCredentials> Get(Expression<Func<UserCredentials, bool>> expression)
    {
        return _appDataContext.UserCredentials.Where(expression.Compile()).AsQueryable();
    }

    public ValueTask<ICollection<UserCredentials>> Get(IEnumerable<Guid> ids)
    {
        return new ValueTask<ICollection<UserCredentials>>(_appDataContext.UserCredentials.Where(item => ids.Contains(item.Id) && !item.IsDeleted).ToList());
    }

    public async ValueTask<UserCredentials> GetById(Guid id)
    {
        var credentials = await _appDataContext.UserCredentials.FindAsync(id);
        if (credentials is null || credentials.IsDeleted)
        {
            throw new ArgumentNullException("Credential that this id, is not found");
        }

        return credentials;
    }

    public async ValueTask<UserCredentials> UpdateAsync(string oldPassword, UserCredentials userCredentials, bool saveChanges = true, CancellationToken cancellation = default)
    {
        IsValidToUpdate(userCredentials);

        var oldCredentials = await GetById(userCredentials.Id);
        if (!_passwordHasher.Verify(oldPassword, oldCredentials.Password))
        {
            throw new ArgumentOutOfRangeException("Incorrect oldpasword");
        }

        oldCredentials.Password = _passwordHasher.Hash(userCredentials.Password);
        oldCredentials.UpdatedTime = DateTime.UtcNow;

        if (saveChanges)
            await _appDataContext.UserCredentials.SaveChangesAsync();

        return oldCredentials;
    }

    private bool IsExistsUserCredentials(Guid id)
    {
        if (_appDataContext.UserCredentials.Any(userCredential => userCredential.Id == id))
            return true;
        return false;
    }

    private bool IsValidToCreate(UserCredentials userCredentials)
    {
        if (IsExistsUserCredentials(userCredentials.Id))
            throw new InvalidOperationException("User Credentials already exists");

        if (_appDataContext.UserCredentials.Any(userCreadential => userCreadential.UserId == userCredentials.UserId))
            throw new InvalidOperationException("The given user already has Creadentials");

        IsValidPassword(userCredentials.Password);

        return true;
    }

    private bool IsValidToUpdate(UserCredentials userCredentials)
    {
        if (!IsExistsUserCredentials(userCredentials.Id))
            throw new InvalidOperationException("User Credentials doesn't exists");

        IsValidPassword(userCredentials.Password);

        return true;
    }

    private void IsValidPassword(string password)
    {
        if (!_validatorService.IsValidPassword(password))
        {
            throw new InvalidOperationException("Password is not available");
        }
    }
}