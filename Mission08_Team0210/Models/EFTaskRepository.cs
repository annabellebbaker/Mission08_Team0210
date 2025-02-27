namespace Mission08_Team0210.Models
{
    public class EFTaskRepository : ITaskRepository // inherits from the other repository'
    {
        private TaskContext _context;

        public EFTaskRepository(TaskContext temp)
        {
            _context = temp;
        }
        public List<Task> Tasks => _context.Tasks.ToList();
        public List<Category> Categories => _context.Categories.ToList();
    }
}
