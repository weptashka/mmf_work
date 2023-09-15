using System;

namespace lab3
{
    public class Individual
    {
        private static readonly Random Rand = new();

        public int X;
        public int Y;
        public int Z;
        public int U;
        public int W;

        public Individual(int x, int y, int z, int u, int w)
        {
            X = x;
            Y = y;
            Z = z;
            U = u;
            W = w;
        }

        public static Individual Generate(int minValue, int maxValue)
        {
            return new Individual(
                Rand.Next(minValue, maxValue),
                Rand.Next(minValue, maxValue),
                Rand.Next(minValue, maxValue),
                Rand.Next(minValue, maxValue),
                Rand.Next(minValue, maxValue)
            );
        }

        public static int GenerateGenome(int minValue, int maxValue)
        {
            return Rand.Next(minValue, maxValue);
        }
    }
}