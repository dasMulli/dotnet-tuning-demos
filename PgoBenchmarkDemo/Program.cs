﻿using System.Text;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Environments;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Running;

BenchmarkRunner.Run<PgoBenchmarks>();

public class PgoBenchmarkConfig : ManualConfig
{
    public PgoBenchmarkConfig()
    {
        AddJob(Job.Default.WithId(".NET 8 Default")
            .AsBaseline());

        AddJob(Job.Default.WithId(".NET 7 Default")
            .With(CoreRuntime.Core70));

        AddJob(Job.Default.WithId(".NET 8 Dynamic PGO disabled")
            .WithEnvironmentVariable("DOTNET_TieredPGO", "0"));
    }
}

[Config(typeof(PgoBenchmarkConfig))]
public class PgoBenchmarks
{

    public static IEnumerable<object> TestCollection()
    {
        // Test data for 'GuardedDevirtualization(ICollection<int>)'
        yield return new List<int>();
    }

    [Benchmark]
    [ArgumentsSource(nameof(TestCollection))]
    public void GuardedDevirtualization(ICollection<int> collection)
    {
        // a chain of unknown virtual calls...
        collection.Clear();
        collection.Add(1);
        collection.Add(2);
        collection.Add(3);
    }
    
    [Benchmark]
    public StringBuilder ProfileDrivenInlining()
    {
        StringBuilder sb = new();
        for (int i = 0; i < 1000; i++)
            sb.Append("hi");
        return sb;
    }
}