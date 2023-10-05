using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserTask.Db
{
    public interface IUserDbRepository
    {
        void CreateTask(Task task);
        void EditTask(Task task);
        void DeleteTask(Task task);
        List<Task> FindAllTasks();
        Task FindTaskById(int id);
    }
}
