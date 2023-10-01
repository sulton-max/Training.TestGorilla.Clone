using System.Linq.Expressions;
using TestGorilla.DataAccess.Context;
using TestGorilla.Domain.Entities;
using TestGorilla.Domain.Entities.Questions;
using TestGorilla.Service.Helpers;
using TestGorilla.Service.Interface;

namespace TestGorilla.Service.Service;

public class ShortAnswerTypeQuestionService : IShortAnswerTypeQuestionService
{
    private readonly IDataContext _appDataContext;
    private readonly ValidationService _validationService;

    public ShortAnswerTypeQuestionService(IDataContext appDataContext, ValidationService validationService)
    {
        _appDataContext = appDataContext;
        _validationService = validationService;
    }
    public Task<ShortAnswerTypeQuestion> CreateAsync(ShortAnswerTypeQuestion question, CancellationToken cancellationToken, bool saveChanges = true)
    {
        throw new NotImplementedException();
    }

    public Task<ShortAnswerTypeQuestion> UpdateAsync(ShortAnswerTypeQuestion question, CancellationToken cancellationToken, bool saveChanges = true)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAsync(Guid questionId, CancellationToken cancellationToken, bool saveChanges = true)
    {
        throw new NotImplementedException();
    }

    public IQueryable<ShortAnswerTypeQuestion> Get(Expression<Func<ShortAnswerTypeQuestion, bool>> predicate, CancellationToken cancellationToken, bool saveChanges = true)
    {
        throw new NotImplementedException();
    }

    public Task<PaginationResult<ShortAnswerTypeQuestion>> GetAsync(ShortAnswerTypeQuestion question, int PageToken, int PageSize, CancellationToken cancellationToken,
        bool saveChanges = true)
    {
        throw new NotImplementedException();
    }

    public Task<ShortAnswerTypeQuestion> GetByIdAsync(Guid id, CancellationToken cancellationToken, bool saveChanges = true)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<ShortAnswerTypeQuestion>> GetByTitleAsync(string Title, CancellationToken cancellationToken, bool saveChanges = true)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<ShortAnswerTypeQuestion>> GetByCategoryAsync(Category category, CancellationToken cancellationToken, bool saveChanges = true)
    {
        throw new NotImplementedException();
    }
}