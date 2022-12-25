namespace Todo.API.Data;

public class TodoItem
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public bool Completed { get; set; }
    //public int CategoryId { get; set; }
    public DateTime CreatedAt { get; set; }
}