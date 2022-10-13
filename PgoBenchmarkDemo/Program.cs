using System.Text;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Running;

BenchmarkRunner.Run<PgoBenchmarks>();

public class PgoBenchmarkConfig : ManualConfig
{
    public PgoBenchmarkConfig()
    {
        AddJob(Job.Default.WithId(".NET 7 Default"));

        AddJob(Job.Default.WithId("Dynamic PGO enabled")
            .WithEnvironmentVariable("DOTNET_TieredPGO", "1"));
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