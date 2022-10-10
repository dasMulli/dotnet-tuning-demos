
// Construct sample data

using System.Diagnostics;
using MathNet.Numerics.Data.Text;
using MathNet.Numerics.LinearAlgebra;

Matrix<float> costs;

if(File.Exists("data.csv"))
{
    costs = DelimitedReader.Read<float>("data.csv", false, ";", false);
}
else
{
    var rnd = new Random(42);
    costs = Matrix<float>.Build.Dense(1_000, 2_000, (_,_) => (float)rnd.NextDouble());
    DelimitedWriter.Write("data.csv", costs, ";");
}
Console.WriteLine($"Costs: {costs.RowCount}x{costs.ColumnCount}");
Console.Out.WriteLine("Beginning calculation");
var stopWatch = new Stopwatch();
stopWatch.Start();
HungarianAlgorithm.FindAssignments(costs);
stopWatch.Stop();
Console.Out.WriteLine($"Calculation took {stopWatch.Elapsed}");