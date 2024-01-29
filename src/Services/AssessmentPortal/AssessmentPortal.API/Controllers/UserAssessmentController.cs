namespace AssessmentPortal.API.Controllers
{
    [Route("user")]
    public class UserAssessmentController : BaseController
    {
        #region Constructor
        private readonly IMapper _mapper;
        private readonly ILogger<UserAssessmentController> _logger;
        public UserAssessmentController(IMediator mediator, IMapper mapper, ILogger<UserAssessmentController> logger) : base(mediator)
        {
            _mapper = mapper;
            _logger = logger;
        }
        #endregion
        [HttpGet("{id}/assessment")]
        public async Task<ActionResult<List<UserAssessmentDetailResponse>>> GetUserAssessmentById(Guid id)
        {

            var query = new GetUserAssessmentQuery { UserId = id };
            _logger.LogInformation($"Returned values: {query}");
            var userAssessment = await Mediator.Send(query);
            return Ok(userAssessment);
        }
        #region Add new User Assessment
        [HttpPost("assessment")]
        public async Task<IActionResult> AddUserAssessment(UserAssessmentDTO userAssessmentDto)
        {
            var user = _mapper.Map<CreateUserAssessmentCommand>(userAssessmentDto);
            var result = await Mediator.Send(user);
            return Ok(result);

        }
        #endregion
    }
}
