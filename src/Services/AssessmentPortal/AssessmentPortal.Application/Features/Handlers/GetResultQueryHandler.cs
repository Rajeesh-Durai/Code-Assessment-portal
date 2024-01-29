using AssessmentPortal.Application.ViewModels;

namespace AssessmentPortal.Application.Features.Handlers
{
    public class GetResultQueryHandler : IRequestHandler<GetResultQuery, List<ResultResponse>>
    {
        private readonly IResultRepository _userResultRepository;
        private readonly IMapper _mapper;

        public GetResultQueryHandler(IResultRepository userResultRepository, IMapper mapper)
        {
            _userResultRepository = userResultRepository;
            _mapper = mapper;
        }

        public async Task<List<ResultResponse>> Handle(GetResultQuery request, CancellationToken cancellationToken)
        {
            var assessmentResult = await _userResultRepository.GetAssessmentResultByUserId(request.UserId);
            return _mapper.Map<List<ResultResponse>>(assessmentResult);
        }
    }
}
