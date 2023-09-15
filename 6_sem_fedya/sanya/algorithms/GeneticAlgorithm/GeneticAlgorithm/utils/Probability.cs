using System;

namespace GeneticAlgorithm.utils
{
    public class Probability
    {
        private static readonly Random Rand = new Random();

        public static bool ComeTrue(double probability)
        {
            return Rand.NextDouble() > probability;
        }
        
        public static double GenerateProbability()
        {
            return Rand.NextDouble();
        }

        public static double[] GenerateProbabilities(int length)
        {
            double[] probabilities = new double[length]; 

            for (int i = 0; i < probabilities.Length; i++)
            {
                probabilities[i] = Rand.NextDouble();
            }

            return probabilities;
        }
    }
}