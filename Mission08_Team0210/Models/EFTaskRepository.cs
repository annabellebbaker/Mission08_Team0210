namespace Mission08_Team0210.Models
{
    public class EFTaskRepository : ITaskRepository // inherits from the other repository'
    {
        private TaskContext _context;

        public EFTaskRepository(TaskContext temp)
        {
            _context = temp;
        }

        public void AddTask(Task task)
        {
            _context.Add(task);
            _context.SaveChanges();
        }
        public void RemoveTask(Task task)
        {
            _context.Remove(task);
            _context.SaveChanges();
        }

        public void UpdateTask(Task task)
        {
            _context.Update(task);
            _context.SaveChanges();
            
            var existingTask = _context.Tasks.FirstOrDefault(t => t.TaskId == task.TaskId);
            if (existingTask != null)
            {
                existingTask.Completed = task.Completed;
                _context.SaveChanges();
            }
        }
        
        public List<Task> Tasks => _context.Tasks.ToList();
        public List<Category> Categories => _context.Categories.ToList();
    }
}