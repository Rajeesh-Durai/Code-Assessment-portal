namespace AssessmentPortal.Application.Features.Handlers
{
    public class GetCountOfCompletedAssessmentQueryHandler : IRequestHandler<GetCountOfCompletedAssessmentQuery, int>
    {
        #region Constructor
        private readonly IResultRepository _userResultRepository;
        public GetCountOfCompletedAssessmentQueryHandler(IResultRepository userResultRepository)
        {
            _userResultRepository = userResultRepository;
        }
        #endregion
        #region Get count of completed assessments
        public async Task<int> Handle(GetCountOfCompletedAssessmentQuery request, CancellationToken cancellationToken)
        {
            var completedAssessment = await _userResultRepository.GetAssessmentResultByUserId(request.UserId);
            return completedAssessment.Count(u => u.Status == "completed");
        }
        #endregion
    }
}
