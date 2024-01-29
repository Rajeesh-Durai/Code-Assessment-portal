namespace Judge0.Application.Interface
{
    public interface ISubmissionAppService
    {
        Task<SubmissionResult> PostAsync(Submission submission);
    }
}
