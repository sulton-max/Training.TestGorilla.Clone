using TestGorilla.Domain.Commons;

namespace TestGorilla.Domain.Models
{
    public class Category : Auditable, IEntity
    {
        public string Name { get; set; }
        
        public Category()
        {
            
        }
    }
}
