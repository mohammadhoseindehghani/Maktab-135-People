using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UI_MVC._Framework;
using UI_MVC.Models.Database;
using UI_MVC.Models.Entities;
using UI_MVC.Services;

namespace UI_MVC.Controllers
{
    [Authorize]
    public class PeopleController : Controller
    {
        private readonly AppPeopleDbContext dbContext;
        private readonly IPeopleRepository _peopleRepository;
        private readonly ILogger<PeopleController> _logger;

        public PeopleController(
            AppPeopleDbContext context,
            IPeopleRepository peopleRepository,
            ILogger<PeopleController> logger)
        {
            dbContext = context;
            _peopleRepository = peopleRepository;
            _logger = logger;
        }



        public IActionResult Index()
        {
            ViewBag.Title = "لیست افراد";
            ViewData["Title"] = "لیست افراد";
            TempData["Title"] = "Temp Data Value";
            var people = _peopleRepository.GetAll();

            _logger.LogTrace("Error 1");
            _logger.LogDebug("Error 1");
            _logger.LogInformation("Error 1");
            _logger.LogWarning("Error 1");
            _logger.LogError("Error 1");
            _logger.LogCritical("Error 1");

            var output = View(people);
            return output;

            
        }

        //[HttpGet]
        public IActionResult Add()
        {
            var td = TempData["Title"];
            TempData.Keep("Title");

            var model = new Person();
            model.Age = -24;
            return View(model);
        }
        
        [HttpPost]
        // Model Binding

        public IActionResult Add(Person model)
        {
            if (ModelState.IsValid == false)
            {
                return View(model);
            }

            //var context = HttpContext.Request.Form;
            
            try
            {
                /*
                 *
                 *
                 *
                 *
                 *
                 */
                //throw new Exception("new exception");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("","خطا در عملیات");
                return View(model);
            }

            dbContext.People.Add(model);
            dbContext.SaveChanges(); // Validation

            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var result = dbContext.People.Find(id);

            ViewBag.Cities = new Dictionary<string, string>()
            {
            };
            ViewData["Cities"] = new Dictionary<string, string>()
            {
            };
            ViewBag.PersonType = "حقیقی";

            // return RedirectToAction("Index");

            return View(result);
        }

        [HttpPost]
        public IActionResult Edit(Person model)
        {
            var result = _peopleRepository.FindById(model.Id);

            result.FirstName = model.FirstName;
            result.LastName = model.LastName;
            result.PhoneNumber = model.PhoneNumber;
            result.CityName = model.CityName;

            //dbContext.People.Update(result);
            dbContext.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var result = _peopleRepository.FindById(id);

            dbContext.People.Remove(result);
            
            dbContext.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}
