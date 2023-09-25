﻿

using TestGorilla.Domain.Models.Questions.InterfeysQuestion;
namespace TestGorilla.Domain.Models.Questions;
    public class CheckboxQuestion : Auditable, IQuestion
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public Answer Answer { get; set; }
        public DateTime Time { get; set; }
    }

