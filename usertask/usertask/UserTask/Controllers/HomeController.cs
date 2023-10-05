using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using UserTask.Models;
using UserTask.Db;
using Task = UserTask.Db.Task;
using System.Reflection.Metadata;

namespace UserTask.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IUserDbRepository _repository;

        public HomeController(ILogger<HomeController> logger, IUserDbRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult CreateTask()
        {
            Task task = new()
            {
                t_title = "test",
                t_description = "test2",
                t_due_date = DateTime.Now.AddDays(1),
                t_priority_level = 1,
                t_user_id = 1,
                t_status = 1,
            };
            _repository.CreateTask(task);
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public event EventHandler Clicked;

        // Method to trigger the event
        protected virtual void OnClicked(EventArgs e)
        {
            Clicked?.Invoke(this, e);
        }

        // Method that simulates a button click
        public void Click()
        {
            OnClicked(EventArgs.Empty);
        }
    }
}