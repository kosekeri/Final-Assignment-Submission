using System;
using System.Linq;

class Program
{
    static void Main()
    {
        using (var context = new StudentContext())
        {
            // Ensure the database is created
            context.Database.EnsureCreated();

            // Add a new student if none exists
            if (!context.Students.Any())
            {
                var student = new Student { Name = "John Doe", Age = 20 };
                context.Students.Add(student);
                context.SaveChanges();
                Console.WriteLine("Student added to the database.");
            }
            else
            {
                Console.WriteLine("Student already exists.");
            }

            // Display all students
            var students = context.Students.ToList();
            foreach (var s in students)
            {
                Console.WriteLine($"Id: {s.Id}, Name: {s.Name}, Age: {s.Age}");
            }
        }
    }
}
