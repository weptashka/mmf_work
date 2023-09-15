using System;

namespace GeneticAlgorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            PrintSolution(
                new EquationSolver(new[] { 1, 2, 2, 2, 2, 1, 0, 1, 0, 1, 1, 1, 0, 0, 2, 0, 0, 1, 0, 0, 2, 0, 0, 1, 1 }, -50));
            PrintSolution(
                new EquationSolver(new[] { 0, 1, 2, 1, 0, 1, 1, 2, 0, 0, 0, 0, 1, 0, 0, 1, 2, 2, 1, 1, 2, 1, 2, 0, 1 }, -50));
            // PrintSolution(
              //   new EquationSolver(new[] { 0, 0, 1, 0, 2, 0, 0, 2, 1, 0, 0, 2, 0, 0, 0, 2, 2, 2, 1, 1, 0, 1, 1, 0, 1 }, 22));
        }

        private static void PrintSolution(EquationSolver solver)
        {
            var (solution, iterations) = solver.Solve();
            
            Console.WriteLine($"X = {solution.X}, Y = {solution.Y}, Z = {solution.Z}, U = {solution.U}, W = {solution.W}");
            Console.WriteLine("Iterations = " + iterations);
            Console.WriteLine("Solution error = " + solver.GetSolutionError(solution));
        }
    }
}