using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UserTask.Db
{
    public class UserDbRepository : IUserDbRepository
    {
        public void CreateTask(Task task)
        {
            using (var context = new usertaskEntities())
            {
                context.Task.Add(task);
                context.SaveChanges();
            }
        }
        public void EditTask(Task task)
        {
            using (var context = new usertaskEntities())
            {
                var entity = context.Task.Where(i => i.t_id == task.t_id).FirstOrDefault();
                if (entity == null)
                {
                    return;
                }
                context.Entry(entity).CurrentValues.SetValues(task);
                context.SaveChanges();
            }
        }

        public void DeleteTask(Task task)
        {
            using (var context = new usertaskEntities())
            {
                var entity = context.Task.Where(i => i.t_id == task.t_id).FirstOrDefault();
                if (entity == null)
                {
                    return;
                }
                context.Task.Remove(entity);
                context.SaveChanges();
            }
        }

        public List<Task> FindAllTasks()
        {
            using (var context = new usertaskEntities())
            {
                return context.Task.ToList();
            }
        }

        public Task FindTaskById(int id)
        {
            using (var context = new usertaskEntities())
            {
                return context.Task.Where(i => i.t_id == id).FirstOrDefault();
            }
        }
    }
}
