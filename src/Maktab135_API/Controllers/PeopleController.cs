using Microsoft.AspNetCore.Mvc;
using UI_MVC.Models.Entities;
using UI_MVC.Services;

namespace Maktab135_API.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	//[Route("api/people")]
	public class PeopleController : ControllerBase
    {
	    private readonly IPeopleRepository _peopleRepository;

	    public PeopleController(IPeopleRepository peopleRepository)
	    {
		    _peopleRepository = peopleRepository;
	    }

		[HttpGet()]
		public List<Person> Index()
		{
			var model = _peopleRepository.GetAll();
			return model;
		}

		//[HttpGet("{id}/details")]
		[HttpGet("{id}")]
		public IActionResult GetDetails(int id)
		{
			var model = _peopleRepository.GetAll().Find(p => p.Id == id);
			return Ok(model);
		}


		//[HttpPost("add")]
		//[HttpPost("[action]")]
		[HttpPost]
		public IActionResult Add([FromHeader] string apiKey, [FromBody] Person model)
		{
			if (apiKey == "d97afbef-92b9-4b6c-bba2-7fc6fa98c7d3")
			{
				var id = _peopleRepository.Add(model);
				return Ok(id);
			}
			return Unauthorized();
		}

		[HttpPut]
		public IActionResult Update([FromHeader] string apiKey, [FromBody] Person model)
		{
			if (apiKey == "d97afbef-92b9-4b6c-bba2-7fc6fa98c7d3")
			{
				return Ok();
			}
			return Unauthorized();
		}

		[HttpDelete]
		public IActionResult Delete([FromHeader] string apiKey, int id)
		{
			if (apiKey == "d97afbef-92b9-4b6c-bba2-7fc6fa98c7d3")
			{
				return Ok();
			}
			return Unauthorized();
		}

		//[HttpPost("add")]
		[HttpPatch("{id}/set-avatar")]
		public IActionResult SetAvatar([FromHeader] string apiKey, IFormFile Image)
		{
			if (apiKey == "d97afbef-92b9-4b6c-bba2-7fc6fa98c7d3")
			{
				// Upload
				return Ok();
			}
			return Unauthorized();
		}
	}
}
