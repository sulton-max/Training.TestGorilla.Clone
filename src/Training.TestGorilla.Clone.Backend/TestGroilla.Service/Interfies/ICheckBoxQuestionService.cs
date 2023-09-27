using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TestGorilla.Domain.Models;
using TestGorilla.Domain.Models.Questions;

namespace TestGroilla.Service
{
    public interface ICheckBoxQuestionService
    {
        public Task<CheckboxQuestion> Createasync(CheckboxQuestion question);
        public Task<CheckboxQuestion> UpdateAsync(CheckboxQuestion question);
        public bool DeleteAsync(Guid questionId);
        public IQueryable<CheckboxQuestion> Get(Expression<Func<CheckboxQuestion, bool>> predicate);
        public Task<PaginationResult<CheckboxQuestion>> GetByQuestionIdAsync(Guid id, int PageToken, int PageSize);
        public Task<CheckboxQuestion> GetByQuestionTitleAsync (string Title);
        public Task<IEnumerable<CheckboxQuestion>> GetByQuestionCategoryAsync(string category);
    }
}
