using AssessmentPortal.Application.ViewModels;

namespace AssessmentPortal.Application.Features.Queries
{
    public class GetResultQuery : IRequest<List<ResultResponse>>
    {
        public Guid UserId { get; set; }
    }
}
