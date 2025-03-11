using System;
using System.Collections.Generic;

class Student
{
    public int Id;
    public string Name;
    private List<int> Marks;

    public Student(int id, string name)
    {
        Id = id;
        Name = name;
        Marks = new List<int>();
    }

    public void AddMark(int mark)
    {
        Marks.Add(mark);
    }

    public double GetAverage()
    {
        if (Marks.Count == 0) return 0;
        double total = 0;
        foreach (int mark in Marks)
        {
            total += mark;
        }
        return total / Marks.Count;
    }
}

class Teacher
{
    public int Id;
    public string Name;
    public string Subject;

    public Teacher(int id, string name, string subject)
    {
        Id = id;
        Name = name;
        Subject = subject;
    }

    public void GiveMark(Student student, int mark)
    {
        student.AddMark(mark);
        Console.WriteLine($"{Name} gave {mark} marks to {student.Name}");
    }
}

class School
{
    public string Name;
    public string Address;
    private List<Student> Students;

    public School(string name, string address)
    {
        Name = name;
        Address = address;
        Students = new List<Student>();
    }

    public void AddStudent(Student student)
    {
        Students.Add(student);
        Console.WriteLine($"{student.Name} joined {Name}");
    }

    public void ShowDetails()
    {
        Console.WriteLine($"\nSchool: {Name}");
        Console.WriteLine($"Address: {Address}");
        Console.WriteLine("Students:");
        foreach (Student student in Students)
        {
            Console.WriteLine($"- {student.Name} (ID: {student.Id}) - Average: {student.GetAverage()}");
        }
    }
}

class Program
{
    static void Main()
    {
        Student s1 = new Student(101, "Ali");
        Student s2 = new Student(102, "Bilal");
        Student s3 = new Student(103, "Usman");

        Teacher t1 = new Teacher(201, "Hamid", "Science");
        Teacher t2 = new Teacher(202, "Rashid", "Math");

        School school = new School("Bright Future School", "Lahore");

        school.AddStudent(s1);
        school.AddStudent(s2);
        school.AddStudent(s3);

        t1.GiveMark(s1, 88);
        t1.GiveMark(s2, 76);
        t2.GiveMark(s3, 91);
        t2.GiveMark(s3, 82);

        school.ShowDetails();
    }
}
