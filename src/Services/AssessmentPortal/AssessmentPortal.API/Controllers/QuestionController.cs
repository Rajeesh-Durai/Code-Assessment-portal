namespace AssessmentPortal.API.Controllers
{
    [Route("question")]
    public class QuestionController : BaseController
    {
        #region Constructor
        private readonly IMapper _mapper;
        private readonly ILogger<QuestionController> _logger;
        public QuestionController(IMediator mediator, IMapper mapper, ILogger<QuestionController> logger) : base(mediator)
        {
            _mapper = mapper;
            _logger = logger;
        }
        #endregion
        #region Add new question
        [HttpPost]
        public async Task<IActionResult> AddQuestion(QuestionDTO questionDTO)
        {
            _logger.LogInformation("The Question details :{questionDTO} ", questionDTO);
            var question = _mapper.Map<CreateQuestionCommand>(questionDTO);
            _logger.LogInformation($"Returned values: {question}");
            var result = await Mediator.Send(question);
            return Ok(result);
        }
        #endregion
    }

}
