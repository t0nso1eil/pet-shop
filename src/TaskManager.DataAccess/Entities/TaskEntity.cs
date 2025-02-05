namespace TaskManager.DataAccess.Entities;

public class TaskEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public TaskStatusEntity Status { get; set; }
    public UserEntity Creator { get; set; }
    public UserEntity? Assignee { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? DueDate { get; set; }
    public TaskLabelEntity? Label { get; set; }
    public ProjectEntity Project { get; set; }
}