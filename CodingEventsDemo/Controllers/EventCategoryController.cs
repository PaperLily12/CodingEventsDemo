using CodingEventsDemo.Data;
using CodingEventsDemo.Models;
using CodingEventsDemo.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace CodingEventsDemo.Controllers
{
    public class EventCategoryController : Controller
    {
        private EventDbContext context;
        public EventCategoryController(EventDbContext dbContext)
        {
            context = dbContext;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<EventCategory> Categories = context.Categories.ToList();
            return View(Categories);
        }

        [HttpGet]
        [Route("/Create")]
        public IActionResult Create()
        {
            AddEventCategoryViewModel viewModel = new AddEventCategoryViewModel();
            return View(viewModel);
        }

        [HttpPost]
        [Route("/Create")]
        public IActionResult ProcessCreateEventCategoryForm(AddEventCategoryViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                EventCategory newCategory = new EventCategory(viewModel.Name);
                context.Categories.Add(newCategory);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return Redirect("Create");
        }
    }
}
