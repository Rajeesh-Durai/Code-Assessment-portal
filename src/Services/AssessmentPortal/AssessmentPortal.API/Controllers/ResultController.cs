namespace AssessmentPortal.API.Controllers
{
    [Route("users")]
    public class ResultController : BaseController
    {
        #region Constructor
        private readonly IMapper _mapper;
        public ResultController(IMediator mediator, IMapper mapper) : base(mediator)
        {
            _mapper = mapper;
        }
        #endregion

        [HttpGet("{id}/results")]

        public async Task<ActionResult<List<ResultResponse>>> GetResultByUserId(Guid id)
        {
            var query = new GetResultQuery { UserId = id };
            var result = await Mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("{id}/assessment/pending")]
        public async Task<ActionResult<int>> GetCountOfAssessmentPending(Guid id)
        {
            var query = new GetCountOfAssessmentPendingQuery { UserId = id };
            var count = await Mediator.Send(query);
            return Ok(count);
        }

        [HttpGet("{id}/assessment/completed")]
        public async Task<ActionResult<int>> GetCountOfCompletedAssessment(Guid id)
        {
            var query = new GetCountOfCompletedAssessmentQuery { UserId = id };
            var count = await Mediator.Send(query);
            return Ok(count);
        }

        [HttpGet("{id}/result")]
        public async Task<ActionResult<ResultResponse>> GetLastAssessmentResultByUserId(Guid id)
        {
            var query = new GetLastAssessmentResultQuery { UserId = id };
            var result = await Mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("{id}/result/score")]
        public async Task<ActionResult<List<ResultResponse>>> GetTopScoreByUserId(Guid id)
        {
            var query = new GetTopScoreByUserAssessmentIdQuery { UserId = id };
            var userAssessment = await Mediator.Send(query);
            return Ok(userAssessment);
        }

        [HttpPost("/result")]
        public async Task<IActionResult> AddUserResult(UserResultDTO userResultDto)
        {
            var user = _mapper.Map<CreateResultCommand>(userResultDto);
            var result = await Mediator.Send(user);
            return Ok(result);
        }
    }
}
