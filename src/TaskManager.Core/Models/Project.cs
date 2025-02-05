namespace TaskManager.Core.Models;

public class Project
{
    private const int MIN_NAME_LENGTH = 2;
    private const int MAX_NAME_LENGTH = 50;
    public Guid Id { get; }
    public string Name { get; }
    public string Description { get; }
    public User Owner { get; }

    private Project(Guid id, string name, string description, User owner)
    {
        Id = id;
        Name = name;
        Description = description;
        Owner = owner;
    }

    public static (Project Project, string Error) Create(Guid id, string name, string description, User owner)
    {
        var error = string.Empty;
        if (name.Length is < MIN_NAME_LENGTH or > MAX_NAME_LENGTH)
        {
            error = "Name must be between 2 and 50 characters long.";
        }

        var project = new Project(id, name, description, owner);
        return (project, error);
    }
}