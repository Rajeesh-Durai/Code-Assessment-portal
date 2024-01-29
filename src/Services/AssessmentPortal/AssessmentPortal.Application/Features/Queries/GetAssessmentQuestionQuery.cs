using AssessmentPortal.Application.ViewModels;

namespace AssessmentPortal.Application.Features.Queries
{
    public class GetAssessmentQuestionQuery : IRequest<List<AssessmentQuestionResponse>>
    {
        public Guid UserAssessmentId { get; set; }
    }
}
