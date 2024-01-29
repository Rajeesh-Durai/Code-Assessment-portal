using AssessmentPortal.Application.ViewModels;

namespace AssessmentPortal.Application.Features.Queries
{
    public class GetTopScoreByUserAssessmentIdQuery : IRequest<List<ResultResponse>>
    {
        public Guid UserId { get; set; }
    }
}
