using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TestGorilla.Domain.Models.Question;
using TestGorilla.Domain.Models;
using TestGorilla.Domain.Models.Questions;

namespace TestGorilla.Service.Services.Interfaces
{
    public interface IMultipleChoiceQuestionService
    {
        public Task<MultipleChoiceQuestion> Createasync(MultipleChoiceQuestion question);
        public Task<MultipleChoiceQuestion> UpdateAsync(MultipleChoiceQuestion question);
        public bool DeleteAsync(Guid questionId);
        public IQueryable<MultipleChoiceQuestion> Get(Expression<Func<MultipleChoiceQuestion, bool>> predicate);
        public Task<PaginationResult<MultipleChoiceQuestion>> GetByQuestionIdAsync(Guid id, int PageToken, int PageSize);
        public Task<MultipleChoiceQuestion> GetByQuestionTitleAsync(string Title);
        public Task<IEnumerable<MultipleChoiceQuestion>> GetByQuestionCategoryAsync(string category);
    }
}
