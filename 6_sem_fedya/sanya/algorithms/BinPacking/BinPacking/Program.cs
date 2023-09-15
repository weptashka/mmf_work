using System;
using System.Collections.Generic;
using System.Linq;
using BinPacking.packing;

namespace BinPacking
{
    class Program
    {
        private static readonly Random random = new Random();
        private static readonly double MinRandomValue = 0.0;
        private static readonly double MaxRandomValue = 1.0;
        private static readonly int WeightsLength = 10000;
        private static readonly double Capacity = 1.0;

        static void Main(string[] args)
        {
            double[] weights = GenerateArrayWithRandomValues(WeightsLength, MinRandomValue, MaxRandomValue);

            PrintPackingResult(Packing.NextFit(weights, Capacity), "Next fit");
            PrintPackingResult(Packing.FirstFit(weights, Capacity), "First fit");
            PrintPackingResult(Packing.BestFit(weights, Capacity), "Best fit");
            PrintPackingResult(Packing.FirstFitDecreasing(weights, Capacity), "First fit decreasing");
        }

        private static void PrintPackingResult(int binsCount, string algorithmName)
        {
            Console.WriteLine(algorithmName + ":");
            Console.WriteLine(binsCount + " bins");
            Console.WriteLine("==============");
        }
        
        private static double RandomNumberBetween(double minValue, double maxValue)
        {
            var next = random.NextDouble();

            return minValue + (next * (maxValue - minValue));
        }

        private static double[] GenerateArrayWithRandomValues(int arrayLength, double minRandomValue, double maxRandomValue)
        {
            double[] randomValues = new double[arrayLength];

            for (int i = 0; i < arrayLength; i += 1)
            {
                randomValues[i] = RandomNumberBetween(minRandomValue, maxRandomValue);
            }

            return randomValues;
        }
    }
}