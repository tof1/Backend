namespace TodoListApp;

internal class TodoItem
{
    private string _title = string.Empty;
    private bool _isCompleted;

    public int Id { get; }

    public string Title
    {
        get => _title;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Title cannot be empty.");
            }
            _title = value.Trim();
        }
    }

    public bool IsCompleted => _isCompleted;

    public TodoItem(int id, string title)
    {
        Id = id;
        Title = title;
    }

    public void MarkComplete()
    {
        _isCompleted = true;
    }

    public override string ToString()
    {
        string status = _isCompleted ? "[x]" : "[ ]";
        return $"{Id}. {status} {Title}";
    }
}