using System.Diagnostics;

var stopWatch = new Stopwatch();
var factory = new Factory();

for (int i = 1; i <= 5; i++)
{
    stopWatch.Restart();

    for (int j = 0; j < 10_000; j++)
    {
        Workload(factory);
    }

    stopWatch.Stop();

    Console.WriteLine($"Iteration {i}: {stopWatch.ElapsedMilliseconds} ms");
}

static void Workload(IFactory factory)
{
    var thing = factory.CreateThing();
    while(!thing.FeelingHappy)
    {
        thing.GiveTreat();
    }
}

interface IFactory
{
    IThing CreateThing();
}

class Factory : IFactory
{
    public IThing CreateThing() => new Thing();
}

interface IThing
{
    bool FeelingHappy { get; }
    void GiveTreat();
}

class Thing : IThing
{
    private int treatCount = 0;
    public bool FeelingHappy => treatCount >= 10_000;

    public void GiveTreat()
    {
        treatCount++;
    }
}