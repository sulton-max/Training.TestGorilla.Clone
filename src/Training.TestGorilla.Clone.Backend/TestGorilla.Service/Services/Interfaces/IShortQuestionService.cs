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
    public interface IShortQuestionService
    {
        public Task<ShortAnswerTypeQuestion> CreateAsync(ShortAnswerTypeQuestion question, CancellationToken cancellationToken, bool saveChanges = true);
        public Task<ShortAnswerTypeQuestion> UpdateAsync(ShortAnswerTypeQuestion question, CancellationToken cancellationToken, bool saveChanges = true);
        public Task<bool> DeleteAsync(Guid questionId, CancellationToken cancellationToken, bool saveChanges = true);
        public IQueryable<ShortAnswerTypeQuestion> Get(Expression<Func<ShortAnswerTypeQuestion, bool>> predicate, CancellationToken cancellationToken, bool saveChanges = true);
        public Task<PaginationResult<ShortAnswerTypeQuestion>> GetByQuestionIdAsync(Guid id, int PageToken, int PageSize, CancellationToken cancellationToken, bool saveChanges = true);
        public Task<ShortAnswerTypeQuestion> GetByQuestionTitleAsync(string Title, CancellationToken cancellationToken, bool saveChanges = true);
        public Task<IEnumerable<ShortAnswerTypeQuestion>> GetByQuestionCategoryAsync(string category, CancellationToken cancellationToken, bool saveChanges = true);
    }
}
