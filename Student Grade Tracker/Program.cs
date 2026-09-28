namespace StudentGradeTracker;

internal class Program
{
    static readonly List<Student> students = new();
    static int nextId = 1;

    static void Main(string[] args)
    {
        bool running = true;

        while (running)
        {
            Console.WriteLine("\n=== Student Grade Tracker ===");
            Console.WriteLine("1. Add student");
            Console.WriteLine("2. Add grade to student");
            Console.WriteLine("3. View all students");
            Console.WriteLine("4. View student report");
            Console.WriteLine("5. Exit");
            Console.Write("Choose an option: ");

            switch (Console.ReadLine()?.Trim())
            {
                case "1": AddStudent(); break;
                case "2": AddGrade(); break;
                case "3": ViewAll(); break;
                case "4": ViewReport(); break;
                case "5": running = false; break;
                default: Console.WriteLine("Invalid option, try again."); break;
            }
        }

        Console.WriteLine("Goodbye!");
    }

    static void AddStudent()
    {
        Console.Write("Enter student name: ");
        string? name = Console.ReadLine();

        try
        {
            students.Add(new Student(nextId++, name ?? ""));
            Console.WriteLine("Student added.");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    static void AddGrade()
    {
        Student? student = FindStudent();
        if (student == null) return;

        Console.Write("Enter grade (0-100): ");
        if (!double.TryParse(Console.ReadLine(), out double grade))
        {
            Console.WriteLine("That's not a valid number.");
            return;
        }

        try
        {
            student.AddGrade(grade);
            Console.WriteLine("Grade added.");
        }
        catch (ArgumentOutOfRangeException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    static void ViewAll()
    {
        if (students.Count == 0)
        {
            Console.WriteLine("No students yet.");
            return;
        }

        foreach (Student s in students)
        {
            Console.WriteLine(s.GetDescription());
        }
    }

    static void ViewReport()
    {
        Student? student = FindStudent();
        if (student == null) return;

        Console.WriteLine($"\nReport for {student.Name}");
        if (student.Grades.Count == 0)
        {
            Console.WriteLine("No grades recorded.");
            return;
        }

        foreach (double g in student.Grades)
        {
            Console.WriteLine($"  - {g}");
        }
        Console.WriteLine($"Average: {student.Average:F1} ({student.LetterGrade})");
    }

    static Student? FindStudent()
    {
        Console.Write("Enter student ID: ");
        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            Console.WriteLine("That's not a valid number.");
            return null;
        }

        Student? student = students.FirstOrDefault(s => s.StudentId == id);
        if (student == null)
        {
            Console.WriteLine("No student with that ID.");
        }
        return student;
    }
}