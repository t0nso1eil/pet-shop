namespace TaskManager.Core.Models;

public class Task
{
    private const int MIN_SUMMARY_LENGTH = 3;
    private const int MAX_SUMMARY_LENGTH = 100;
    private const int MAX_DESCRIPTION_LENGTH = 1000;
    
    public Guid Id { get; }
    public string Summary { get; } = string.Empty;
    public string? Description { get; } = string.Empty;
    public TaskStatus Status { get; }
    public User Creator { get; }
    public User? Asignee { get; }
    public DateTime CreatedAt { get; }
    public DateTime? DueDate { get; }
    public TaskLabel? Label { get; }
    public Project Project { get; }

    private Task(Guid id, string summary, Project project, string? description, TaskStatus status, User creator, User? asignee, DateTime createdAt, DateTime? dueDate, TaskLabel? label)
    {
        Id = id;
        Summary = summary;
        Project = project;
        if (string.IsNullOrEmpty(description))
        {
            Description = description;
        }
        Status = status;
        Creator = creator;
        if (asignee is not null)
        {
            Asignee = asignee;
        }
        CreatedAt = createdAt;
        if (dueDate is not null)
        {
            DueDate = dueDate;
        }
        if (label is not null)
        {
            Label = label;
        }
    }

    public static (Task Task, string Error) Create(Guid id, string summary, Project project, string? description, TaskStatus status, User creator, User? asignee, DateTime createdAt, DateTime? dueDate, TaskLabel? label)
    {
        var error = string.Empty;
        if (!CheckSummary(summary) || !CheckDescription(description) || !CheckDueDate(createdAt, dueDate))
        {
            error = "Invalid data entered";
        }
        var task = new Task(id, summary, project, description, status, creator, asignee, createdAt, dueDate, label);
        return (task, error);
    }

    private static bool CheckSummary(string summary)
    {
        return summary.Length is >= MIN_SUMMARY_LENGTH and <= MAX_SUMMARY_LENGTH && !string.IsNullOrEmpty(summary);
    }

    private static bool CheckDescription(string? description)
    {
        if (string.IsNullOrEmpty(description))
        {
            return true;
        }
        return description.Length <= MAX_DESCRIPTION_LENGTH;
    }

    private static bool CheckDueDate(DateTime createdAt, DateTime? dueDate)
    {
        if (dueDate is null)
        {
            return true;
        }
        return dueDate <= createdAt;
    }
}