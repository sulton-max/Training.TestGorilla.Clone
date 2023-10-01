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
    public async Task<ShortAnswerTypeQuestion> CreateAsync(ShortAnswerTypeQuestion question, CancellationToken cancellationToken, bool saveChanges = true)
    {
        if (!isValidCreate(question))
        {
            throw new InvalidOperationException("This is not a valid question");
        }

        _appDataContext.ShortAnswerTypeQuestions.AddAsync(question);
        if (saveChanges)
        {
            await _appDataContext.ShortAnswerTypeQuestions.SaveChangesAsync(cancellationToken);
        }
        return question;
    }

    public async Task<ShortAnswerTypeQuestion> UpdateAsync(ShortAnswerTypeQuestion question, CancellationToken cancellationToken, bool saveChanges = true)
    {
        if (!isValidUpdate(question))
        {
            throw new ArgumentException("This question not found");
        }

        var existingQuestion = await _appDataContext.ShortAnswerTypeQuestions.FindAsync(question.Id);
        if (existingQuestion == null)
        {
            throw new ArgumentException("This question is not found");
        }
        existingQuestion.Title = question.Title;
        existingQuestion.Description = question.Description;
        existingQuestion.Duration = question.Duration;
        existingQuestion.Category = question.Category;
        existingQuestion.UpdatedTime = DateTime.UtcNow;
        if (saveChanges)
        {
            await _appDataContext.ShortAnswerTypeQuestions.SaveChangesAsync(cancellationToken);
        }

        return existingQuestion;
    }

    public async Task<bool> DeleteAsync(Guid questionId, CancellationToken cancellationToken, bool saveChanges = true)
    {
        var deletingQuestion = await _appDataContext.ShortAnswerTypeQuestions.FindAsync(questionId);
        if (deletingQuestion == null)
        {
            return false;
        }

        await _appDataContext.ShortAnswerTypeQuestions.RemoveAsync(deletingQuestion);
        if (saveChanges)
        {
            await _appDataContext.ShortAnswerTypeQuestions.SaveChangesAsync(cancellationToken);
        }
        return true;
    }

    public IQueryable<ShortAnswerTypeQuestion> Get(Expression<Func<ShortAnswerTypeQuestion, bool>> predicate, CancellationToken cancellationToken, bool saveChanges = true)
    {
        return _appDataContext.ShortAnswerTypeQuestions.Where(predicate.Compile()).AsQueryable();

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
    public bool isValidCreate(ShortAnswerTypeQuestion question)
    {
        if (_appDataContext.ShortAnswerTypeQuestions.Any(x => x.Answer.AnswerText == null))
        {
            return false;
        }

        if (_appDataContext.ShortAnswerTypeQuestions.Any(x => x.Title == question.Title))
        {
            return false;
        }

        if (!_validationService.IsValidTitle(question.Title))
        {
            return false;
        }

        if (!_validationService.IsValidDescription(question.Description))
        {
            return false;
        }

        if (question.Duration >= TimeSpan.FromMinutes(90))
        {
            return false;
        }
        return true;
    }

    public bool isValidUpdate(ShortAnswerTypeQuestion question)
    {
        if (_appDataContext.ShortAnswerTypeQuestions.Any(x => x.Id != question.Id))
        {
            return false;
        }

        if (!_validationService.IsValidTitle(question.Title))
        {
            return false;
        }

        if (!_validationService.IsValidDescription(question.Description))
        {
            return false;
        }

        if (question.Duration >= TimeSpan.FromMinutes(90))
        {
            return false;
        }

        return true;
    }
}