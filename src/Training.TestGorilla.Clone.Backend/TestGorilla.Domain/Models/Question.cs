﻿using TestGorilla.Domain.Enums;

namespace TestGorilla.Domain.Models
{
    public class Question
    {
        public long Id { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
        public QuestionLevel Level { get; set; }
        public List<Test> tests = new List<Test>(); 
    }
}
