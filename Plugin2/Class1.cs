using PlugableLibrary;

namespace Plugin2;
public class Class1 : IPlugin
{
    public void Run()
    {
        Console.WriteLine("Plugin2 is running from Class1");
    }
}

public class Class2 : IPlugin
{
    public void Run()
    {
        Console.WriteLine("Plugin2 is running from Class2");
    }
}
