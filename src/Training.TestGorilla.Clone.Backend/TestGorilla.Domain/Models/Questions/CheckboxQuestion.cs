using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestGorilla.Domain.Models.Questions.InterfeysQuestion;

namespace TestGorilla.Domain.Models.Questions
{
    public class CheckboxQuestion : Auditable, IQuestion
    {
        public string Title { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Description { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public Answer Answer { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DateTime Time { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
