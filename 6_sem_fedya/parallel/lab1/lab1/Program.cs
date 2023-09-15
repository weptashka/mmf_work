using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace lab1
{
    internal static class Program
    {
        private static void Main()
        {
            var numbers = NumberGenerator.GenerateNumbersArray();
            
            ConsecutiveExecution(numbers);
            ChooseThreadingExecution(numbers, 2);
            ChooseThreadingExecution(numbers, 4);
            ChooseThreadingExecution(numbers, 6);
            ChooseThreadingExecution(numbers, 8);
            ChooseThreadingExecution(numbers, 10);
            ChooseThreadingExecution(numbers, 12);
        }

        private static void ChooseThreadingExecution(int[][] numbers, int threads)
        {
            var parallelOptions = new ParallelOptions
            {
                MaxDegreeOfParallelism = threads
            };
            
            Console.Write($"\n{threads}-threading execution: ");
            MultiThreadingExecution(numbers, parallelOptions);
        }

        private static void MultiThreadingExecution(int[][] numbers, ParallelOptions parallelOptions)
        {
            var stopwatch = new Stopwatch();

            stopwatch.Start();
            Parallel.For(
                0, 
                numbers.Length, 
                parallelOptions,
                i =>
                {
                    var quadraticEquationSolver = new QuadraticEquationSolver(
                        numbers[i][0], 
                        numbers[i][1], 
                        numbers[i][2]
                    );
                    quadraticEquationSolver.Solve();
                });
            
            var timeTaken = stopwatch.Elapsed;
            Console.Write(timeTaken.ToString(@"m\:ss\.fff"));
        }

        private static void ConsecutiveExecution(int[][] numbers)
        {
            var stopwatch = new Stopwatch();
            
            stopwatch.Start();
            for (var i = 0; i < 5; i++)
            {
                var quadraticEquationSolver = new QuadraticEquationSolver(
                    numbers[i][0], 
                    numbers[i][1], 
                    numbers[i][2]
                );
                quadraticEquationSolver.SolveAndOutputAnswer();
            }
            
            Console.Write("Consecutive execution: ");
            
            for (var i = 5; i < numbers.Length; i++)
            {
                var quadraticEquationSolver = new QuadraticEquationSolver(
                    numbers[i][0], 
                    numbers[i][1], 
                    numbers[i][2]
                );
                quadraticEquationSolver.Solve();
            }
            stopwatch.Stop();

            var timeTaken = stopwatch.Elapsed;
            Console.Write(timeTaken.ToString(@"m\:ss\.fff"));
        }
    }
}