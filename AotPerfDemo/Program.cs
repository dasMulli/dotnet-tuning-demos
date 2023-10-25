
using System.Diagnostics;

var stopWatch = new Stopwatch();

var text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Ut congue lacus in metus imperdiet, id fermentum arcu congue. Vivamus sit amet orci sed nibh ultrices venenatis. Curabitur vitae interdum sem, a pharetra ligula. Cras in tortor aliquam, feugiat enim imperdiet, commodo lectus. Mauris sed orci non dolor condimentum dictum id vitae risus. Suspendisse et orci nibh. Quisque ac mattis ipsum. Morbi dolor ante, aliquet sed justo quis, efficitur vestibulum neque. Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Suspendisse tincidunt diam sed condimentum pellentesque. Suspendisse dignissim faucibus lacus, eu convallis ante rutrum ut. Ut malesuada, urna vel commodo sollicitudin, urna est molestie metus, ut rhoncus tellus orci quis sapien. Cras dapibus efficitur consequat. Morbi efficitur risus leo, vel sodales odio tempor id. Pellentesque sapien nunc, suscipit quis urna eu, tempus ultricies velit. Pellentesque id sapien iaculis, pretium odio vitae, mollis justo.";
var searchTerm = "sollicit";

for (int i = 1; i <= 5; i++)
{
    stopWatch.Restart();

    for (int j = 0; j < 10_000_000; j++)
    {
        text.IndexOf(searchTerm, StringComparison.Ordinal);
    }

    stopWatch.Stop();

    Console.WriteLine($"Iteration {i}: {stopWatch.ElapsedMilliseconds} ms");
}