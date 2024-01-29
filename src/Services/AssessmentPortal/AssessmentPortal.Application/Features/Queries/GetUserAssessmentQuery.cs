using AssessmentPortal.Application.ViewModels;

namespace AssessmentPortal.Application.Features.Queries
{
    public class GetUserAssessmentQuery : IRequest<List<UserAssessmentDetailResponse>>
    {
        public Guid UserId { get; set; }
    }
}
