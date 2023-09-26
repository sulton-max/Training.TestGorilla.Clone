using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestGorilla.Domain.Models
{
    public class Result : Auditable
    {
        public long UserId { get; set; }
        public long TestId { get; set; }
        public long ExamId { get; set; }
        public long CategoryId { get; set; }
        public decimal TestResult { get; set; }
        public decimal ExamResult { get; set;}
        public bool IsDelete { get; set; }
        public Result()
        {
            
        }
    }
}
