using Microsoft.AspNetCore.Mvc;
using SimpleApp.Data.Domain;
using SimpleApp.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleApp.Controllers
{
    public class PersonController : Controller
    {
        private readonly PersonService _personService = null;

        public PersonController(PersonService personService)
        {
            _personService = personService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Search()
        {
            return PartialView("PersonList", await _personService.SearchAsync());
        }

        public async Task<IActionResult> Register(int id = 0)
        {
            var model = await _personService.GetByIdAsNoTrackingAsync(id);
            if (model == null)
            {
                model = new Person();
                model.Gender = true;
                model.Birthday = DateTime.Now;
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(Person model)
        {
            if (model.ID == 0)
            {
                await _personService.InsertAsync(model);
            }
            else
            {
                await _personService.UpdateAsync(model);
            }
            TempData["Success"] = "true";
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            await _personService.DeleteAsync(id);
            return Ok();
        }
    }
}
