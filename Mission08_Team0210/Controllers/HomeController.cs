using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Mission08_Team0210.Models;

namespace Mission08_Team0210.Controllers
{
    public class HomeController : Controller
    {
        private ITaskRepository _repo;

        public HomeController(ITaskRepository temp)
        {
            _repo = temp;
        }

        [HttpGet]

        public IActionResult Index() // returning to the index page, which is displaying the main time management matrix
        {
            var taskList = _repo.Tasks.Where(X => X.Completed == false).ToList();

            return View(taskList);
          
        }

        [HttpGet]
        public IActionResult AddForm()
        {
            ViewBag.Categories = _repo.Categories.ToList();

            return View(new Mission08_Team0210.Models.Task());
        }

        [HttpPost]
        public IActionResult AddForm(Mission08_Team0210.Models.Task t)
        {

            ViewBag.Categories = _repo.Categories.ToList();
            if (ModelState.IsValid)
            {
                _repo.AddTask(t);
                
                return View("Confirmation");

            }

            return View(new Mission08_Team0210.Models.Task());
        }


    }
}