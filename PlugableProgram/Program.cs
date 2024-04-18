using System.Reflection;
using PlugableLibrary;

const string PluginPath = "Plugins";

var pluginAssemblies = ScanPlugins();

var plugins = GetPluginsFromAssemblies(pluginAssemblies);

ActivateAndRunPlugins(plugins);

static Assembly[] ScanPlugins()
{
    var assemblies = new List<Assembly>();
    var files = Directory.GetFiles(PluginPath, "*.dll");
    foreach (var file in files)
    {
        var assembly = Assembly.LoadFile(Path.GetFullPath(file));
        assemblies.Add(assembly);
    }
    return assemblies.ToArray();
}


// Get all type which implement IPlugin interface from assembly
static Type[] GetPluginsFromAssembly(Assembly assembly)
{
    var pluginType = typeof(IPlugin);
    var types = assembly.GetTypes();
    var plugins = types.Where(pluginType.IsAssignableFrom).ToArray();
    return plugins;
}

static Type[] GetPluginsFromAssemblies(Assembly[] assemblies)
{

    var plugins = new List<Type>();
    foreach (var assembly in assemblies)
    {
        var assemblyPlugins = GetPluginsFromAssembly(assembly);
        plugins.AddRange(assemblyPlugins);
    }
    return plugins.ToArray();
}

static void ActivateAndRunPlugins(Type[] plugins)
{

    foreach (var plugin in plugins)
    {
        var instance = Activator.CreateInstance(plugin);
        var runMethod = plugin.GetMethod("Run")!;
        runMethod.Invoke(instance, null);
    }
}