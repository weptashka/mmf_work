using System;
using lab4;

const int MATRIX_SIZE = 10;
const int MIN_WEIGHT = 1;
const int MAX_WEIGHT = 10;

int[,] weights = GenerateWeightMatrix(MATRIX_SIZE);
int[] route = GetInitialRoute(MATRIX_SIZE);
PrintSolution(MATRIX_SIZE, weights, route, TspLocalSearch.Solve(MATRIX_SIZE, weights, route));

static void PrintSolution(int matrixSize, int[,] weights, int[] initialRoute, int[] optimalRoute)
{
    Console.WriteLine("============");
    
    for (var i = 0; i < matrixSize; i += 1)
    {
        Console.Write("[");
        for (var j = 0; j < matrixSize - 1; j += 1)
        {
            Console.Write(weights[i, j] + ", ");
        }

        Console.WriteLine(weights[i, matrixSize - 1] + "]");
    }
}

static int[] GetInitialRoute(int matrixSize)
{
    var route = new int[matrixSize + 1];

    for (var i = 0; i < matrixSize; i += 1)
    {
        route[i] = i;
    }

    route[matrixSize] = 0;

    return route;
}

static int[,] GenerateWeightMatrix(int matrixSize)
{
    var random = new Random();
    var weights = new int[matrixSize, matrixSize];

    for (var i = 0; i < matrixSize; i += 1)
    {
        for (var j = 0; j < matrixSize; j += 1)
        {
            if (i == j)
            {
                weights[i, j] = 0;
                continue;
            }

            if (i < j)
            {
                weights[i, j] = random.Next(MIN_WEIGHT, MAX_WEIGHT);
            }
            else
            {
                weights[i, j] = weights[j, i];
            }
        }
    }

    return weights;
}