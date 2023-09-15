using System;

namespace local_search
{
    class Program
    {
        private const int MATRIX_SIZE = 100;
        private const int MIN_WEIGHT = 1;
        private const int MAX_WEIGHT = 10;
        
        private static readonly Random Rand = new Random();

        static void Main(string[] args)
        {
            int[,] weights = GenerateWeightMatrix(MATRIX_SIZE);
            int[] route = GetInitialRoute(MATRIX_SIZE);
            PrintSolution(MATRIX_SIZE, weights, route, TSPLocalSearch.Solve(MATRIX_SIZE, weights, route));
        }

        private static void PrintSolution(int maxtrixSize, int[,] weights, int[] initialRoute, int[] optimalRoute)
        {
            Console.WriteLine("============");
            Console.Write("[");
            for (int i = 0; i < maxtrixSize; i += 1)
            {
                Console.Write("[");
                for (int j = 0; j < maxtrixSize - 1; j += 1)
                {
                    Console.Write(weights[i, j] + ", ");
                }
                Console.WriteLine(weights[i, maxtrixSize - 1] + "]");
            }

            Console.WriteLine("]");

            // Console.WriteLine("[{0}]", string.Join(", ", initialRoute));
            // Console.WriteLine("[{0}]", string.Join(", ", optimalRoute));
        }

        private static int[] GetInitialRoute(int matrixSize)
        {
            int[] route = new int[matrixSize + 1];

            for (int i = 0; i < matrixSize; i += 1)
            {
                route[i] = i;
            }

            route[matrixSize] = 0;

            return route;
        }

        private static int[,] GenerateWeightMatrix(int matrixSize)
        {
            int[,] weights = new int[matrixSize, matrixSize];
            
            for (int i = 0; i < matrixSize; i += 1)
            {
                for (int j = 0; j < matrixSize; j += 1)
                {
                    if (i == j)
                    {
                        weights[i, j] = 0;
                        continue;
                    }

                    if (i > j)
                    {
                        weights[i, j] = weights[j, i];
                    }

                    weights[i, j] = Rand.Next(MIN_WEIGHT, MAX_WEIGHT);
                }
            }

            return weights;
        }
    }
}