using AssessmentPortal.Application.ViewModels;

namespace AssessmentPortal.Application.Features.Handlers
{
    public class GetLastAssessmentResultQueryHandler : IRequestHandler<GetLastAssessmentResultQuery, ResultResponse>
    {
        #region Constructor
        private readonly IResultRepository _userResultRepository;
        private readonly IMapper _mapper;
        public GetLastAssessmentResultQueryHandler(IResultRepository userResultRepository, IMapper mapper)
        {
            _userResultRepository = userResultRepository;
            _mapper = mapper;
        }
        #endregion
        #region Get last assessment result of a particular user
        public async Task<ResultResponse> Handle(GetLastAssessmentResultQuery request, CancellationToken cancellationToken)
        {
            var userResults = await _userResultRepository.GetLastUserResultByIdAsync(request.UserId);
            var finalAssessmentResult = _mapper.Map<List<ResultResponse>>(userResults);
            return finalAssessmentResult.Last();
        }
        #endregion
    }
}
