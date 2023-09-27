using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TestGorilla.Data.Data;
using TestGorilla.Domain.Models;
using TestGorilla.Domain.Models.Question;

namespace TestGroilla.Service;

public class CheckBoxQuestionService : ICheckBoxQuestionService
{
    private readonly IDataContext _appDataContext;
    private ICheckBoxQuestionService _checkBoxQuestionServiceImplementation;

    public CheckBoxQuestionService(IDataContext appDataContext)
    {
        _appDataContext = appDataContext;
    }


    public async Task<CheckBoxQuestion> Createasync(CheckBoxQuestion question)
    {
        var existingCheckboxQuestion = _appDataContext.CheckboxQuestions.FirstOrDefault(x =>
            x.Id == question.Id && DateTime.UtcNow - x.CratedTime > TimeSpan.FromMinutes(90));
        if (existingCheckboxQuestion != null)
        {
            throw new InvalidOperationException($"CheckboxQuestion {question.Id} already exists");
        }
        CheckBoxQuestion result = (await _appDataContext.CheckboxQuestions.AddAsync(question)).Entity;
        await _appDataContext.SaveChangesAsync();
        return result;
    }

    public async Task<CheckBoxQuestion> UpdateAsync(CheckBoxQuestion question)
    {
        var UpdatingCheckBoxQuestion = _appDataContext.CheckboxQuestions.FirstOrDefault(x => x.Id == question.Id);
        if (UpdatingCheckBoxQuestion == null)
        {
            throw new NotImplementedException("This Question does not exist");
        }
        var newCheckboxQuestion = new CheckBoxQuestion()
        {
            Title = question.Title,
            Description = question.Description,
            CratedTime = question.CratedTime,
            UpdateTime = question.UpdateTime,
            Answer = question.Answer
        };
        CheckBoxQuestion result = (await _appDataContext.CheckboxQuestions.AddAsync(newCheckboxQuestion)).Entity;
        await _appDataContext.SaveChangesAsync();
        return result;

    }

    public bool DeleteAsync(Guid questionId)
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

    public IQueryable<CheckBoxQuestion> Get(Expression<Func<CheckBoxQuestion, bool>> predicate)
    {
        return _appDataContext.CheckboxQuestions.Where(predicate.Compile()).AsQueryable();
    }

    public async Task<PaginationResult<CheckBoxQuestion>> GetByQuestionIdAsync(Guid id, int PageToken, int PageSize)
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

    public async Task<CheckBoxQuestion> GetByQuestionTitleAsync(string Title)
    {
        var searchingQuestionWithTitle = _appDataContext.CheckboxQuestions.FirstOrDefault(c => c.Title == Title);
        if (searchingQuestionWithTitle == null)
        {
            throw new NotImplementedException("This Title not using!!");
        }
        return searchingQuestionWithTitle;
    }
    public Task<IEnumerable<CheckBoxQuestion>> GetByQuestionCategoryAsync(string category)
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