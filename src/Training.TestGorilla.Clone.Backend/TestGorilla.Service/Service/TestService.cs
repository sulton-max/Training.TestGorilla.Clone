using AutoMapper;
using System.Linq.Expressions;
using TestGorilla.DataAccess.Context;
using TestGorilla.Domain.Entities;
using TestGorilla.Service.DTOs.Tests;
using TestGorilla.Service.Helpers;
using TestGorilla.Service.Interface;

namespace TestGorilla.Service.Service;

public class TestService : ITestService
{
    private readonly IDataContext _appDataContext;
    private readonly ValidationService _validator;
    private readonly IMapper _mapper;

    public TestService(IDataContext dataContext, ValidationService validator, IMapper mapper)
    {
        _appDataContext = dataContext;
        _validator = validator;
        _mapper = mapper;
    }

    public async ValueTask<Test> CreateAsync(Test test, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        if (!_validator.IsValidTitle(test.Title))
            throw new ArgumentException("Invalid Title");

        var existTest = await _appDataContext.Tests.FindAsync(test.Id);

        if (existTest != null)
            throw new InvalidOperationException("Test already exists");

        await _appDataContext.Tests.AddAsync(test);

        if (saveChanges)
            await _appDataContext.Tests.SaveChangesAsync(cancellationToken);

        return test;
    }

    public async ValueTask<Test> DeleteAsync(Guid testId, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        var existTest = await _appDataContext.Tests.FindAsync(testId);

        if (existTest == null)
            throw new InvalidOperationException("Test does not exists");

        await _appDataContext.Tests.RemoveAsync(existTest);

        return existTest;
    }

    public IQueryable<Test> Get(Expression<Func<Test, bool>> predicate)
    {
        return _appDataContext.Tests.Where(predicate.Compile()).AsQueryable();
    }

    public async ValueTask<Test> GetByIdAsync(Guid id)
    {
        var existTest = await _appDataContext.Tests.FindAsync(id);

        if (existTest is null)
            throw new InvalidOperationException("Test does not exists");

        return existTest;
    }

    public async ValueTask<Test> UpdateAsync(Test test, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        var existTest = _appDataContext.Tests.FirstOrDefault(test);

        if (existTest == null)
            throw new InvalidOperationException("User does not exists");

        existTest.Title = test.Title;
        existTest.Description = test.Description;
        existTest.QuestionLevel = test.QuestionLevel;
        existTest.DurationInMinute = test.DurationInMinute;
        existTest.UpdatedTime = DateTime.UtcNow;

        if (saveChanges)
            await _appDataContext.Tests.SaveChangesAsync(cancellationToken);

        return existTest;
    }
}