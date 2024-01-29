namespace AssessmentPortal.API.Controllers
{
    [Route("api")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        private readonly IMediator _mediator;
        public BaseController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public IMediator Mediator => _mediator;
    }
}
