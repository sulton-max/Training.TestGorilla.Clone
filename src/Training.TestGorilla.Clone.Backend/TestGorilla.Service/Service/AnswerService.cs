using TestGorilla.Domain.Entities.Answers;
using TestGorilla.Service.Interface;
using TestGorilla.Service.Helpers;
using TestGorilla.DataAccess.Context;
using System.Data;
using System.Linq.Expressions;
using TestGorilla.Domain.Entities;

namespace TestGorilla.Service.Service;
public class AnswerService : IAnswerService
{
    private readonly IDataContext _appDataContext;
    private readonly ValidationService _validatorService;

    public AnswerService(IDataContext appDataContext, ValidationService validatorService)
    {
        _appDataContext = appDataContext;
        _validatorService = validatorService;
    }

    public IQueryable<Answer> Get(Expression<Func<Answer, bool>> predicate, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        return _appDataContext.Answers.Where(predicate.Compile()).AsQueryable();
    }

    public async Task<PaginationResult<Answer>> GetAsync(Expression<Func<Answer, bool>> predicate, int pageToken, int pageSize, CancellationToken cancellationToken, bool saveChanges = true)
    {
        if (pageToken < 1)
        {
            throw new ArgumentException("PageToken must be greater than or equal to 1");
        }

        if (pageSize < 1)
        {
            throw new ArgumentException("PageSize must be greater than or equal to 1");
        }

        var query = _appDataContext.Answers.Where(predicate.Compile()).AsQueryable();
        var length = query.Count();
        var question = query
            .Skip((pageToken - 1) * pageSize)
            .Take(pageSize)
            .ToList();

        var paginationResult = new PaginationResult<Answer>
        {
            Items = question,
            TotalItems = length,
            PageToken = pageToken,
            PageSize = pageSize,
        };
        return paginationResult;
    }

    public ValueTask<Answer> GetByIdAsync(Guid answerId)
    {
        var searchingAnswer = _appDataContext.Answers.FirstOrDefault(a => a.Id == answerId);

        if (searchingAnswer == null)
            throw new InvalidOperationException("Answer does not exist.");

        return new ValueTask<Answer>(searchingAnswer);
    }

    public ValueTask<ICollection<Answer>> GetByQuestionIdAsync(Guid questionId)
    {
        ICollection<Answer> questionsAnswers = _appDataContext.Answers.Where(a => a.QuestionId == questionId).ToList();

        return new ValueTask<ICollection<Answer>>(questionsAnswers);
    }

    public ValueTask<Answer> CreateAsync(Answer answer, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        if (_validatorService.IsValidTitle(answer.AnswerText) == false)
            throw new Exception();

        var isUniqueText = _appDataContext.Answers
            .FirstOrDefault(a => a.AnswerText == answer.AnswerText && a.Id == answer.Id && a.QuestionId == answer.QuestionId);
        
        if (isUniqueText != null)
            throw new DuplicateNameException("Data of this object is a duplicate of existing data in this question's answers.");

        _appDataContext.Answers.AddAsync(answer);

        if (saveChanges)
            _appDataContext.Answers.SaveChangesAsync();

        return new ValueTask<Answer>(answer);
    }
    public ValueTask<Answer> UpdateAsync(Answer answer, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        var searchingAnswer = _appDataContext.Answers.FirstOrDefault(a => a.Id == answer.Id);

        if (searchingAnswer == null)
            throw new InvalidOperationException("Answer is not exist.");

        searchingAnswer.AnswerText = answer.AnswerText;
        searchingAnswer.UpdatedTime = DateTime.UtcNow;
        searchingAnswer.IsCorrect = answer.IsCorrect;

        if (saveChanges)
            _appDataContext.Answers.SaveChangesAsync();

        return new ValueTask<Answer>(answer);
    }

    public ValueTask<Answer> DeleteAsync(Guid answerId, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        var searchingAnswer = _appDataContext.Answers.FirstOrDefault(a => a.Id == answerId);
        
        if (searchingAnswer == null)
            throw new InvalidOperationException("Answer is not exists in this question.");

        searchingAnswer.IsDeleted = true;
        searchingAnswer.DeletedDate = DateTime.UtcNow;

        if (saveChanges)
            _appDataContext.Answers.SaveChangesAsync();

        return new ValueTask<Answer>(searchingAnswer);
    }
}
