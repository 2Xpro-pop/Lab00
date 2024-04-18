using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.Xml;
using PersonNamespace;
using StudentNamespace;
using TeacherNamespace;
using BinaryFormatter;

namespace SerializationDemo;

public static class SerializationDemoClass
{
    [Obsolete("Obsolete")]
    public static void BinarySerialization(object student)
    {
        // Сериализация в бинарном формате
        var formatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
        using (var stream = new System.IO.FileStream("student.bin", System.IO.FileMode.Create, System.IO.FileAccess.Write))
        {
            formatter.Serialize(stream, student);
        }

        // Десериализация из бинарного формата
        using (var stream = new System.IO.FileStream("student.bin", System.IO.FileMode.Open, System.IO.FileAccess.Read))
        {
            Student? deserializedStudent = formatter.Deserialize(stream) as Student;
            Console.WriteLine("Deserialized Student:");
            Console.WriteLine(deserializedStudent);
        }
    }

    public static void SoapSerialization(object student)
    {
        // Сериализация в формате SOAP
        var formatter = new SoapFormatter();
        using (var stream = new System.IO.FileStream("student.soap", System.IO.FileMode.Create, System.IO.FileAccess.Write))
        {
            formatter.Serialize(stream, student);
        }

        // Десериализация из формата SOAP
        using (var stream = new System.IO.FileStream("student.soap", System.IO.FileMode.Open, System.IO.FileAccess.Read))
        {
            Student deserializedStudent = (Student)formatter.Deserialize(stream);
            Console.WriteLine("Deserialized Student:");
            Console.WriteLine(deserializedStudent);
        }
    }
}
