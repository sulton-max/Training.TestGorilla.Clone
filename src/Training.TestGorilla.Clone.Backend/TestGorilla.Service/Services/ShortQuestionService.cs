using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TestGorilla.Data.Data;
using TestGorilla.Domain.Models;
using TestGorilla.Domain.Models.Questions;
using TestGorilla.Service.Helpers;
using TestGorilla.Service.Services.Interfaces;

namespace TestGorilla.Service.Services
{
    public class ShortQuestionService : IShortQuestionService
    {
        private readonly IDataContext _dataContext;
        private readonly Validator _validator;
        public ShortQuestionService(IDataContext dataContext, Validator validator)
        {
            _dataContext = dataContext;
            _validator = validator;
        }
        public async Task<ShortAnswerTypeQuestion> CreateAsync(ShortAnswerTypeQuestion question, CancellationToken cancellationToken, bool saveChanges = true)
        {
           if(IsValidCreatedShortQuestion(question) != true)
            {
                throw new InvalidOperationException("This Question is not valid");
            }
            if (saveChanges)
            {
                ShortAnswerTypeQuestion result = (await _dataContext.ShortQuestions.AddAsync(question)).Entity;
                await _dataContext.SaveChangesAsync();
                return result;
            }
            return null;
            
        }
        public async Task<bool> DeleteAsync(Guid questionId, CancellationToken cancellationToken, bool saveChanges = true)
        {
            var deletingShortQuestion = _dataContext.ShortQuestions.FirstOrDefault(question => question.Id == questionId);
            if (deletingShortQuestion != null)
            {
                ShortAnswerTypeQuestion result = (await _dataContext.ShortQuestions.RemoveAsync(deletingShortQuestion)).Entity;
                await _dataContext.SaveChangesAsync();
            }
            throw new NotImplementedException("This is question id is not existing!!");
        }

        public IQueryable<ShortAnswerTypeQuestion> Get(Expression<Func<ShortAnswerTypeQuestion, bool>> predicate, CancellationToken cancellationToken, bool saveChanges = true)
        {
            return _dataContext.ShortQuestions.Where(predicate.Compile()).AsQueryable();
        }

        public Task<IEnumerable<ShortAnswerTypeQuestion>> GetByQuestionCategoryAsync(string category, CancellationToken cancellationToken, bool saveChanges = true)
        {
            var existingShortQuestionCategory = _dataContext
        }

        public Task<PaginationResult<ShortAnswerTypeQuestion>> GetByQuestionIdAsync(Guid id, int PageToken, int PageSize, CancellationToken cancellationToken, bool saveChanges = true)
        {
            throw new NotImplementedException();
        }

        public Task<ShortAnswerTypeQuestion> GetByQuestionTitleAsync(string Title, CancellationToken cancellationToken, bool saveChanges = true)
        {
            throw new NotImplementedException();
        }

        public async Task<ShortAnswerTypeQuestion> UpdateAsync(ShortAnswerTypeQuestion question, CancellationToken cancellationToken, bool saveChanges = true)
        {
            if (isValidUpdatedShortQuestion(question) != true)
            {
                throw new InvalidOperationException("This Updated is not valid!!");
            }
            if (saveChanges)
            {
                var newShortQuestion = new ShortAnswerTypeQuestion()
                {
                    Title = question.Title,
                    Description = question.Description,
                    Category = question.Category,
                    Duration = question.Duration,
                };
                ShortAnswerTypeQuestion result = (await _dataContext.ShortQuestions.AddAsync(newShortQuestion)).Entity;
                await _dataContext.SaveChangesAsync();
                return result;
            }
            return null;
        }
        public bool IsValidCreatedShortQuestion(ShortAnswerTypeQuestion question)
        {
            if(_dataContext.ShortQuestions.Any(x => x.Title == question.Title)) 
            {
                return false;
            }
            if (question.Duration >= TimeSpan.FromMinutes(90))
            {
                return false;
            }
            if(!_validator.IsValidTitle(question.Title) || !_validator.IsValidDescription(question.Description))
            {
                return false;
            }
            throw new NullReferenceException("This is null");
        }
        public bool isValidUpdatedShortQuestion(ShortAnswerTypeQuestion question)
        {
            if (_dataContext.ShortQuestions.Any(question => question.Id != question.Id))
            {
                return false;
            }
            if(!_validator.IsValidTitle(question.Title) || !_validator.IsValidDescription(question.Description))
            {
                return false;
            }
            return true;
        }
      
    }
}
