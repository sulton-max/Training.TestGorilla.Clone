<<<<<<< HEAD
namespace TestGorilla.Domain.Commons;

public abstract class Auditable
{
    
=======
﻿namespace TestGorilla.Domain.Commons;

public abstract class Auditable : IAuditable
{
    public Guid Id { get; set; }
    public DateTime CreatedTime { get; set; }
    public DateTime? UpdatedTime { get; set; }
>>>>>>> bfa2f0906d5c70b03208bc389a3a53826ace22df
}