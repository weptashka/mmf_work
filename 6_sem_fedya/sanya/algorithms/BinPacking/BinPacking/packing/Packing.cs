using System;

namespace BinPacking.packing
{
    public class Packing
    {
        public static int NextFit(double[] weights, double capacity)
        {
            int binsCount = 1;
            double binRemaining = capacity;
 
            for (int i = 0; i < weights.Length; i += 1)
            {
                if (weights[i] > binRemaining)
                {
                    binsCount += 1;
                    binRemaining = capacity - weights[i];
                }
                else
                {
                    binRemaining -= weights[i];
                }

            }
            return binsCount;
        }
        
        public static int FirstFit(double[] weights, double capacity)
        {
            int binsCount = 1;

            double[] binsRemaining = new double[weights.Length];
            Array.Fill(binsRemaining, capacity);

            for (int i = 0; i < weights.Length; i += 1)
            {
                int j;
                for (j = 0; j < binsCount; j += 1)
                {
                    if (binsRemaining[j] >= weights[i])
                    {
                        binsRemaining[j] -= weights[i];
                        break;
                    }
                }

                if (j == binsCount)
                {
                    binsCount += 1;
                    binsRemaining[binsCount - 1] = capacity - weights[i];
                }
            }

            return binsCount;
        }
        
        public static int BestFit(double[] weights, double capacity)
        {
            int binsCount = 1;

            double[] binsRemaining = new double[weights.Length];
            Array.Fill(binsRemaining, capacity);

            for (int i = 0; i < weights.Length; i += 1)
            {
                int j;
                double min = capacity + 1.0;
                int minIndex = 0;
 
                for (j = 0; j < binsCount; j += 1) {
                    if (binsRemaining[j] >= weights[i] && binsRemaining[j] - weights[i] < min) {
                        minIndex = j;
                        min = binsRemaining[j] - weights[i];
                    }
                }
                
                if (min == capacity + 1.0)
                {
                    binsCount += 1;
                    binsRemaining[binsCount - 1] = capacity - weights[i];
                }
                else
                {
                    binsRemaining[minIndex] -= weights[i];
                }
            }

            return binsCount;
        }

        public static int FirstFitDecreasing(double[] weights, double capacity)
        {
            Array.Sort(weights);
            Array.Reverse(weights);
            
            return FirstFit(weights, capacity);
        }
    }
}