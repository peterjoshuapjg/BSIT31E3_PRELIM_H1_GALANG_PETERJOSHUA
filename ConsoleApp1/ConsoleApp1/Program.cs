using System;
using System.Collections.Generic;
using System.Linq;

class Student
{
    public string Name { get; set; }
    public double Grade1 { get; set; }
    public double Grade2 { get; set; }
    public double Grade3 { get; set; }

    public double Average()
    {
        return (Grade1 + Grade2 + Grade3) / 3;
    }

    public double HighestGrade()
    {
        return Math.Max(Grade1, Math.Max(Grade2, Grade3));
    }
}

class Program
{
    static List<Student> students = new List<Student>();

    static void Main()
    {
        bool running = true;

        while (running)
        {
            Console.WriteLine("\n===== STUDENT SYSTEM =====");
            Console.WriteLine("1. Add Student");
            Console.WriteLine("2. View All Students");
            Console.WriteLine("3. Compute Average Grade");
            Console.WriteLine("4. Find Highest Grade");
            Console.WriteLine("5. Exit");
            Console.WriteLine("==========================");
            Console.Write("Choose an option: ");

            int choice;

            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Invalid input.");
                continue;
            }

            switch (choice)
            {
                case 1:
                    AddStudent();
                    break;

                case 2:
                    ViewStudents();
                    break;

                case 3:
                    ComputeClassAverage();
                    break;

                case 4:
                    FindHighestGrade();
                    break;

                case 5:
                    Console.WriteLine("Exiting program...");
                    Console.WriteLine("Goodbye!");
                    running = false;
                    break;

                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }
        }
    }

    static void AddStudent()
    {
        Console.Write("Enter student name: ");
        string name = Console.ReadLine();

        Console.Write("Enter grade 1: ");
        double grade1 = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter grade 2: ");
        double grade2 = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter grade 3: ");
        double grade3 = Convert.ToDouble(Console.ReadLine());

        students.Add(new Student
        {
            Name = name,
            Grade1 = grade1,
            Grade2 = grade2,
            Grade3 = grade3
        });

        Console.WriteLine("Student added successfully!");
    }

    static void ViewStudents()
    {
        if (students.Count == 0)
        {
            Console.WriteLine("No students found.");
            return;
        }

        foreach (Student student in students)
        {
            Console.WriteLine("\nName: " + student.Name);
            Console.WriteLine("Grades: " +
                              student.Grade1 + ", " +
                              student.Grade2 + ", " +
                              student.Grade3);
            Console.WriteLine("Average: " + student.Average().ToString("F2"));
        }
    }

    static void ComputeClassAverage()
    {
        if (students.Count == 0)
        {
            Console.WriteLine("No students available.");
            return;
        }

        double overallAverage = students.Average(student => student.Average());

        Console.WriteLine("\n===== CLASS AVERAGE =====");
        Console.WriteLine("Overall Average Grade: " + overallAverage.ToString("F2"));
    }

    static void FindHighestGrade()
    {
        if (students.Count == 0)
        {
            Console.WriteLine("No students available.");
            return;
        }

        Student topStudent = students
            .OrderByDescending(student => student.HighestGrade())
            .First();

        Console.WriteLine("\n===== HIGHEST GRADE =====");
        Console.WriteLine("Top Student: " + topStudent.Name);
        Console.WriteLine("Highest Grade: " + topStudent.HighestGrade());
    }
}