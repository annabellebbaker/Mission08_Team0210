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
            return View();
        }

        [HttpPost]

        public IActionResult Index() // 
        {
            if (ModelState.IsValid)
            {
                _repo.AddTask(t);
            }

            return View(new Task());

        }

        public IActionResult AddTask()
        {
            ViewBag.Categories = _context.Categories
                .OrderBy(x => x.CategoryName)
                .ToList();

            return View(new Task());
        }

        [HttpPost]
        public IActionResult AddTask(Task response)
        {
            if (ModelState.IsValid == false) // invalid input
            {
                ViewBag.Categories = _context.Categories.ToList();
                return View(response);
            }
            else
            {
                _context.Tasks.Add(response);
                _context.SaveChanges();
                return View("Confirmation", response);
            }
        }

        [HttpGet]
        // this is going to be a reference to the database and CRUD functionality
        public IActionResult Edit(int id)
        {
            var recordToEdit = _context.Tasks.Find(id);

            ViewBag.Categories = _context.Categories
                .ToList();

            return View("AddTask", recordToEdit);
        }


        [HttpPost]
        public IActionResult Edit(Task updatedInfo) // returns ALL the information about the record
        {
            if (ModelState.IsValid == true)
            {
                _context.Tasks.Update(updatedInfo);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            // Re-populate categories if form validation fails
            ViewBag.Categories = _context.Categories.ToList();
            return View("Index", updatedInfo);
        }

        // Delete (POST) - Handle the delete action directly from the index page
        [HttpPost]
        public IActionResult Delete(int id)
        {
            //var taskToDelete = _context.Tasks.SingleOrDefault(x => x.TaskId == id);

            if (taskToDelete != null)
            {
                _context.Tasks.Remove(taskToDelete); // Remove the movie
                _context.SaveChanges(); // Save changes to the database
            }

            return RedirectToAction("Index"); // Redirect back to the index page

        }
