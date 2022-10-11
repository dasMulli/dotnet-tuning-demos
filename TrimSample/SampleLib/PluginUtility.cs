using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace SampleLib;
public class PluginUtility
{
    public static IPlugin CreatePlugin(Type type)
        => Activator.CreateInstance(type) as IPlugin ?? throw new Exception("Failed to create plugin");

    public static IList<string> FindAllPluginNames()
        => Assembly.GetAssembly(typeof(PluginUtility))!
            .ExportedTypes
            .Where(t => t.IsAssignableTo(typeof(IPlugin)) && !t.IsAbstract)
            .Select(t => CreatePlugin(t).Name)
            .ToList();
}




/*



    CreatePlugin([DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.All)] Type type)




    [UnconditionalSuppressMessage("ReflectionAnalysis", "IL2026")]
    [UnconditionalSuppressMessage("ReflectionAnalysis", "IL2067")]





    [DynamicDependency(DynamicallyAccessedMemberTypes.All, typeof(PluginA))]
    [DynamicDependency(DynamicallyAccessedMemberTypes.All, "SampleLib.PluginB", "SampleLib")]






    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.All)]
    private static Type _pluginCType;

    static PluginUtility()
    {
        _pluginCType = typeof(PluginC);
    }



*/