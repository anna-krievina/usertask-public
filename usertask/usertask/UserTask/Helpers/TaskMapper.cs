using UserTask.Models;
using UserTask.Db;
using Task = UserTask.Db.Task;
using Microsoft.VisualBasic;

namespace UserTask.Helpers
{
    public class TaskMapper
    {
        public static TaskModel TaskToTaskModel(Task task)
        {
            return new TaskModel
            {
                Id = task.t_id,
                Title = task.t_title,
                Description = task.t_description,
                DueDate = task.t_due_date ?? DateTime.Now,
                Prioritylevel = task.t_priority_level,
                Status = task.t_status
            };
        }

        public static Task TaskModelToTask(TaskModel task)
        {
            return new Task
            {
                t_id = task.Id,
                t_title = task.Title,
                t_description = task.Description,
                t_due_date = task.DueDate,
                t_priority_level = task.Prioritylevel,
                t_status = task.Status
            };
        }
        public static List<TaskModel> TaskToTaskModelList(List<Task> taskList)
        {
            List<TaskModel> taskModelList = new List<TaskModel>();
            foreach (var task in taskList)
            {
                taskModelList.Add(TaskToTaskModel(task));
            }
            return taskModelList;
        }
    }
}
