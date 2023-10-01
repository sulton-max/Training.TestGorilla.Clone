using TestGorilla.Domain.Commons;

namespace TestGorilla.Domain.Entities;
/// <summary>
/// Category use in test, questions ans answers
/// </summary>
public abstract class Category : Auditable, IEntity
{
    public string? CategoryName { get; set; }

    public Category()
    {
    }

    protected Category(string? categoryName)
    {
        CategoryName = categoryName;
    }
}