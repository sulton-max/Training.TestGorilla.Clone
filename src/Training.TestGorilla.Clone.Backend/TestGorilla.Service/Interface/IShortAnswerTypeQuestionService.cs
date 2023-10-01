using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TestGorilla.Domain.Entities;
using TestGorilla.Domain.Entities.Questions;

namespace TestGorilla.Service.Interface
{
    public interface IShortAnswerTypeQuestionService
    {
        public Task<ShortAnswerTypeQuestion> CreateAsync(ShortAnswerTypeQuestion question, CancellationToken cancellationToken, bool saveChanges = true);
    
        public Task<ShortAnswerTypeQuestion> UpdateAsync(ShortAnswerTypeQuestion question, CancellationToken cancellationToken, bool saveChanges = true);
    
        public Task<bool> DeleteAsync(Guid questionId, CancellationToken cancellationToken, bool saveChanges = true);
    
        public IQueryable<ShortAnswerTypeQuestion> Get(Expression<Func<ShortAnswerTypeQuestion, bool>> predicate, CancellationToken cancellationToken, bool saveChanges = true);

        public Task<PaginationResult<ShortAnswerTypeQuestion>> GetAsync(ShortAnswerTypeQuestion question, int PageToken, int PageSize,
            CancellationToken cancellationToken, bool saveChanges = true);
    
        public Task<ShortAnswerTypeQuestion> GetByIdAsync(Guid id, CancellationToken cancellationToken, bool saveChanges = true);
    
        public Task<IEnumerable<ShortAnswerTypeQuestion>> GetByTitleAsync(string Title, CancellationToken cancellationToken, bool saveChanges = true);
    
        public Task<IEnumerable<ShortAnswerTypeQuestion>> GetByCategoryAsync(Category category, CancellationToken cancellationToken, bool saveChanges = true);
    }
}
