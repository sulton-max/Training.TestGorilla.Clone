using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TestGorilla.Data.Data;
using TestGorilla.Domain.Models;
using TestGorilla.Domain.Models.Question;
using TestGroilla.Service;

namespace TestGorilla.Service
{
    public class ExamService : IExamService
    {
        private readonly IDataContext _appDataContext;
        private IExamService _examServiceImplementation;

        public ExamService(IDataContext dataContext)
        {
            _appDataContext = dataContext;
        }

        public async Task<Exam> Createasync(Exam exam)
        {
            var checkExam = _appDataContext.Exams.FirstOrDefault(x => x.Id.Equals(exam.Id));

            if (checkExam != null)
                throw new InvalidOperationException($"{exam.Id} already exists");

            var newExam = (await _appDataContext.Exams.AddAsync(exam)).Entity;
            await _appDataContext.SaveChangesAsync();
            
            return newExam;
        }

        public bool DeleteById(Guid id)
        {
            var checkExam = _appDataContext.Exams.FirstOrDefault(x => x.Id.Equals(id));
            
            if(checkExam == null)
                return false;

            _appDataContext.Exams.RemoveAsync(checkExam);
            _appDataContext.SaveChangesAsync();
        
            return true;
        }

        public IQueryable<Exam> Get(Expression<Func<Exam, bool>> predicate) 
            => _appDataContext.Exams.Where(predicate.Compile()).AsQueryable();
        

        public async Task<PaginationResult<Exam>> GetByIdAsync(Guid id, int PageToken, int PageSize)
        {
            var query = _appDataContext.Exams
                        .Where(question => question.Id == id).AsQueryable();
            var length = await query.CountAsync();

            var exams = await query
           .Skip((PageToken - 1) * PageSize)
           .Take(PageSize)
           .ToListAsync();

            var paginationResult = new PaginationResult<Exam>
            {
                Items = exams,
                TotalItems = length,
                PageToken = PageToken,
                PageSize = PageSize
            };

            return paginationResult;
        }

        public async Task<Exam> GetByTitleAsync(string title)
        {
            var checkExam = _appDataContext.Exams.FirstOrDefault(x => x.Title.Equals(title));

            if (checkExam == null)
                throw new InvalidOperationException($" {title} title doesn't exist");

            return checkExam;
        }

        public async Task<Exam> UpdateAsync(Exam exam)
        {
            var UpdatingExam = _appDataContext.Exams.FirstOrDefault(x => x.Id == exam.Id);
            
            if (UpdatingExam == null)
                throw new NotImplementedException("This exam does not exist");

            var newExam = new Exam(exam.Title, exam.Description, exam.Duration, exam.ExaminatorId, exam.CreatorId);
            var result = (await _appDataContext.Exams.AddAsync(newExam)).Entity;
            await _appDataContext.SaveChangesAsync();
            return result;
        }
    }
}
