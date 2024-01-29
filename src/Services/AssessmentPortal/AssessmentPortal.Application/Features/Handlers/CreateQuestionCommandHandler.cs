namespace AssessmentPortal.Application.Features.Handlers
{
    public class CreateQuestionCommandHandler : IRequestHandler<CreateQuestionCommand, string>
    {
        #region Constructor
        private readonly IQuestionRepository _questionRepository;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        public CreateQuestionCommandHandler(IQuestionRepository questionRepository, IMapper mapper, IMediator mediator)
        {
            _questionRepository = questionRepository;
            _mapper = mapper;
            _mediator = mediator;
        }
        #endregion
        #region Create new Question
        public async Task<string> Handle(CreateQuestionCommand request, CancellationToken cancellationToken)
        {
            var question = _mapper.Map<Question>(request);
            var assessmentQuestion = await _questionRepository.AddWriteQuestionAsync(question);
            if (assessmentQuestion == string.Empty)
            {
                throw new CustomException("Invalid");
            }
            var QuestionCreatedNotification = _mapper.Map<QuestionCreatedNotification>(question);
            await _mediator.Publish(QuestionCreatedNotification, cancellationToken);
            return assessmentQuestion;
        }
        #endregion
    }
}
