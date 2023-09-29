﻿using TestGorilla.Domain.Commons;
using TestGorilla.Domain.Models.Questions.InterfeysQuestion;
namespace TestGorilla.Domain.Models.Questions;
public class MultipleChoiceQuestion : Auditable, IQuestion, IEntity
{
    public string Title { get; set; }
    public string Description { get ; set; }
    public Category Category  {get; set; }
    public Answer Answer { get; set; }
    public DateTime Duration { get; set; }
    
}
