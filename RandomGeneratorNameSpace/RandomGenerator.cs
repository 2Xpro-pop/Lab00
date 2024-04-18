// RandomGenerator.cs
using System;
using PersonNamespace;
using StudentNamespace;
using TeacherNamespace;

public static class RandomGenerator
{
    private static Random random = new Random();

    public static Person RandomPerson()
    {
        int choice = random.Next(3);
        switch (choice)
        {
            case 0:
                return RandomStudent();
            case 1:
                return RandomTeacher();
            default:
                return new Person { Name = "Random Person", Age = random.Next(18, 60) };
        }
    }

    public static Student RandomStudent()
    {
        return new Student
        {
            Name = "Zhibek Orozmamatova",
            Age = random.Next(18, 23),
            StudentID = random.Next(1000, 9999)
        };
    }

    public static Teacher RandomTeacher()
    {
        return new Teacher
        {
            Name = "Irina Vladimirovna",
            Age = random.Next(25, 35),
            Students = new List<Student> { RandomStudent(), RandomStudent() }
        };
    }
}
