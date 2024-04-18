
using System.Reflection;

const string StudentDllName = "StudentNameSpace.dll";

var asm = Assembly.LoadFrom(StudentDllName);

var studentType = asm.GetType("StudentNamespace.Student")!;

Console.WriteLine($"Student type: {studentType}");

PrintAllBaseTypeAndInterfaces(studentType);

Console.WriteLine("Get and Set property by refluctionn");

var studentInstance = Activator.CreateInstance(studentType)!;

var nameProperty = studentType.GetProperty("Name")!;
nameProperty.SetValue(studentInstance, "John");

Console.WriteLine($"Name: {nameProperty.GetValue(studentInstance)}");

Console.WriteLine();

// Create Dictionary<string, int> instance with reflection

var dictionaryType = typeof(Dictionary<string, int>);
var dictionaryInstance = Activator.CreateInstance(dictionaryType);

PrintDictionary((Dictionary<string, int>)dictionaryInstance!);

// Заполняем словарь всякой ерундой

var addMethod = dictionaryType.GetMethod("Add")!;
addMethod.Invoke(dictionaryInstance, new object[] { "one", 1 });
addMethod.Invoke(dictionaryInstance, new object[] { "two", 2 });

PrintDictionary((Dictionary<string, int>)dictionaryInstance!);

static void PrintAllBaseTypeAndInterfaces(Type type)
{
    if (type.BaseType == null)
    {
        return;
    }

    Console.WriteLine($"Base type: {type.BaseType}");

    var interfaces = type.GetInterfaces();

    if (interfaces.Length > 0)
    {
        Console.WriteLine("Interfaces:");
    }

    foreach (var @interface in interfaces)
    {
        Console.WriteLine(@interface);
    }

    if (type.BaseType != null)
    {
        PrintAllBaseTypeAndInterfaces(type.BaseType);
    }
}

static void PrintDictionary(Dictionary<string, int> dic)
{
    Console.WriteLine("Dictionary:");
    foreach (var (key, value) in dic)
    {
        Console.WriteLine($"\t {key} - {value}");
    }
}