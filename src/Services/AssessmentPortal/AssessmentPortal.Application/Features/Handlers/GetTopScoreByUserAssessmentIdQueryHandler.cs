using AssessmentPortal.Application.ViewModels;

namespace AssessmentPortal.Application.Features.Handlers
{
    public class GetTopScoreByUserAssessmentIdQueryHandler : IRequestHandler<GetTopScoreByUserAssessmentIdQuery, List<ResultResponse>>
    {
        #region Constructor
        private readonly IResultRepository _userResultRepository;
        private readonly IMapper _mapper;
        public GetTopScoreByUserAssessmentIdQueryHandler(IResultRepository userResultRepository, IMapper mapper)
        {
            _userResultRepository = userResultRepository;
            _mapper = mapper;
        }
        #endregion
        #region Get top score of Assessment by user id
        public async Task<List<ResultResponse>> Handle(GetTopScoreByUserAssessmentIdQuery request, CancellationToken cancellationToken)
        {
            var topScore = await _userResultRepository.GetComparedUserResultByIdAsync(request.UserId) ??
                throw new CustomException("NoId");
            return _mapper.Map<List<ResultResponse>>(topScore);
        }
        #endregion
    }
}
