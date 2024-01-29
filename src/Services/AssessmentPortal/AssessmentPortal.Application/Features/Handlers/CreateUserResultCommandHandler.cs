namespace AssessmentPortal.Application.Features.Handlers
{
    public class CreateUserResultCommandHandler : IRequestHandler<CreateResultCommand, string>
    {
        #region Constructor
        private readonly IResultRepository _userResultRepository;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        public CreateUserResultCommandHandler(IResultRepository userResultRepository, IMapper mapper, IMediator mediator)
        {
            _userResultRepository = userResultRepository;
            _mapper = mapper;
            _mediator = mediator;
        }
        #endregion
        #region Create new User Result
        public async Task<string> Handle(CreateResultCommand request, CancellationToken cancellationToken)
        {
            var userResult = _mapper.Map<UserResult>(request);
            var result = await _userResultRepository.AddWriteUserResultAsync(userResult);
            if (result == string.Empty)
            {
                throw new CustomException("Invalid");
            }
            var userResultCreatedNotification = _mapper.Map<UserResultCreatedNotification>(userResult);
            await _mediator.Publish(userResultCreatedNotification, cancellationToken);
            return result;
        }
        #endregion
    }
}
