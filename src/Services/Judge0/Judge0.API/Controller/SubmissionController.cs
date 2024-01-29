using Judge0.Application.Interface;

namespace Judge0.API.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class SubmissionController : ControllerBase
    {
        private readonly ISubmissionAppService _submissionService;

        public SubmissionController(ISubmissionAppService submissionService)
        {
            _submissionService = submissionService;
        }

        [HttpPost("submit")]
        public async Task<ActionResult<SubmissionResult>> Submit(Submission submission)
        {
            try
            {
                var tokens = await _submissionService.PostAsync(submission);
                return Ok(tokens);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }
    }
}
