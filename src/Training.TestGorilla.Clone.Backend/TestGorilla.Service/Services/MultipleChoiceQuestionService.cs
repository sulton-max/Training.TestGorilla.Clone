using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using TestGorilla.Data.Data;
using TestGorilla.Domain.Models;
using TestGorilla.Domain.Models.Questions;
using TestGorilla.Service.Helpers;
using TestGorilla.Service.Services.Interfaces;

namespace TestGorilla.Service.Services
{
    public class MultipleChoiceQuestionService : IMultipleChoiceQuestionService
    {
        private readonly IDataContext _appDataContext;
        private readonly Validator _validator;
        public MultipleChoiceQuestionService(IDataContext appDataContext, Validator validator)
        {
            _appDataContext = appDataContext;
            _validator = validator;
        }
        public async Task<MultipleChoiceQuestion> Createasync(MultipleChoiceQuestion question, bool saveChanges = true)
        {
            if(!_validator.IsValidTitle(question.Title) || !_validator.IsValidDescription(question.Description))
            {
                throw new InvalidOperationException("This Question is not Valid!!");
            }
            var creatingMultipleChoceQuestion = _appDataContext.MultipleQuestions.FirstOrDefault(x =>
                x.Id == question.Id && DateTime.UtcNow - x.CreatedTime > TimeSpan.FromMinutes(90) && x.Answer.AnswerText == null);
            if (creatingMultipleChoceQuestion != null)
            {
                throw new InvalidOperationException($"CheckboxQuestion {question.Id} already exists");
            }
            MultipleChoiceQuestion result = (await _appDataContext.MultipleQuestions.AddAsync(question)).Entity;
            await _appDataContext.SaveChangesAsync();
            return result;
        }

        public async Task<MultipleChoiceQuestion> UpdateAsync(MultipleChoiceQuestion question, bool saveChanges = true)
        {
            if (!_validator.IsValidTitle(question.Title) || !_validator.IsValidDescription(question.Description))
            {
                throw new Exception("Updated Question is not valid!!");
            }
            var updatingMultipleChoceQuestion =
                _appDataContext.MultipleQuestions.FirstOrDefault(x => x.Id == question.Id);
            {
                if (updatingMultipleChoceQuestion == null)
                {
                    throw new NotImplementedException($"This question is not existing!!");
                }
                var newMultipleChoiceQuestion = new MultipleChoiceQuestion()
                {
                    Title = question.Title,
                    Description = question.Description,
                    Category = question.Category,
                    Answer = question.Answer,
                    Duration = question.Duration
                };
                MultipleChoiceQuestion result = (await _appDataContext.MultipleQuestions.AddAsync(newMultipleChoiceQuestion)).Entity;
                await _appDataContext.SaveChangesAsync();
                return result;
            }
        }

        public bool DeleteAsync(Guid questionId,CancellationToken cancellationToken = default, bool saveChanges = true)
        {
            var deletedMultipleChoiceQuestion =
                _appDataContext.MultipleQuestions.FirstOrDefault(x => x.Id == questionId);
            if (deletedMultipleChoiceQuestion != null)
            {
                _appDataContext.MultipleQuestions.RemoveAsync(deletedMultipleChoiceQuestion);
                _appDataContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public IQueryable<MultipleChoiceQuestion> Get(Expression<Func<MultipleChoiceQuestion, bool>> predicate, CancellationToken cancellationToken = default, bool saveChanges = true)
        {
            return _appDataContext.MultipleQuestions.Where(predicate.Compile()).AsQueryable();
        }

        public async Task<PaginationResult<MultipleChoiceQuestion>> GetByQuestionIdAsync(Guid id, int PageToken, int PageSize, CancellationToken cancellationToken = default, bool saveChanges = true)
        {
            var query = _appDataContext.MultipleQuestions
                .Where(question => question.Id == id).AsQueryable();

            // Umumiy elementlar sonini hisoblash
            var totalItems = await query.CountAsync();

            // Sahifalash uchun ishlatilgan skip() va take() metodlarini qo'llash
            var questions = await query
                .Skip((PageToken - 1) * PageSize)
                .Take(PageSize)
                .ToListAsync();

            var paginationResult = new PaginationResult<MultipleChoiceQuestion>
            {
                Items = questions,
                TotalItems = totalItems,
                PageToken = PageToken,
                PageSize = PageSize
            };

            return paginationResult;
        }

        public async Task<MultipleChoiceQuestion> GetByQuestionTitleAsync(string Title, CancellationToken cancellationToken = default, bool saveChanges = true)
        {
            var searchingQuestionWithTitle = _appDataContext.MultipleQuestions.FirstOrDefault(c => c.Title == Title);
            if (searchingQuestionWithTitle == null)
            {
                throw new NotImplementedException("This Title not using!!");
            }
            return searchingQuestionWithTitle;
        }
        public Task<IEnumerable<MultipleChoiceQuestion>> GetByQuestionCategoryAsync(string category, CancellationToken cancellationToken = default, bool saveChanges = true)
        {
            
            var existingCategory =
                _appDataContext.Categories.FirstOrDefault(x => x.Name.Equals(category, StringComparison.OrdinalIgnoreCase));
            if (existingCategory == null)
            {
                throw new NotImplementedException("This Category not using!!");
            }

            var questionCategory =
                _appDataContext.MultipleQuestions.Where(question => question.Category.Id == existingCategory.Id);
            return Task.FromResult(questionCategory);
        }
    }
}
