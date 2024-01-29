using AssessmentPortal.Domain.CoreModels;
using AssessmentPortal.Domain.DTOs;

namespace AssessmentPortal.Domain.Repositories
{
    public interface IResultRepository
    {
        Task<string> AddWriteUserResultAsync(UserResult userResult);
        Task<string> AddReadUserResultAsync(UserResult userResult);
        Task<IEnumerable<UserResultDTO>> GetAssessmentResultByUserId(Guid userId);
        Task<IEnumerable<UserResultDTO>> GetLastUserResultByIdAsync(Guid userId);
        Task<IEnumerable<UserResultDTO>> GetComparedUserResultByIdAsync(Guid userId);
        Task<List<UserResult>> GetAllAsync();
    }
}
