using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using TestGorilla.DataAccess.Context;
using TestGorilla.Domain.Entities;
using TestGorilla.Domain.Entities.Questions;
using TestGorilla.Service.Helpers;
using TestGorilla.Service.Interface;

namespace TestGorilla.Service.Service;

public class MultipleChoiceQuestionService : IMultipleChoiceQuestionService
{
    private readonly IDataContext _appDataContext;
    private readonly ValidationService _validator;
    public MultipleChoiceQuestionService(IDataContext appDataContext, ValidationService validationService)
    {
        _validator = validationService;
        _appDataContext = appDataContext;
    }
    public async Task<MultipleChoiceQuestion> CreateAsync(MultipleChoiceQuestion question, CancellationToken cancellationToken, bool saveChanges = true)
    {
        if (!isValidCreated(question))
        {
            throw new InvalidOperationException("This question has already been created!!");
        }

        _appDataContext.MultipleChoiceQuestions.AddAsync(question);
        if (saveChanges)
        {
            await _appDataContext.MultipleChoiceQuestions.SaveChangesAsync(cancellationToken);
        }

        return question;
    }

    public async Task<MultipleChoiceQuestion> UpdateAsync(MultipleChoiceQuestion question, CancellationToken cancellationToken, bool saveChanges = true)
    {
        if (!isValidUpdate(question))
        {
            throw new InvalidOperationException("This id is not existing");
        }

        var existingQuestion = await _appDataContext.MultipleChoiceQuestions.FindAsync(question.Id);
        if (existingQuestion == null)
        {
            throw new ArgumentException("This Id is not found!!");
        }

        existingQuestion.Title = question.Title;
        existingQuestion.Description = question.Description;
        existingQuestion.UpdatedTime = DateTime.UtcNow;
        existingQuestion.Answers = question.Answers;
        existingQuestion.Duration = question.Duration;
        existingQuestion.Category = question.Category;
        if (saveChanges)
        {
            await _appDataContext.MultipleChoiceQuestions.SaveChangesAsync(cancellationToken);
        }

        return existingQuestion;
    }
    public async Task<bool> DeleteAsync(Guid questionId, CancellationToken cancellationToken, bool saveChanges = true)
    {
        var deletingQuestion = await _appDataContext.MultipleChoiceQuestions.FindAsync(questionId);
        if (deletingQuestion == null)
        {
            return false;
        }

        await _appDataContext.MultipleChoiceQuestions.RemoveAsync(deletingQuestion);

        if (saveChanges)
        {
            await _appDataContext.MultipleChoiceQuestions.SaveChangesAsync(cancellationToken);
        }
        return true;
    }
    
    public IQueryable<MultipleChoiceQuestion> Get(Expression<Func<MultipleChoiceQuestion,bool>> predicate, CancellationToken cancellationToken, bool saveChanges = true)
    {
        return _appDataContext.MultipleChoiceQuestions.Where(predicate.Compile()).AsQueryable();
    }

    public async Task<PaginationResult<MultipleChoiceQuestion>> GetAsync(MultipleChoiceQuestion question, int PageToken, int PageSize, CancellationToken cancellationToken = default,
        bool saveChanges = true)
    {
        if (PageToken < 1)
        {
            throw new ArgumentException("PageToken must be greater than or equal to 1");
        }

        if (PageSize < 1)
        {
            throw new ArgumentException("PageSize must be greater than or equal to 1");
        }
        
        var query = _appDataContext.MultipleChoiceQuestions.AsQueryable();
        
        if (!string.IsNullOrEmpty(question.Title))
        {
            query = query.Where(q => q.Title.Contains(question.Title));
        }
       
        query = query.Skip((PageToken - 1) * PageSize).Take(PageSize);

        var questions = await query.ToListAsync(cancellationToken);

        
        var totalItem = await query.CountAsync(cancellationToken);

        var paginationResult = new PaginationResult<MultipleChoiceQuestion>
        {
            Items = questions,
            TotalItems = totalItem,
            PageToken = PageToken,
            PageSize = PageSize
        };

        return paginationResult;

    }

    public async Task<MultipleChoiceQuestion> GetByIdAsync(Guid id)
    {
        var existingQuestion = _appDataContext.MultipleChoiceQuestions.FindAsync(id);
        if (existingQuestion != null)
        {
            return await existingQuestion;
        }
        throw new NullReferenceException("This is question is not found");
    }

    public async Task<IEnumerable<MultipleChoiceQuestion>> GetByTitleAsync(string Title, CancellationToken cancellationToken, bool saveChanges = true)
    {
        var existingQuestion = _appDataContext.MultipleChoiceQuestions.Where(x => x.Title.Equals(Title)).AsQueryable();
        if (existingQuestion != null)
        {
            var questionList = await existingQuestion.ToListAsync();
            return questionList;
        }

        throw new NullReferenceException("This is question is not found!!");
    }

    public async Task<IEnumerable<MultipleChoiceQuestion>> GetByCategoryAsync(Category category, CancellationToken cancellationToken, bool saveChanges = true)
    {
        var existingQuestion = _appDataContext.MultipleChoiceQuestions.Where(x => x.Category == category).AsQueryable();
        if (existingQuestion != null)
        {
            var questionList = await existingQuestion.ToListAsync();
            return questionList;
        }

        throw new ArgumentException("This Category is not found");
    }

    public bool isValidCreated(MultipleChoiceQuestion question)
    {
        if (_appDataContext.MultipleChoiceQuestions.Any(x => x.Title == question.Title))
        {
            return false;
        }

        if (question.Title == null || string.IsNullOrWhiteSpace(question.Title))
        {
            return false;
        }

        if (question.Description == null || string.IsNullOrWhiteSpace(question.Description))
        {
            return false;
        }

        if (question.Duration >= TimeSpan.FromMinutes(90))
        {
            return false;
        }
        return true;
    }

    public bool isValidUpdate(MultipleChoiceQuestion question)
    {
        if (_appDataContext.MultipleChoiceQuestions.Any(x => x.Id != question.Id))
        {
            return false;
        }

        if (!_validator.IsValidTitle(question.Title))
        {
            return false;
        }

        if (!_validator.IsValidDescription(question.Description))
        {
            return false;
        }

        if (_appDataContext.MultipleChoiceQuestions.Any(x => x.IsDeleted == false))
        {
            return false;
        }

        return true;
    }
}