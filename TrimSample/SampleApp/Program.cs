﻿// See https://aka.ms/new-console-template for more information

using SampleLib;

Console.WriteLine("The following pluigns can be used:");

foreach (var pluginName in PluginUtility.FindAllPluginNames())
{
    Console.WriteLine(pluginName);
}

// Console.WriteLine("Let's do something with Plugin B...");

// var plugin = PluginUtility.CreatePlugin(typeof(PluginB));
// plugin.DoSomething();