using Microsoft.AspNetCore.Mvc;
using UI_MVC.Services;

namespace Maktab135_API.Controllers
{
	[ApiController]
	[Route("api/people")]
    public class PeopleController : ControllerBase
    {
	    private readonly IPeopleRepository _peopleRepository;

	    public PeopleController(IPeopleRepository peopleRepository)
	    {
		    _peopleRepository = peopleRepository;
	    }

		[HttpGet]
        public IActionResult Index()
        {
	        var model = _peopleRepository.GetAll();
			return Ok(model);
        }
    }
}
