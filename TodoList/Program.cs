namespace TodoListApp;

internal class Program
{
    static readonly List<TodoItem> todos = new();
    static int nextId = 1;

    static void Main(string[] args)
    {
        bool running = true;

        while (running)
        {
            Console.WriteLine("\n=== Todo List ===");
            Console.WriteLine("1. Add task");
            Console.WriteLine("2. View tasks");
            Console.WriteLine("3. Mark task as complete");
            Console.WriteLine("4. Delete task");
            Console.WriteLine("5. Exit");
            Console.Write("Choose an option: ");

            switch (Console.ReadLine()?.Trim())
            {
                case "1": AddTask(); break;
                case "2": ViewTasks(); break;
                case "3": CompleteTask(); break;
                case "4": DeleteTask(); break;
                case "5": running = false; break;
                default: Console.WriteLine("Invalid option, try again."); break;
            }
        }

        Console.WriteLine("Goodbye!");
    }

    static void AddTask()
    {
        Console.Write("Enter task title: ");
        string? title = Console.ReadLine();

        try
        {
            todos.Add(new TodoItem(nextId++, title ?? ""));
            Console.WriteLine("Task added.");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    static void ViewTasks()
    {
        if (todos.Count == 0)
        {
            Console.WriteLine("No tasks yet.");
            return;
        }

        foreach (TodoItem item in todos)
        {
            Console.WriteLine(item);
        }
    }

    static void CompleteTask()
    {
        TodoItem? item = FindTask();
        if (item != null)
        {
            item.MarkComplete();
            Console.WriteLine("Task marked as complete.");
        }
    }

    static void DeleteTask()
    {
        TodoItem? item = FindTask();
        if (item != null)
        {
            todos.Remove(item);
            Console.WriteLine("Task deleted.");
        }
    }

    static TodoItem? FindTask()
    {
        Console.Write("Enter task number: ");
        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            Console.WriteLine("That's not a valid number.");
            return null;
        }

        TodoItem? item = todos.FirstOrDefault(t => t.Id == id);
        if (item == null)
        {
            Console.WriteLine("No task with that number.");
        }
        return item;
    }
}