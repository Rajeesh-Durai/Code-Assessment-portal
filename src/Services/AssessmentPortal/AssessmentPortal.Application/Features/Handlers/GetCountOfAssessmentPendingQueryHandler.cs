namespace AssessmentPortal.Application.Features.Handlers
{
    public class GetCountOfAssessmentPendingQueryHandler : IRequestHandler<GetCountOfAssessmentPendingQuery, int>
    {
        #region Constructor
        private readonly IResultRepository _userResultRepository;
        public GetCountOfAssessmentPendingQueryHandler(IResultRepository userResultRepository)
        {
            _userResultRepository = userResultRepository;
        }
        #endregion
        #region Get count of pending assessments
        public async Task<int> Handle(GetCountOfAssessmentPendingQuery request, CancellationToken cancellationToken)
        {
            var assessmentPending = await _userResultRepository.GetAssessmentResultByUserId(request.UserId);
            return assessmentPending.Count(u => u.Status == "pending");
        }
        #endregion
    }
}
