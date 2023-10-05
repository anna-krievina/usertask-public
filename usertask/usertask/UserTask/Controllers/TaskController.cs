using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserTask.Db;
using UserTask.Helpers;
using UserTask.Models;

namespace UserTask.Controllers
{
    public class TaskController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IUserDbRepository _repository;

        public TaskController(ILogger<HomeController> logger, IUserDbRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        // GET: TaskController/Create
        public ActionResult Create()
        {
            TaskModel model = new TaskModel();
            return View("Create", model);
        }

        // POST: TaskController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TaskModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (model.Id == 0)
                    {
                        _repository.CreateTask(TaskMapper.TaskModelToTask(model));
                    }
                    else
                    {
                        _repository.EditTask(TaskMapper.TaskModelToTask(model));
                    }
                    return RedirectToAction(nameof(List));
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex.Message);
                }
            }
            return View(model);
        }

        // GET: TaskController/Edit/5
        public ActionResult Edit(int id)
        {
            TaskModel model = new TaskModel();
            Db.Task task = _repository.FindTaskById(id);
            if (task != null)
            {
                model = TaskMapper.TaskToTaskModel(task);
            }
            return View("Create", model);
        }

        // GET: TaskController/Delete/5
        public ActionResult Delete(int id)
        {
            Db.Task task = _repository.FindTaskById(id);
            if (task != null)
            {
                _repository.DeleteTask(task);
            }
            return RedirectToAction(nameof(List));
        }


        public ActionResult List()
        {
            TaskListModel model = new TaskListModel();
            try
            {
                model.taskModels.AddRange(TaskMapper.TaskToTaskModelList(_repository.FindAllTasks()));
            } 
            catch (Exception ex)
            {
                int breakpoint = 0;
            }
            return View(model);
        }
    }
}
