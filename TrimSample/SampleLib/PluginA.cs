namespace SampleLib;

public class PluginA : IPlugin
{
    public string Name => "Plugin A";

    public void DoSomething() => Console.WriteLine("Plugin A is doing something");
}