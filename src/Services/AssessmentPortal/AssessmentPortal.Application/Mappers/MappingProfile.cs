using AssessmentPortal.Application.ViewModels;
using AssessmentPortal.Domain.DTOs;

namespace AssessmentPortal.Application.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserDTO, CreateUserCommand>().ReverseMap();
            CreateMap<UserAssessmentDTO, CreateUserAssessmentCommand>().ReverseMap();
            CreateMap<UserResultDTO, CreateResultCommand>().ReverseMap();
            CreateMap<CreateUserAssessmentCommand, UserAssessment>().ReverseMap();
            CreateMap<CreateUserCommand, User>().ReverseMap();
            CreateMap<CreateResultCommand, UserResult>().ReverseMap();
            CreateMap<UserResultDTO, ResultResponse>().ReverseMap();
            CreateMap<User, UserResponse>().ReverseMap();
            CreateMap<GetAssessmentQuestionDTO, AssessmentQuestionResponse>().ReverseMap();
            CreateMap<GetUserAssessmentDetailsDTO, UserAssessmentDetailResponse>().ReverseMap();
            CreateMap<QuestionCreatedNotification, Question>().ReverseMap();
            CreateMap<UserAssessmentCreatedNotification, UserAssessment>().ReverseMap();
            CreateMap<UserCreatedNotification, User>().ReverseMap();
            CreateMap<UserResultCreatedNotification, UserResult>().ReverseMap();

        }
    }
}
