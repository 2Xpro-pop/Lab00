using System;
using System.Collections.Generic;
using PersonNamespace;


namespace StudentNamespace;

[Serializable]
public class Student : Person
{
    public int StudentID { get; set; }

    public override void Print()
    {
        Console.WriteLine($"Name: {Name}, Age: {Age}, Student ID: {StudentID}");
    }

    public override string ToString()
    {
        return $"Name: {Name}, Age: {Age}, Student ID: {StudentID}";
    }

}
