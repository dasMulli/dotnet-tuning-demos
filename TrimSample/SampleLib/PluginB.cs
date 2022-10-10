namespace SampleLib;

public class PluginB : IPlugin
{
    public string Name => "Plugin B";

    public void DoSomething() => Console.WriteLine("Plugin B is doing something");
}