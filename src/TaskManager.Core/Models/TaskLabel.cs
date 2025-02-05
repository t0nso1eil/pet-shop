namespace TaskManager.Core.Models;

public class TaskLabel
{
    private const int MIN_NAME_LENGTH = 2;
    private const int MAX_NAME_LENGTH = 20;
    
    public Guid Id { get; }
    public string Name { get; } = string.Empty;

    private TaskLabel(Guid id, string name)
    {
        Id = id;
        Name = name;
    }

    public static (TaskLabel TaskLabel, string Error) Create(Guid id, string name)
    {
        var error = string.Empty;
        if (name.Length > MAX_NAME_LENGTH || name.Length < MIN_NAME_LENGTH)
        {
            error = "Name must be between 2 and 20 characters";
        }
        var taskLabel = new TaskLabel(id, name);
        return (taskLabel, error);
    }
}