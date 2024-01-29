namespace AssessmentPortal.API.Controllers
{
    [Route("assessment")]
    public class AssessmentQuestionController : BaseController
    {
        #region Constructor
        private readonly ILogger<AssessmentQuestionController> _logger;
        public AssessmentQuestionController(IMediator mediator, ILogger<AssessmentQuestionController> logger) : base(mediator)
        {
            _logger = logger;
        }
        #endregion
        [HttpGet("{id}/question")]
        public async Task<ActionResult<List<AssessmentQuestionResponse>>> GetAssessmentQuestionsById(Guid id)
        {
            _logger.LogInformation("Get the assessment details by id: {userAssessmentId}", id);
            var query = new GetAssessmentQuestionQuery { UserAssessmentId = id };
            _logger.LogInformation($"Returned values: {query}");
            var assessmentQuestionDetails = await Mediator.Send(query);
            return Ok(assessmentQuestionDetails);
        }
    }
}
