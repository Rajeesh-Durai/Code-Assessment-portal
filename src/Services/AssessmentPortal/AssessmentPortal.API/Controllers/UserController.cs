namespace AssessmentPortal.API.Controllers
{
    [Route("user")]
    public class UserController : BaseController
    {
        #region Constructor
        private readonly IMapper _mapper;
        public UserController(IMediator mediator, IMapper mapper) : base(mediator)
        {
            _mapper = mapper;
        }
        #endregion
        [HttpGet("{email}")]
        public async Task<ActionResult<UserResponse>> GetUserByEmail(string email)
        {
            var query = new GetUserQuery { Email = email };
            var userAssessment = await Mediator.Send(query);
            return Ok(userAssessment);
        }
        #region Add new User
        [HttpPost]
        public async Task<IActionResult> AddUser(UserDTO userDto)
        {
            var user = _mapper.Map<CreateUserCommand>(userDto);
            var result = await Mediator.Send(user);
            return Ok(result);

        }
        #endregion
    }
}
