namespace Mission08_Team0210.Models
{
    public interface ITaskRepository 
    {
        List<Category>Categories { get; }
        List<Task> Tasks { get; }
    }
}
