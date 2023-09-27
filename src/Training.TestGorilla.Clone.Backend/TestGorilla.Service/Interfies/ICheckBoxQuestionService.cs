namespace TestGroilla.Service;

public interface ICheckBoxQuestionService
{
    public Task<CheckboxQuestion> Createasync(CheckboxQuestion question);
    public Task<CheckboxQuestion> UpdateAsync(CheckboxQuestion question);
    public bool DeleteAsync(Guid questionId);
    public IQueryable<CheckboxQuestion> Get(Expression<Func<CheckboxQuestion, bool>> predicate);
    public Task<PaginationResult<CheckboxQuestion>> GetByQuestionIdAsync(Guid id, int PageToken, int PageSize);
    public Task<CheckboxQuestion> GetByQuestionTitleAsync(string Title);
    public Task<IEnumerable<CheckboxQuestion>> GetByQuestionCategoryAsync(string category);
}
