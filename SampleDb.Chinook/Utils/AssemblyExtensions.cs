using System.Reflection;

namespace SampleDb.Chinook.Utils;

public static class AssemblyExtensions
{
    public static string? ReadResource(this Assembly assembly, string resourceName)
    { 
        var rootNamespace = assembly.GetName().Name;
        resourceName = $"{rootNamespace}.{resourceName}";
        using var stream = assembly.GetManifestResourceStream(resourceName);
        if (stream == null)
        {
            return null;
        }

        using var reader = new StreamReader(stream);
        return reader.ReadToEnd();
    } 
    
    public static string[] GetResourceNames(this Assembly assembly)
    {
        return assembly.GetManifestResourceNames();
    }
}