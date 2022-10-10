namespace SampleLib;

public class PluginC : IPlugin
{
    public string Name => "Plugin C";

    public void DoSomething() => Console.WriteLine("Plugin C is doing something");
}