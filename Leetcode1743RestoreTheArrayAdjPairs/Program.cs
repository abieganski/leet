// See https://aka.ms/new-console-template for more information


using Leetcode1743RestoreTheArrayAdjPairs;


// for very large test cases
const int largeStackSize = 1024 * 1024 * 64;
Thread th = new Thread(Executor, largeStackSize);
th.Start();
th.Join();


static void Executor()
{
    var solution = new Solution();

    List<int[][]> data =
    [
        [[2, 1], [3, 4], [3, 2]],
        [[2, 1], [3, 4], [3, 2]],
        [[4, -2], [1, 4], [-3, 1]],
        [[100000, -100000]],
        [[-2, 4], [6, 5], [1, 4], [1, -3], [7, -3], [-2, 6]],
        [[4, -10], [-1, 3], [4, -3], [-3, 3]],
    ];

    foreach (var d in data)
    {
        Console.WriteLine("input: " + string.Join(", ", d.Select(x => $"[{x[0]}, {x[1]}]")));

        var result = solution.RestoreArray(d);
        Console.WriteLine("result: " + string.Join(", ", result));
        Console.WriteLine();
    }

    Console.WriteLine("SOLUTION FROM LEET");

    var solutionFromLeet = new SolutionFromLeet();

    foreach (var d in data)
    {
        Console.WriteLine("input: " + string.Join(", ", d.Select(x => $"[{x[0]}, {x[1]}]")));

        var result = solutionFromLeet.RestoreArray(d);
        Console.WriteLine("result: " + string.Join(", ", result));
        Console.WriteLine();
    }
}
