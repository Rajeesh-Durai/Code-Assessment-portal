using Judge0.Domain.Model;

namespace Judge0.Domain.Interface
{
    public interface ISubmissionService
    {
        Task<string> SubmitAsync(Submission submission);
        Task<SubmissionResult> GetResultAsync(string token);
    }
}
