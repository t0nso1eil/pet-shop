namespace TaskManager.DataAccess.Entities;

public class ProjectEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public UserEntity Owner { get; set; }
    public ICollection<UserEntity> Members { get; set; }
    public ICollection<TaskEntity> Tasks { get; set; }
}