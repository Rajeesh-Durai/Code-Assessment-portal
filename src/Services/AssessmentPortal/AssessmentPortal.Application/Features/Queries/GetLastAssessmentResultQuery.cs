using AssessmentPortal.Application.ViewModels;

namespace AssessmentPortal.Application.Features.Queries
{
    public class GetLastAssessmentResultQuery : IRequest<ResultResponse>
    {
        public Guid UserId { get; set; }
    }
}
