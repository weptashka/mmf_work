using System;
using lab5;

const double MinRandomValue = 0.0;
const double MaxRandomValue = 1.0;
const int WeightsLength = 10000;
const double Capacity = 1.0;

double[] weights = GenerateArrayWithRandomValues(WeightsLength, MinRandomValue, MaxRandomValue);
PrintPackingResult(Packing.NextFit(weights, Capacity), "Next fit");
PrintPackingResult(Packing.FirstFit(weights, Capacity), "First fit");
PrintPackingResult(Packing.BestFit(weights, Capacity), "Best fit");
PrintPackingResult(Packing.FirstFitDecreasing(weights, Capacity), "First fit decreasing");

static void PrintPackingResult(int binsCount, string algorithmName)
{
    Console.WriteLine(algorithmName + ":");
    Console.WriteLine(binsCount + " bins");
    Console.WriteLine("==============");
}
        
static double RandomNumberBetween(double minValue, double maxValue)
{
    var randomDouble = new Random().NextDouble();
    return minValue + (randomDouble * (maxValue - minValue));
}

double[] GenerateArrayWithRandomValues(int arrayLength, double minRandomValue, double maxRandomValue)
{
    double[] randomValues = new double[arrayLength];

    for (var i = 0; i < arrayLength; i += 1)
    {
        randomValues[i] = RandomNumberBetween(minRandomValue, maxRandomValue);
    }

    return randomValues;
}