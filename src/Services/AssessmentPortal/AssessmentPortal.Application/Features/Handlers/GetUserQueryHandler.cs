using AssessmentPortal.Application.ViewModels;

namespace AssessmentPortal.Application.Features.Handlers
{
    public class GetUserQueryHandler : IRequestHandler<GetUserQuery, UserResponse>
    {
        #region Constructor
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public GetUserQueryHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        #endregion
        #region Get User by id
        public async Task<UserResponse> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserByEmailAsync(request.Email);
            return _mapper.Map<UserResponse>(user);
        }
        #endregion
    }
}
