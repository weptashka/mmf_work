using System;
using lab3;

PrintSolution(new EquationSolver(new[] { 
    2, 1, 0, 2, 0, 
    0, 0, 1, 0, 0, 
    0, 0, 0, 0, 0, 
    2, 0, 2, 1, 2, 
    0, 1, 0, 0, 0 }, 22));

static void PrintSolution(EquationSolver solver)
{
    var (solution, iterations) = solver.Solve();
            
    Console.WriteLine($"X = {solution.X}, Y = {solution.Y}, Z = {solution.Z}, U = {solution.U}, W = {solution.W}");
    Console.WriteLine("Iterations = " + iterations);
    Console.WriteLine("Solution error = " + solver.GetSolutionError(solution));
}