

namespace Judge0.Application
{
    public class SubmissionAppService : ISubmissionAppService
    {
        private readonly ISubmissionService _submissionService;

        public SubmissionAppService(ISubmissionService submissionService)
        {
            _submissionService = submissionService;
        }

        public async Task<SubmissionResult> PostAsync(Submission submission)
        {
            var response = await _submissionService.SubmitAsync(submission);
            var token = response;
            return await  _submissionService.GetResultAsync(token);
        }
    }
}
