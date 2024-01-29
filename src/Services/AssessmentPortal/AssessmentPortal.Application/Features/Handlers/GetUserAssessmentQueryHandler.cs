﻿using AssessmentPortal.Application.ViewModels;

namespace AssessmentPortal.Application.Features.Handlers
{
    public class GetUserAssessmentQueryHandler : IRequestHandler<GetUserAssessmentQuery, List<UserAssessmentDetailResponse>>
    {
        #region Constructor
        private readonly IUserAssessmentRepository _userAssessmentRepository;
        private readonly IMapper _mapper;
        public GetUserAssessmentQueryHandler(IUserAssessmentRepository userAssessmentRepository, IMapper mapper)
        {
            _userAssessmentRepository = userAssessmentRepository;
            _mapper = mapper;
        }
        #endregion
        #region Get Assessment by User id
        public async Task<List<UserAssessmentDetailResponse>> Handle(GetUserAssessmentQuery request, CancellationToken cancellationToken)
        {
            var userAssessment = await _userAssessmentRepository.GetUserAssessmentByIdAsync(request.UserId);
            return _mapper.Map<List<UserAssessmentDetailResponse>>(userAssessment);
        }
        #endregion
    }
}
