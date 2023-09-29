using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TestGorilla.Data.Data;
using TestGorilla.Domain.Models;
using TestGorilla.Domain.Models.Question;
using TestGorilla.Service.Helpers;
using TestGorilla.Service.Services.Interfaces;

namespace TestGorilla.Service.Services;

public class CheckBoxQuestionService : ICheckBoxQuestionService
{
    private readonly IDataContext _appDataContext;
    private ICheckBoxQuestionService _checkBoxQuestionServiceImplementation;
 
    private readonly Validator _validator;

    public CheckBoxQuestionService(IDataContext appDataContext, Validator validator)
    {
        _appDataContext = appDataContext;
        _validator = validator;
    }
    public async Task<CheckBoxQuestion> CreateAsync(CheckBoxQuestion question, CancellationToken cancellationToken, bool saveChanges = true)
    {
        if (!_validator.IsValidDescription(question.Description) || !_validator.IsValidTitle(question.Title))
        {
            throw new ArgumentException("Question is not valid!!");
        }
        var existingCheckboxQuestion = _appDataContext.CheckboxQuestions.FirstOrDefault(x =>
            x.Id == question.Id && DateTime.UtcNow - x.Duration > TimeSpan.FromMinutes(90) && x.Answer.AnswerText == null);
        if (existingCheckboxQuestion != null)
        {
            throw new InvalidOperationException($"CheckboxQuestion {question.Id} already exists");
        }
        CheckBoxQuestion result = (await _appDataContext.CheckboxQuestions.AddAsync(question)).Entity;
        await _appDataContext.SaveChangesAsync();
        return result;
    }

    public async Task<CheckBoxQuestion> UpdateAsync(CheckBoxQuestion question, CancellationToken cancellationToken, bool saveChanges = true)
    {
        if(!_validator.IsValidTitle(question.Title) || !_validator.IsValidDescription(question.Description))
        {
            throw new ArgumentException("Updated Question is not valid!!");
        }
        var updatingCheckBoxQuestion = _appDataContext.CheckboxQuestions.FirstOrDefault(x => x.Id == question.Id);
        if (updatingCheckBoxQuestion == null)
        {
            throw new NotImplementedException("This Question does not exist");
        }
        var newCheckboxQuestion = new CheckBoxQuestion()
        {
            Title = question.Title,
            Description = question.Description,
            UpdatedTime = DateTime.UtcNow,
            Answer = question.Answer,
            Duration = question.Duration,
            Category = question.Category
        };
        CheckBoxQuestion result = (await _appDataContext.CheckboxQuestions.AddAsync(newCheckboxQuestion)).Entity;
        await _appDataContext.SaveChangesAsync();
        return result;

    }

    public bool DeleteAsync(Guid questionId, CancellationToken cancellationToken, bool saveChanges = true)
    {
        var DeleteCheckBoxQuestion = _appDataContext.CheckboxQuestions.FirstOrDefault(x => x.Id == questionId);
        if (DeleteCheckBoxQuestion != null)
        {
            _appDataContext.CheckboxQuestions.RemoveAsync(DeleteCheckBoxQuestion);
            _appDataContext.SaveChangesAsync();
            return true;
        }
        return false;
    }

    public IQueryable<CheckBoxQuestion> Get(Expression<Func<CheckBoxQuestion, bool>> predicate, CancellationToken cancellationToken, bool saveChanges = true)
    {
        return _appDataContext.CheckboxQuestions.Where(predicate.Compile()).AsQueryable();
    }

    public async Task<PaginationResult<CheckBoxQuestion>> GetByQuestionIdAsync(Guid id, int PageToken, int PageSize, CancellationToken cancellationToken, bool saveChanges = true)
    {
        var query = _appDataContext.CheckboxQuestions
            .Where(question => question.Id == id).AsQueryable();

        // Umumiy elementlar sonini hisoblash
        var totalItems = await query.CountAsync();

        // Sahifalash uchun ishlatilgan skip() va take() metodlarini qo'llash
        var questions = await query
            .Skip((PageToken - 1) * PageSize)
            .Take(PageSize)
            .ToListAsync();

        var paginationResult = new PaginationResult<CheckBoxQuestion>
        {
            Items = questions,
            TotalItems = totalItems,
            PageToken = PageToken,
            PageSize = PageSize
        };

        return paginationResult;
    }

    public async Task<CheckBoxQuestion> GetByQuestionTitleAsync(string Title, CancellationToken cancellationToken, bool saveChanges = true)
    {
        var searchingQuestionWithTitle = _appDataContext.CheckboxQuestions.FirstOrDefault(c => c.Title == Title);
        if (searchingQuestionWithTitle == null)
        {
            throw new NotImplementedException("This Title not using!!");
        }
        return searchingQuestionWithTitle;
    }
    public Task<IEnumerable<CheckBoxQuestion>> GetByQuestionCategoryAsync(string category ,CancellationToken cancellationToken, bool saveChanges = true)
    {
        var existingCategory =
            _appDataContext.Categories.FirstOrDefault(x => x.Name.Equals(category, StringComparison.OrdinalIgnoreCase));
        if (existingCategory == null)
        {
            throw new NotImplementedException("This Category not using!!");
        }

        var questionCategory =
            _appDataContext.CheckboxQuestions.Where(question => question.Category.Id == existingCategory.Id);
        return Task.FromResult(questionCategory);
    }


}