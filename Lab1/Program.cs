// MainProgram.cs
using System;
using System.Collections.Generic;
using PersonNamespace;
using StudentNamespace;
using TeacherNamespace;
using SerializationDemo;

class Program
{
    static void Main()
    {
        var teacher = RandomGenerator.RandomTeacher();
        string filePath = "teahcer.bin";
        // Сериализация
        // Создаем случайного студента
        var student = RandomGenerator.RandomStudent();

        // Сериализация в бинарном формате
       SerializationDemoClass.BinarySerialization(student);

        // Сериализация в формате SOAP
        SerializationDemoClass.SoapSerialization(student);
        Console.WriteLine("Hello");
    }
}
