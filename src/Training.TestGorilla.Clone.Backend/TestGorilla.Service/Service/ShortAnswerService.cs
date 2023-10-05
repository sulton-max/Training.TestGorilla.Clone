using System.Linq.Expressions;
using TestGorilla.DataAccess.Context;
using TestGorilla.Domain.Entities.Answers;
using TestGorilla.Service.Helpers;
using TestGorilla.Service.Interface;

namespace TestGorilla.Service.Service;
public class ShortAnswerService : IShortAnswerService
{
    private readonly IDataContext _appDataContext;
    private ValidationService _validationService;

    public ShortAnswerService(IDataContext appDataContext, ValidationService validationService)
    {
        _appDataContext = appDataContext;
        _validationService = validationService;
    }

    public IQueryable<ShortAnswer> Get(Expression<Func<ShortAnswer, bool>> predicate)
    {
        return _appDataContext.ShortAnswers.Where(predicate.Compile()).AsQueryable();
    }

    public ValueTask<ShortAnswer> GetByIdAsync(Guid answerId)
    {
        var searchingAnswer = _appDataContext.ShortAnswers.FirstOrDefault(a => a.Id == answerId);

        if (searchingAnswer == null)
            throw new InvalidOperationException("Answer does not exist.");

        return new ValueTask<ShortAnswer>(searchingAnswer);
    }

    public ValueTask<ShortAnswer> CreateAsync(ShortAnswer answer, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        if (_validationService.IsValidTitle(answer.AnswerText) == false)
            throw new Exception();

        var isUniqueAnswer = _appDataContext.ShortAnswers.Where(a => a.QuestionId == answer.QuestionId).Select(a => a).Count() > 0;
        if (isUniqueAnswer)
            throw new InvalidOperationException("Answer's count must one and empty.");

        if (answer.AnswerText != default)
            throw new InvalidOperationException("Answer must be empty.");

        _appDataContext.ShortAnswers.AddAsync(answer);

        if (saveChanges)
            _appDataContext.ShortAnswers.SaveChangesAsync();
            
        return new ValueTask<ShortAnswer>(answer);
    }

    public ValueTask<ShortAnswer> UpdateAsync(ShortAnswer answer, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        var searchingAnswer = _appDataContext.ShortAnswers.FirstOrDefault(a => a.Id == answer.Id);

        if (searchingAnswer == null)
            throw new InvalidOperationException("Answer does not exist.");

        if (answer.IsChecked != true && answer.IsCorrect != false)
            throw new InvalidOperationException("Answer modification not allowed if unchecked.");

        searchingAnswer.AnswerText = answer.AnswerText;
        searchingAnswer.IsCorrect = answer.IsCorrect;
        searchingAnswer.IsChecked = answer.IsChecked;
        searchingAnswer.UpdatedTime = DateTime.UtcNow;

        if (saveChanges)
            _appDataContext.ShortAnswers.SaveChangesAsync();

        return new ValueTask<ShortAnswer>(answer);
    }

    public ValueTask<ShortAnswer> DeleteAsync(Guid answerId, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        var searchingAnswer = _appDataContext.ShortAnswers.FirstOrDefault(a => a.Id == answerId);

        if (searchingAnswer == null)
            throw new InvalidOperationException("Answer is not exists in this question.");

        searchingAnswer.IsDeleted = true;
        searchingAnswer.DeletedDate = DateTime.UtcNow;

        if (saveChanges)
            _appDataContext.ShortAnswers.SaveChangesAsync();

        return new ValueTask<ShortAnswer>(searchingAnswer);
    }
}
