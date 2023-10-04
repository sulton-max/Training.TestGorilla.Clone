using System.Linq.Expressions;
using TestGorilla.DataAccess.Context;
using TestGorilla.Domain.Entities;
using TestGorilla.Service.Helpers;
using TestGorilla.Service.Interface;

namespace TestGorilla.Service.Service;

public class CategoryService : ICategoryService
{
    private readonly IDataContext _appDataContext;
    private readonly ValidationService _validationService;

    public CategoryService(IDataContext appDataContext, ValidationService validationService)
    {
        _appDataContext = appDataContext;
        _validationService = validationService;
    }

    public IQueryable<Category> Get(Expression<Func<Category, bool>> expression) =>
                    _appDataContext.Categories.Where(expression.Compile()).AsQueryable();

    
    public ValueTask<ICollection<Category>> GetAsync(IEnumerable<Guid> ids)
    {
        var categories = _appDataContext.Categories.Where(category => ids.Contains(category.Id));
        return new ValueTask<ICollection<Category>>(categories.ToList());
    }

    public async ValueTask<Category> GetById(Guid id)
    {
        var result = await _appDataContext.Categories.FindAsync(id);

        return result;

    }
    
    public async ValueTask<Category> CreateAsync(Category category, bool saveChanges = true, CancellationToken cancellation = default)
    {
        if (category is null)
            throw new AggregateException("Category name is not valid!");

        await _appDataContext.Categories.AddAsync(category,cancellation);

        if (saveChanges)
            await _appDataContext.SaveChangesAsync();
        
        return category;
    }

    
    public async ValueTask<Category> UpdateAsync( Category category, bool saveChanges = true, CancellationToken cancellation = default)
    {

        var existingCategory = (await _appDataContext.Categories.FindAsync(category.Id, cancellation));
        
        if (existingCategory!.Equals(null))
            throw new ArgumentNullException($"{existingCategory}", "Category not found");

        existingCategory.CategoryName = category.CategoryName;
        existingCategory.UpdatedTime = DateTime.UtcNow;

        await _appDataContext.SaveChangesAsync();
        
        return category;
    }    
    public async ValueTask<Category> DeleteAsync(Guid id, bool saveChanges = true, CancellationToken cancellation = default)
    {
        var foundCategory = await GetById(id);
        if(foundCategory is null)
            throw new InvalidOperationException("Category not found!");
        
        foundCategory.IsDeleted = true;
        await _appDataContext.SaveChangesAsync();
        return foundCategory;
    }
}