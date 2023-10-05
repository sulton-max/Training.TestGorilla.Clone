using AutoMapper;
using System.Linq.Expressions;
using TestGorilla.DataAccess.Context;
using TestGorilla.Domain.Entities;
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

    public async Task<PaginationResult<Test>> Get(Expression<Func<Test, bool>> predicate, int PageToken, int PageSize)
    {
        var query = _appDataContext.Tests.Where(predicate.Compile()).AsQueryable();
        var length = query.Count();

        var tests = query
       .Skip((PageToken - 1) * PageSize)
       .Take(PageSize)
       .ToList();

        var paginationResult = new PaginationResult<Test>
        {
            Items = tests,
            TotalItems = length,
            PageToken = PageToken,
            PageSize = PageSize
        };
        return paginationResult;
    }

    public async ValueTask<Test> GetByIdAsync(Guid id)
    {
        var existTest = _appDataContext.Tests.FirstOrDefault(x => x.Id == id);

        if (existTest is null || existTest.IsDeleted)
            throw new InvalidOperationException("Test does not exists");

        return existTest;
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
            await _appDataContext.SaveChangesAsync();

        return test;
    }

    public async ValueTask<Test> UpdateAsync(Test test, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        var existTest = _appDataContext.Tests.FirstOrDefault(result => result.Id == test.Id);

        if (existTest == null || existTest.IsDeleted)
            throw new InvalidOperationException("User does not exists");

        existTest.Id = test.Id;
        existTest.Title = test.Title;
        existTest.Description = test.Description;
        existTest.QuestionLevel = test.QuestionLevel;
        existTest.Duration = test.Duration;
        existTest.IsDeleted = test.IsDeleted;
        existTest.UpdatedTime = DateTime.UtcNow;

        if (saveChanges)
            await _appDataContext.Tests.SaveChangesAsync(cancellationToken);

        return existTest;
    }

    public async ValueTask<Test> DeleteAsync(Guid testId, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        var existTest = await _appDataContext.Tests.FindAsync(testId);

        if (existTest == null)
            throw new InvalidOperationException("Test does not exists");

        await _appDataContext.Tests.RemoveAsync(existTest);

        if (saveChanges)
            await _appDataContext.SaveChangesAsync();

        return existTest;
    }
}