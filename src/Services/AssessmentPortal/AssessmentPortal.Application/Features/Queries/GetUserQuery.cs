using AssessmentPortal.Application.ViewModels;

namespace AssessmentPortal.Application.Features.Queries
{
    public class GetUserQuery : IRequest<UserResponse>
    {
        public string Email { get; set; } = string.Empty;
    }
}
