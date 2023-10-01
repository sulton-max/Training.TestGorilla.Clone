using TestGorilla.Domain.Commons;

namespace TestGorilla.Domain.Entities;
/// <summary>
/// Result calculate userAnswers from tests
/// </summary>
public class Result : Auditable
{

    public Guid UserId { get; set; }

    public Guid TestId { get; set; }

    public Guid ExamId { get; set; }

    public Guid CategoryId { get; set; }

    public decimal TestResult { get; set; }

    public decimal ExamResult { get; set; }

    public bool IsDeleted { get; set; }

    public Result(Guid userId, Guid testId, Guid examId, Guid categoryId, decimal testResult, decimal examResult, bool isDeleted)
    {
        UserId = userId;
        TestId = testId;
        ExamId = examId;
        CategoryId = categoryId;
        TestResult = testResult;
        ExamResult = examResult;
        IsDeleted = isDeleted;
    }
    
}