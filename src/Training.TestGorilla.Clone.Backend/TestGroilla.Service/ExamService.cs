using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestGorilla.Data.Data;
using TestGorilla.Domain.Models;

namespace TestGroilla.Service
{
    public class ExamService : IExamService
    {
        private readonly IDataContext _appdataContext;

        public ExamService(IDataContext appDatacontext)
        {
            _appdataContext = appDatacontext;
        }

        public Task<Exam> CreateAsync(string title, string description, TimeSpan duration, Guid creatorId, Guid examinatorId)
        {
            //Validation Servicelardan keyin qo`shiladi
            var checkExam = _appdataContext.    
            
        }

        public Task<Exam> DeleteByIdAsync(Guid examId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Exam>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Exam> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Exam> UpdateByIdAsync(Guid examId)
        {
            throw new NotImplementedException();
        }
    }
}
